import { MutableRefObject, Dispatch, SetStateAction } from "react";

export function handleAddNew<T>(
    blankObject: T,
    additionalFields: Partial<T>,
    primaryKey: keyof T,
    parentKey: keyof T,
    parentKeyValue: any,
    rowData: T[],
    setRowData: Dispatch<SetStateAction<T[]>>,
    gridRef: MutableRefObject<any>
) {
    const negativeKeys = rowData.filter(row => (row[primaryKey] as unknown as number) < 0).length;
    const nextNegativeKey = -(negativeKeys + 1);

    const newRow = {
        ...blankObject,
        ...additionalFields,
        [primaryKey]: nextNegativeKey, // Use the next sequential negative key
        [parentKey]: parentKeyValue
    };
    const updatedRowData = [...rowData, newRow];
    setRowData(updatedRowData);
    if (gridRef.current) {
        gridRef.current.api.setRowData(updatedRowData);
    }
}
