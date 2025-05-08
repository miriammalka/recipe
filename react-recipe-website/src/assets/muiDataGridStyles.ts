import { SxProps } from '@mui/material/styles';
import { GridSortDirection } from '@mui/x-data-grid';
import { GridColDef } from '@mui/x-data-grid';

export const commonDataGridStyles: SxProps = {
  '& .MuiTablePagination-toolbar': {
    alignItems: 'center',
    minHeight: '48px',
  },
  '& .MuiTablePagination-selectLabel': {
    margin: 0,
  },
  '& .MuiTablePagination-displayedRows': {
    margin: 0,
  },
};

export const commonSortingOrder: GridSortDirection[] = ['asc', 'desc'];

export function withDefaultColumnStyles(columns: GridColDef[]): GridColDef[] {
  return columns.map(col => ({
    headerAlign: 'left',
    align: 'left',
    ...col
  })

  );
}
