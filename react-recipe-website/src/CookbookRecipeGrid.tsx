import { useState, useEffect } from "react";
import { DataGrid, type GridColDef, GridActionsCellItem } from '@mui/x-data-grid';
import SaveIcon from '@mui/icons-material/Save';
import DeleteIcon from '@mui/icons-material/Delete';
import { ICookbook, ICookbookRecipe, IRecipe } from "./DataInterfaces";
import { blankCookbookRecipe, deleteCookbookRecipe, fetchRecipes, postCookbookRecipe } from "./DataUtility";

interface Props {
    cookbook: ICookbook;
    onChanged: (value: ICookbookRecipe, fordelete: boolean) => void;
}

export function CookbookRecipeGrid({ cookbook, onChanged }: Props) {

    const [errormsg, setErrormsg] = useState("");
    const [rowData, setRowData] = useState<ICookbookRecipe[]>(cookbook?.cookbookRecipeList || []);
    const [recipes, setRecipes] = useState<IRecipe[]>([]);

    useEffect(() => {
        const fetchData = async () => {
            const data = await fetchRecipes();
            setRecipes(data);
            console.log(data)
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
        },
        { field: "sequenceOrder", headerName: "Sequence Order", width: 150, editable: true },
        {
            field: "actions",
            headerName: "Actions",
            type: 'actions',
            width: 150,
            getActions: (params) => [
                <GridActionsCellItem
                    icon={<SaveIcon />}
                    label="Save"
                    onClick={() => handleSave(params.row)}
                />,
                <GridActionsCellItem
                    icon={<DeleteIcon />}
                    label="Delete"
                    onClick={() => handleDelete(params.row)}
                />
            ],
        },

    ]

    //need to spread all values of recipe into Cookbook Recipe
    const handleSave = async (row: ICookbookRecipe) => {
        try {
            setErrormsg("");
            //this code handles new records and updates, for new records the primary key before post is a negative number
            const recordid = row.cookbookRecipeId;
            //if new record then after post updatedOrder has the new primary key
            const updatedRecipe = await postCookbookRecipe(row);
            if (updatedRecipe.errorMessage) {
                throw new Error(updatedRecipe.errorMessage);
            }

            const updatedData = rowData.map(recipe =>
                //match on recordid because if new record then rowData still has the negative primary key
                recipe.cookbookRecipeId === recordid ? updatedRecipe : recipe
            );
            console.log(updatedData);
            setRowData(updatedData);
            onChanged(updatedRecipe, false);
        } catch (error: any) {
            setErrormsg(error.message);
        }
    };



    const handleDelete = async (row: ICookbookRecipe) => {
        try {
            setErrormsg("");
            const r = await deleteCookbookRecipe(row);
            if ((r as any).errorMessage) {
                throw new Error((r as any).errorMessage);
            }
            const updatedData = rowData.filter(ingredient => ingredient.cookbookRecipeId !== row.cookbookRecipeId);
            setRowData(updatedData);
            onChanged(row, true);
        } catch (error: any) {
            setErrormsg(error.message);
        }
    };

    const processRowUpdate = (updatedrow: ICookbookRecipe) => {
        const updatedRows = rowData.map(row =>
            row.cookbookRecipeId === updatedrow.cookbookRecipeId ? updatedrow : row
        );
        setRowData(updatedRows);
        return updatedrow;
    };

    const handleAddNew = () => {
        const nextId = -(rowData.length + 1);
        const newCookbookRecipe = {
            ...blankCookbookRecipe,
            cookbookRecipeId: nextId, // Use a negative number as a temporary ID
            cookbookId: cookbook.cookbookId,
        };
        setRowData([...rowData, newCookbookRecipe]);
    };

    return (
        <div style={{ height: '100%', width: '100%' }}>
            <h2>{errormsg}</h2>
            <button
                className="btn btn-primary"
                onClick={handleAddNew}
            >
                Add New
            </button>
            <DataGrid
                rows={rowData}
                columns={columns}
                processRowUpdate={processRowUpdate}
                getRowId={(row) => row.cookbookRecipeId} />

        </div>
    );
}
