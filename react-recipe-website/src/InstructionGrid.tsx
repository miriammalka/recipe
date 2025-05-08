import { useState } from "react";
import { DataGrid, type GridColDef, GridActionsCellItem } from '@mui/x-data-grid';
import SaveIcon from '@mui/icons-material/Save';
import DeleteIcon from '@mui/icons-material/Delete';
import { IInstruction, IRecipe } from "./DataInterfaces";
import { postInstruction, deleteInstruction, blankInstruction } from "./DataUtility";
import { commonDataGridStyles, commonSortingOrder, withDefaultColumnStyles } from "./assets/muiDataGridStyles";

interface Props {
    recipe: IRecipe;
    onChanged: (value: IInstruction, fordelete: boolean) => void;
}

export function InstructionGrid({ recipe, onChanged }: Props) {

    const [errormsg, setErrormsg] = useState("");
    const [rowData, setRowData] = useState<IInstruction[]>(recipe?.instructionList || []);

    const columns: GridColDef[] = withDefaultColumnStyles([
        { field: "sequenceOrder", headerName: "Sequence Order", width: 150, editable: true },
        { field: "instruction", headerName: "Instruction", width: 150, editable: true },
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

    ])


    const handleSave = async (row: IInstruction) => {
        try {
            setErrormsg("");
            //this code handles new records and updates, for new records the primary key before post is a negative number
            const recordid = row.instructionId;
            //if new record then after post updatedOrder has the new primary key
            const updatedInstruction = await postInstruction(row);
            if (updatedInstruction.errorMessage) {
                throw new Error(updatedInstruction.errorMessage);
            }

            const updatedData = rowData.map(instruction =>
                //match on recordid because if new record then rowData still has the negative primary key
                instruction.instructionId === recordid ? updatedInstruction : instruction
            );
            setRowData(updatedData);
            onChanged(updatedInstruction, false);
        } catch (error: any) {
            setErrormsg(error.message);
        }
    };


    const handleDelete = async (row: IInstruction) => {
        try {
            setErrormsg("");
            const r = await deleteInstruction(row);
            if ((r as any).errorMessage) {
                throw new Error((r as any).errorMessage);
            }
            const updatedData = rowData.filter(instruction => instruction.instructionId !== row.instructionId);
            setRowData(updatedData);
            onChanged(row, true);
        } catch (error: any) {
            setErrormsg(error.message);
        }
    };

    const processRowUpdate = (updatedrow: IInstruction) => {
        const updatedRows = rowData.map(row =>
            row.instructionId === updatedrow.instructionId ? updatedrow : row
        );
        setRowData(updatedRows);
        return updatedrow;
    };

    const handleAddNew = () => {
        const nextId = -(rowData.length + 1);
        const newInstruction = {
            ...blankInstruction,
            instructionId: nextId, // Use a negative number as a temporary ID
            recipeId: recipe.recipeId,
        };
        setRowData([...rowData, newInstruction]);
    };

    return (
        <div style={{ height: '100%', width: '100%' }}>
            <h3>{errormsg}</h3>
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
                getRowId={(row) => row.instructionId} 
                sortingOrder={commonSortingOrder}
                sx={commonDataGridStyles}/>

        </div>
    );
}
