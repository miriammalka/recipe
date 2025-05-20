import { useEffect, useMemo, useState } from 'react'
import {
  blankCourse, blankCuisine, blankIngredient, blankMeasurementType, blankUsers,
  deleteCourse,
  deleteCuisine, deleteIngredient, deleteMeasurementType, deleteUsers,
  fetchCourse, fetchCuisines, fetchIngredients, fetchMeasureMentType, fetchUsers,
  postCourse,
  postCuisine,
  postIngredient,
  postMeasurementType,
  postUsers
} from './DataUtility';
import { DataGrid, GridColDef } from '@mui/x-data-grid';
import { Button, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle } from "@mui/material";
import DeleteIcon from "@mui/icons-material/Delete";
import SaveIcon from "@mui/icons-material/Save"
import { ICourse, ICuisine, IIngredient, IMeasurementType, IUsers } from './DataInterfaces';
import { commonDataGridStyles, commonSortingOrder, withDefaultColumnStyles } from "./assets/muiDataGridStyles";

interface Props {
  tableOption: string,
  onChanged: (value: any, fordelete: boolean) => void;
}

export default function DataMaintenanceGrid({ tableOption, onChanged }: Props) {

  const [data, setData] = useState<any[]>([]);
  const [errormsg, setErrormsg] = useState("");
  const [paginationModel, setPaginationModel] = useState({
    pageSize: 10,
    page: 0
  })

  const [confirmOpen, setConfirmOpen] = useState(false);
  const [rowToDelete, setRowToDelete] = useState<any>(null);

  const fetchFunctions: Record<string, () => Promise<any>> = {
    users: fetchUsers,
    cuisine: fetchCuisines,
    ingredient: fetchIngredients,
    course: fetchCourse,
    measurementType: fetchMeasureMentType
  };


  //function to fetch data based on option selected 
  useEffect(() => {
    const fetchData = async () => {
      try {
        if (fetchFunctions[tableOption]) {
          const responseData = await fetchFunctions[tableOption]();
          //console.log("Fetched data keys:", Object.keys(responseData[0] || {}));
          setData(responseData);
          //console.log("fetched data: ", responseData);
        }
      }
      catch (error) {
        console.error("Error fetching data:", error);
        setData([]);
      }
    };
    fetchData();
  },
    [tableOption]);

  const allowedColumns: Record<string, string[]> = {

    cuisine: ["cuisineName"],
    users: ["firstName", "lastName", "userName"],
    ingredient: ["ingredientName"],
    course: ["courseName", "sequenceOrder"],
    measurementType: ["measurementType"]

  };

  //need to work on delete functions

  const deleteFunctions: Record<string, (record: any) => Promise<any>> = {
    users: deleteUsers,
    cuisine: deleteCuisine,
    ingredient: deleteIngredient,
    course: deleteCourse,
    measurementType: deleteMeasurementType
  };

  const askDeleteConfirmation = (row: any) => {
    setRowToDelete(row);
    setConfirmOpen(true);
  };

  const confirmDelete = async () => {
    if (!rowToDelete) return;

    try {
      setErrormsg("");
      const response = await deleteFunctions[tableOption](rowToDelete);
      if ((response as any).errorMessage) {
        throw new Error((response as any).errorMessage);
      }

      const updatedData = data.filter((item) => item !== rowToDelete);
      setData(updatedData);
      onChanged(updatedData, true);
    } catch (error: any) {
      setErrormsg(error.message);
    } finally {
      setConfirmOpen(false);
      setRowToDelete(null);
    }
  };

  const blankTableRecord: Record<string, any> = {
    course: blankCourse,
    measurementType: blankMeasurementType,
    ingredient: blankIngredient,
    cuisine: blankCuisine,
    users: blankUsers
  };

  const handleAddNew = () => {
    const blankRecord = blankTableRecord[tableOption];
    //console.log(blankRecord)
    if (!blankRecord) {
      console.error(`No blank record found for table: ${tableOption}`);
      return;
    }

    const nextId = -(data.length + 1); // Generate a temporary negative ID
    const newRecord = {
      ...blankRecord,
      id: nextId, // Ensure it has a temporary ID
    };

    setData([...data, newRecord]); // Add the new record to the state
  };

  const postFunctions: Record<string, (record: any) => Promise<any>> = {
    users: postUsers,
    cuisine: postCuisine,
    ingredient: postIngredient,
    course: postCourse,
    measurementType: postMeasurementType
  };

  const getRowId = (row: any): number => {
    return row.id || row.usersId || row.cuisineId || row.courseId || row.measurementTypeId || row.ingredientId;
  };

  const handleSave = async (row: ICourse | ICuisine | IIngredient | IMeasurementType | IUsers) => {
    try {
      setErrormsg("");
      const recordId = getRowId(row);
      const updatedRecord = await postFunctions[tableOption](row);
      if (updatedRecord.errormsg) {
        throw new Error(updatedRecord.errormsg);
      }

      const updatedData = data.map((item) => getRowId(item) === recordId ? updatedRecord : item);
      setData(updatedData);
      onChanged(updatedRecord, false);
    }

    catch (error: any) {
      setErrormsg(error.message);
    }
  }


  const columns: GridColDef[] = useMemo(() => {
    if (data.length === 0) return [];

    const validColumns = allowedColumns[tableOption] || [];

    const dynamicColumns = Object.keys(data[0])
      .filter((key) => validColumns.includes(key))
      .map((key) => ({
        headerName: key.charAt(0).toUpperCase() + key.slice(1),
        field: key,
        sortable: true,
        filterable: true,
        flex: 1,
        editable: true,
      }

      ));

    const deleteColumn: GridColDef = {
      field: "delete",
      headerName: "Delete",
      sortable: false,
      filterable: false,
      flex: 0.5,
      renderCell: (params) => (
        <Button
          variant="contained"
          color="error"
          size="small"
          onClick={() => askDeleteConfirmation(params.row)}
        >
          <DeleteIcon />
        </Button>
      ),
    };

    const saveColumn: GridColDef = {
      field: "save",
      headerName: "Save",
      sortable: false,
      filterable: false,
      flex: 0.5,
      renderCell: (params) => (
        <Button
          variant="contained"
          color="error"
          size="small"
          onClick={() => handleSave(params.row)}
        >
          <SaveIcon />
        </Button>
      ),
    }

    return withDefaultColumnStyles([...dynamicColumns, deleteColumn, saveColumn])

  }, [data, tableOption])


  return (
    <>
      <div>
        <h3>{errormsg}</h3>
        <button className='btn btn-primary' onClick={handleAddNew}>Add New</button>
      </div>
      <DataGrid
        rows={data}
        columns={columns}
        sortingOrder={commonSortingOrder}
        sx={commonDataGridStyles}
        pagination
        paginationModel={paginationModel}
        onPaginationModelChange={setPaginationModel}
        pageSizeOptions={[5, 10, 20]}
        disableRowSelectionOnClick
        getRowId={getRowId} // Ensure unique row ID
      />
      <Dialog open={confirmOpen} onClose={() => setConfirmOpen(false)}>
        <DialogTitle>Confirm Deletion</DialogTitle>
        <DialogContent>
          <DialogContentText>
            Are you sure you want to delete{' '}
            {rowToDelete?.cuisineName || rowToDelete?.userName || rowToDelete?.ingredientName ||
              rowToDelete?.courseName || rowToDelete?.measurementType || "this record"}?
          </DialogContentText>
        </DialogContent>
        <DialogActions>
          <Button onClick={() => setConfirmOpen(false)} color="primary">
            Cancel
          </Button>
          <Button onClick={confirmDelete} color="error">
            Yes
          </Button>
        </DialogActions>
      </Dialog>
    </>

  )
}
