import { ICellRendererParams } from "ag-grid-community";
import { Dispatch, MutableRefObject, SetStateAction } from "react";
import { FieldValues } from "react-hook-form";
import './assets/css/ActionCellRenderer.css'; // Import the CSS file


interface ActionCellRendererProps<T> {
    params: ICellRendererParams;
    onChanged: (value: T, fordelete: boolean) => void;
    setError: (message: string) => void;
    updateObject: (value: FieldValues) => Promise<T>;
    deleteObject: (value: T) => Promise<T>;
    rowData: T[];
    gridRef: MutableRefObject<any>;
    setRowData: Dispatch<SetStateAction<T[]>>;
    idKey: keyof T;
}

const ActionCellRenderer = <T,>({ params, setError, updateObject, deleteObject, rowData, gridRef, setRowData, idKey, onChanged }: ActionCellRendererProps<T>) => {
    const handleRowChanged = (updatedObj: T, fordelete: boolean) => {
        let updatedRowData: T[];
        if (fordelete) {
            updatedRowData = rowData.filter(row => row[idKey] !== updatedObj[idKey]);
        } else {
            const index = rowData.findIndex(row => row[idKey] === updatedObj[idKey]);
            if (index !== -1) {
                updatedRowData = [...rowData];
                updatedRowData[index] = updatedObj;
            } else {
                updatedRowData = [...rowData, updatedObj];
            }
        }

        setRowData(updatedRowData);
        if (gridRef.current) {
            gridRef.current.api.setRowData(updatedRowData);
        }
        onChanged(updatedObj, fordelete);
    };

    const handleSave = async () => {
        try {
            //console.log("Save row: ", params.data);
            setError("");
            const r = await updateObject(params.data);
            if ((r as any).errorMessage) {
                throw new Error((r as any).errorMessage);
            }
            handleRowChanged(r, false); // Pass the updated object
        } catch (error: any) {
            setError(error.message);
        }
    };

    const handleDelete = async () => {
        //console.log("Delete row: ", params.data);
        try {
            setError("");
            const r = await deleteObject(params.data);
            setError((r as any).errorMessage);
            if ((r as any).errorMessage) {
                throw new Error((r as any).errorMessage);
            }
            handleRowChanged(params.data, true); // Pass the original data with delete flag
        } catch (error: any) {
            setError(error.message);
        }
    };

    return (
        <div className="action-cell">
            <button onClick={handleSave} className="btn btn-success btn-sm">Save</button>
            <button onClick={handleDelete} className="btn btn-danger btn-sm">Delete</button>
        </div>
    );
};

export default ActionCellRenderer;
