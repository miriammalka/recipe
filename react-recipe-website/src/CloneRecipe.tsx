import React, { useEffect, useState } from 'react'
import { DataGrid, type GridColDef, GridActionsCellItem } from '@mui/x-data-grid';
import { IRecipe } from './DataInterfaces';
import { fetchRecipes } from './DataUtility';


const [recipes, setRecipes] = useState<IRecipe[]>([]);

useEffect(() => {
    const fetchData = async () => {
        const data = await fetchRecipes();
        setRecipes(data);
    };
    fetchData();
}, []);

const columns: GridColDef[] = [

    {
        field: "recipeId", headerName: "Recipe Name", width: 150, editable: true,
        type: "singleSelect",
        valueOptions: recipes.map(recipe => ({
            value: recipe.recipeId,
            label: recipe.recipeName
        }))
    }];
export default function CloneRecipe() {
    return (
        <>
            <div>CloneRecipe</div>


        </>

    )
}
