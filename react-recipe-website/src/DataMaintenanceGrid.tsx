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
import { Button, Pagination } from "@mui/material";
import DeleteIcon from "@mui/icons-material/Delete";
import SaveIcon from "@mui/icons-material/Save"
import { ICourse, ICuisine, IIngredient, IMeasurementType, IUsers } from './DataInterfaces';
import { toast } from 'react-toastify';

interface Props {
  tableOption: string,
  onChanged: (value: any, fordelete: boolean) => void;
}

export default function DataMaintenanceGrid({ tableOption, onChanged }: Props) {

  const [data, setData] = useState<any[]>([]);
  const [errormsg, setErrormsg] = useState("");

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
          setData(responseData);
          console.log("fetched data: ", responseData);
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

  const handleDelete = async (row: { cuisineName: ICuisine; userName: IUsers; ingredientName: IIngredient; courseName: ICourse; measurementType: IMeasurementType }) => {
    const confirmed = window.confirm(`Are you sure your want to delete ${row.cuisineName || row.userName || row.ingredientName || row.courseName || row.measurementType || "this record"}?`);
    if (confirmed) {
      try {
        setErrormsg("");
        const response = await deleteFunctions[tableOption](row);
        if ((response as any).errorMessage) {
          throw new Error((response as any).errorMessage);
        }
        const updatedData = data.filter(tableOption => tableOption[0] !== data[0]);
        setData(updatedData);
        onChanged(data, true);
      }
      catch (error: any) {
        setErrormsg(error.message);
      }
      setData((prevData) => prevData.filter((item) => item !== row));
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
    console.log(blankRecord)
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


  // const handleAddNew = () => {
  //   // window.confirm("add new record");
  //   console.log("add new", tableOption);
  // }

  const postFunctions: Record<string, (record: any) => Promise<any>> = {
    users: postUsers,
    cuisine: postCuisine,
    ingredient: postIngredient,
    course: postCourse,
    measurementType: postMeasurementType
  };

  const getRowId = (row:any): number=>{
    return row.id || row.usersId || row.cuisineId || row.courseId || row.measurementTypeId;
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

  // const handleSave = async (row: any) => {
  //   try {
  //     setErrormsg("");

  //     const response = await postFunctions[tableOption](row);

  //     if (response.errormsg) {
  //       throw new Error(response.errormsg);
  //     }

  //     // Update the saved record in the grid state
  //     const updatedData = data.map((item) =>
  //       item.id === row.id ? response : item
  //     );
  //     toast.success("Record saved successfully!");
  //     setData(updatedData);
  //     onChanged(response, false);
  //   } catch (error: any) {
  //     setErrormsg(error.message || "An error occurred while saving.");
  //   }
  // };



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
          onClick={() => handleDelete(params.row)}
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

    return [...dynamicColumns, deleteColumn, saveColumn]

  }, [data, tableOption])


  return (
    <>
      <div>
        <h2>{errormsg}</h2>
        <button className='btn btn-primary' onClick={handleAddNew}>Add New</button>
      </div>
      <DataGrid
        rows={data}
        columns={columns}
        pageSizeOptions={[5, 10, 20]}
        pagination
        disableRowSelectionOnClick
        getRowId={(row) => row.id || row.recipeId || row.cuisineId || row.usersId || row.courseId || row.measurementTypeId || Math.random()} // Ensure unique row ID
      />

    </>

  )
}
