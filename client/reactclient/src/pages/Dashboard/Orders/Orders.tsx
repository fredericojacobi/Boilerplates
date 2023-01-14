import { Box } from '@mui/material';
import {
  DataGrid,
  GridColDef
} from '@mui/x-data-grid';
import React, {
  useEffect,
  useState
} from 'react';
import { log } from '../../../functions/util';
import { useOrderService } from '../../../hooks/useOrderService';
import IOrder from '../../../interfaces/models/IFood/IOrder';

export default function Users(): JSX.Element {
  //region consts
  const [orders, setOrders] = useState<Array<IOrder>>();
  const orderService = useOrderService();
  //endregion

  //region hooks
  useEffect(() => {
    log('inside');
  }, []);
  //endregion

  //region table
  const columns: GridColDef[] = [
    {
      field: 'secondaryId',
      headerName: 'ID',
      type: 'number',
      width: 85,
      filterable: false,
      hideable: false,
    },
    { field: 'userName', headerName: 'Username', width: 180 },
    { field: 'email', headerName: 'Email', width: 340 },
    { field: 'createdAt', headerName: 'Created At', width: 165, align: 'center' },
    { field: 'modifiedAt', headerName: 'Modified At', width: 165, align: 'center' },
    { field: 'paidUntil', headerName: 'Paid Until', width: 165, align: 'center' },

  ];
  //endregion

  return (
    <Box sx={{ height: '100%' }}>
      <DataGrid
        rows={orders ?? []}
        columns={columns}
        pageSize={10}
        rowsPerPageOptions={[10]}
        checkboxSelection
        disableSelectionOnClick
        experimentalFeatures={{ newEditingApi: true }}
      />
    </Box>
  );
}