import { useState, useEffect } from "react";
import { DataGrid, type GridColDef, GridActionsCellItem } from '@mui/x-data-grid';
import SaveIcon from '@mui/icons-material/Save';
import DeleteIcon from '@mui/icons-material/Delete';
import { IIngredient, IRecipeIngredient, IRecipe, IMeasurementType } from "./DataInterfaces";
import { fetchIngredients, postRecipeIngredient, deleteRecipeIngredient, blankRecipeIngredient, fetchMeasureMentType } from "./DataUtility";

interface Props {
    recipe: IRecipe;
    onChanged: (value: IRecipeIngredient, fordelete: boolean) => void;
}

export function RecipeIngredientGrid({ recipe, onChanged }: Props) {

    const [errormsg, setErrormsg] = useState("");
    const [rowData, setRowData] = useState<IRecipeIngredient[]>(recipe?.recipeIngredientList || []);
    const [ingredients, setIngredients] = useState<IIngredient[]>([]);
    const [measurementTypes, setMeasurementTypes] = useState<IMeasurementType[]>([]);

    useEffect(() => {
        const fetchData = async () => {
            const data = await fetchIngredients();
            setIngredients(data);
        };
        fetchData();
    }, []);

    useEffect(() => {
        const fetchData = async () => {
            const data = await fetchMeasureMentType();
            setMeasurementTypes(data);
        };
        fetchData();
    }, []);

    const columns: GridColDef[] = [
        { field: "sequenceOrder", headerName: "Sequence Order", width: 150, editable: true, type: "number",
            preProcessEditCellProps: (params) => {
                const isValid = !isNaN(params.props.value) && Number(params.props.value) > 0;
                return { ...params.props, error: !isValid };
            },
            valueParser: (value) => Number(value) || 0
        },
        {
            field: "ingredientId", headerName: "Ingredient Name", width: 150, editable: true,
            type: "singleSelect",
            valueOptions: ingredients.map(ingredient => ({
                value: ingredient.ingredientId,
                label: ingredient.ingredientName
            }))
        },

        { 
            field: "amount", 
            headerName: "Amount", 
            width: 150, 
            editable: true, 
            type: "number",
            preProcessEditCellProps: (params) => {
                const isValid = !isNaN(params.props.value) && Number(params.props.value) > 0;
                return { ...params.props, error: !isValid };
            },
            valueParser: (value) => Number(value) || 0
        },
        
        {
            field: "measurementTypeId", headerName: "Measurement", width: 150, editable: true,
            type: "singleSelect",
            valueOptions: measurementTypes.map(measurement => ({
                value: measurement.measurementTypeId,
                label: measurement.measurementType
            }))
        },
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


    const handleSave = async (row: IRecipeIngredient) => {
        console.log('handle save')
        const formattedRow = {
            ...row,
            amount: Number(row.amount) || 0,
            sequenceOrder: Number(row.sequenceOrder) || 0
        }
        try {
            setErrormsg("");
            //this code handles new records and updates, for new records the primary key before post is a negative number
            const recordID = formattedRow.recipeIngredientId;
            //if new record then after post updatedOrder has the new primary key
            const updatedIngredient = await postRecipeIngredient(formattedRow);
            //check if new record has new pk
            console.log(updatedIngredient);
            if (updatedIngredient.errorMessage) {
                throw new Error(updatedIngredient.errorMessage);
            }
            //this is where recipeingredient save is not working
            const updatedData = rowData.map(ingredient =>
                //match on recordid because if new record then rowData still has the negative primary key
                ingredient.recipeIngredientId === recordID ? updatedIngredient : ingredient
            );
            setRowData(updatedData);
            console.log("checking if updated data has new ID", updatedData);
            console.log("Saved ingredient to DB:", updatedIngredient);
            onChanged(updatedIngredient, false);
        } catch (error: any) {
            setErrormsg(error.message);
        }
    };



    const handleDelete = async (row: IRecipeIngredient) => {
        try {
            setErrormsg("");
            const r = await deleteRecipeIngredient(row);
            if ((r as any).errorMessage) {
                throw new Error((r as any).errorMessage);
            }
            const updatedData = rowData.filter(ingredient => ingredient.recipeIngredientId !== row.recipeIngredientId);
            setRowData(updatedData);
            onChanged(row, true);
        } catch (error: any) {
            setErrormsg(error.message);
        }
    };

    const processRowUpdate = (updatedrow: IRecipeIngredient) => {
        const updatedRows = rowData.map(row =>
            row.recipeIngredientId === updatedrow.recipeIngredientId ? updatedrow : row
        );
        setRowData(updatedRows);
        return updatedrow;
    };

    const handleAddNew = () => {
        const nextId = -(rowData.length + 1);
        const newIngredient = {
            ...blankRecipeIngredient,
            recipeIngredientId: nextId, // Use a negative number as a temporary ID
            recipeId: recipe.recipeId,
        };
        setRowData([...rowData, newIngredient]);
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
                getRowId={(row) => row.recipeIngredientId} />

        </div>
    );
}
