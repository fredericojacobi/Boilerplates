import React, {
	useEffect,
	useState
} from 'react';
import IUser from '../../../interfaces/models/IUser';
import {useUserService} from '../../../hooks/useUserService';
import {
	Box,
	CircularProgress
} from '@mui/material';
import {
	DataGrid,
	GridColDef
} from '@mui/x-data-grid';
import {log} from '../../../functions/util';
import Loading from '../../../components/Loading/Loading';
import useUpdateEffect from '../../../hooks/useUpdateEffect';

export default function Users(): JSX.Element {
	//region consts
	const [users, setUsers] = useState<Array<IUser>>();
	const userService = useUserService();
	const [loading, setLoading] = useState<boolean>(false);
	const [loadingPercentage, setLoadingPercentage] = useState<number>(0);
	//endregion

	//region hooks
	useEffect(() => {
		setLoading(true);
		setLoadingPercentage(1);
		const getUsers = async () => {
			const data = await userService.getUsers();
			setUsers(data?.records[0]?.records);
		};

		setTimeout(() => {
			getUsers();
			setLoading(false);
		}, 1290);

	}, []);

	useUpdateEffect(() => {
		if (loading && loadingPercentage < 100) {
			setTimeout(() => {
				setLoadingPercentage(loadingPercentage + 1);
			}, 95);
		}
	}, [loadingPercentage]);
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
		<Loading
			color="black"
			value={loadingPercentage}
			backdrop={false}
			component={<CircularProgress color="info"/>}
			visible={loading}
		>
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
		</Loading>
	);
}