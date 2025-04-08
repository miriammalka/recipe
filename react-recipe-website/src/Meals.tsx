import { DataGrid, GridColDef } from "@mui/x-data-grid";
import { useEffect, useState } from "react";
import { IMeal } from "./DataInterfaces";
import { fetchMeals } from "./DataUtility";

export default function Meals() {

  const [rowData, setRowData] = useState<IMeal[]>([]);

  useEffect(() => {
    const fetchdata = async () => {
      const data = await fetchMeals();
      console.log("Fetched meals:", data);
      setRowData(data);
    };
    fetchdata();
  }, []);

  const columns: GridColDef[] = [
    { field: "mealName", headerName: "Meal Name", width: 150, editable: false },
    { field: "username", headerName: "User Name", width: 150, editable: false },
    { field: "dateCreated", headerName: "Date Created", width: 150, editable: false },
    { field: "mealDesc", headerName: "Meal Description", width: 150, editable: false },
    { field: "numCalories", headerName: "Number of Calories", width: 150, editable: false },
    { field: "numCourses", headerName: "Number of Courses", width: 150, editable: false },
    { field: "numRecipes", headerName: " Number of Recipes", width: 150, editable: false },
    { field: "active", headerName: "Active", width: 150, editable: false },
  ];


  return (
    <div style={{ height: '100%', width: '100%' }}>
      <h1>Meals</h1>
      <hr />
      <DataGrid
        rows={rowData}
        columns={columns}
        getRowId={(row) => row.mealId}
      />
    </div>
  )
}
