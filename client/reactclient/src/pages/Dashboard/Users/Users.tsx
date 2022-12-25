import React, {
	useEffect,
	useState
} from 'react';
import IUser from '../../../interfaces/models/IUser';
import {useUserService} from '../../../hooks/useUserService';
import {log} from '../../../functions/util';
import {Box} from '@mui/material';
import {
	DataGrid,
	GridColDef
} from '@mui/x-data-grid';

export default function Users(): JSX.Element {
	//region consts
	const [users, setUsers] = useState<Array<IUser>>();
	const userService = useUserService();
	//endregion

	//region hooks
	useEffect(() => {
		const getUsers = async () => {
			const data = await userService.getUsers();
			log(data.records[0].records);
			setUsers(data.records[0].records);
		};

		getUsers();
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
		{field: 'userName', headerName: 'Username', width: 180},
		{field: 'email', headerName: 'Email', width: 340},
		{field: 'createdAt', headerName: 'Created At', width: 165, align: 'center'},
		{field: 'modifiedAt', headerName: 'Modified At', width: 165, align: 'center'},
		{field: 'paidUntil', headerName: 'Paid Until', width: 165, align: 'center'},

	];
	//endregion

	return (
		<Box sx={{height: '100%'}}>
			<DataGrid
				rows={users ?? []}
				columns={columns}
				pageSize={10}
				rowsPerPageOptions={[10]}
				checkboxSelection
				disableSelectionOnClick
				experimentalFeatures={{newEditingApi: true}}
			/>
		</Box>
	);
}