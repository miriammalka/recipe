//This file is equivalent to recipe card

import { DataGrid, GridColDef } from "@mui/x-data-grid";
import { useEffect, useState } from "react";
import { ICookbook } from "./DataInterfaces";
import { fetchCookbooks } from "./DataUtility";
import { commonDataGridStyles, commonSortingOrder, withDefaultColumnStyles } from "./assets/muiDataGridStyles";


interface Props {
  onCookbookEdit: (cookbokid: number) => void;
  onAutoCreatCookbook: (cookbook: ICookbook) => void;
}

export default function CookbookList({ onCookbookEdit, onAutoCreatCookbook }: Props) {

  const [rowData, setRowData] = useState<ICookbook[]>([]);


  useEffect(() => {
    const fetchdata = async () => {
      const data = await fetchCookbooks();
      //console.log("fetched cookbooks", data)
      data.forEach(cookbook => {
        switch (cookbook.skillLevel) {
          case 1:
            return cookbook.skillLevelString = 'Beginner';
          case 2:
            return cookbook.skillLevelString = 'Intermediate';
          case 3:
            return cookbook.skillLevelString = 'Advanced';
          default: return;
        }
      })
      setRowData(data);
    };
    fetchdata();
  }, [onAutoCreatCookbook]);

  const columns: GridColDef[] = withDefaultColumnStyles([
    { field: "cookbookName", headerName: "Cookbook Name", width: 150, editable: false },
    { field: "usersId", headerName: "User Name", width: 150, editable: false },
    { field: "price", headerName: "Price", width: 150, editable: false },
    { field: "dateCreated", headerName: "Date Created", width: 150, editable: false },
    { field: "active", headerName: "Active", width: 150, editable: false },
    { field: "skillLevelString", headerName: "Skill Level", width: 150, editable: false },
    {
      field: "actions",
      headerName: "Actions",
      width: 100,
      sortable: false,
      renderCell: (params => {
        return (
          <button className="btn btn-primary" onClick={() => onCookbookEdit(params.row.cookbookId)}>Edit</button>
        );
      })
    }
  ]);

  return (
    <div style={{ height: '100%', width: '100%' }}>
      <div className="row">
        <DataGrid
          rows={rowData}
          columns={columns}
          getRowId={(row) => row.cookbookId}
          sortingOrder={commonSortingOrder}
          sx={commonDataGridStyles}
        />
      </div>

    </div>
  )
}

