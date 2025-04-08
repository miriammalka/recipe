//This file is equivalent to recipe card
//I might not need this file
import { DataGrid, GridColDef } from "@mui/x-data-grid";
import { useEffect, useState } from "react";
import { ICookbook } from "./DataInterfaces";
import { fetchCookbooks } from "./DataUtility";


interface Props {
  onCookbookEdit: (cookbokid: number) => void;
  onAutoCreatCookbook: (cookbook: ICookbook)=> void;
}

export default function CookbookList({ onCookbookEdit, onAutoCreatCookbook }: Props) {

  const [rowData, setRowData] = useState<ICookbook[]>([]);
  //const [cookbookId, setCookbookId] = useState(0);
  // const [cookbookList, setCookbookList] = useState<ICookbook[]>([]);
  //const navigate = useNavigate();

  useEffect(() => {
    const fetchdata = async () => {
      const data = await fetchCookbooks();
      console.log("fetched cookbooks", data)
      setRowData(data);
      //setCookbookId(0);
    };
    fetchdata();
  }, [onAutoCreatCookbook]);

  // const handleEditClick = (cookbookid: number) => {
  //   console.log("Editing cookbook with ID:", cookbookid);
  //   setCookbookId(cookbookid)
  //   //navigate(`/CookbookEdit`); // Redirect to edit page
  // };

  const columns: GridColDef[] = [
    { field: "cookbookName", headerName: "Cookbook Name", width: 150, editable: false },
    { field: "usersId", headerName: "User Name", width: 150, editable: false },
    { field: "price", headerName: "Price", width: 150, editable: false },
    { field: "dateCreated", headerName: "Date Created", width: 150, editable: false },
    { field: "active", headerName: "Active", width: 150, editable: false },
    { field: "skillLevelDesc", headerName: "Skill Level Description", width: 150, editable: false },
    {
      field: "actions",
      headerName: "Actions",
      width: 100,
      sortable: false,
      renderCell: (params => (
        <button className="btn btn-primary" onClick={() => onCookbookEdit(params.row.cookbookId)}>Edit</button>

      ))
    }
  ];

  //need to create function to create new cookbook
  return (
    <div style={{ height: '100%', width: '100%' }}>
      <div className="row">
        <DataGrid
          rows={rowData}
          columns={columns}
          getRowId={(row) => row.cookbookId} />
      </div>

    </div>
  )
}

