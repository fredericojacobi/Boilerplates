import api from '../config/Api';
import IUser from '../interfaces/models/IUser';
import {AxiosError, AxiosResponse} from 'axios';
import IResponseMessage from '../interfaces/models/IResponseMessage';

const getUser = async (id: string): Promise<IResponseMessage<IUser>> => {
	return await api.Get<IUser>(`user/${id}`)
		.then((response: AxiosResponse<IResponseMessage<IUser>>) => {
			return response.data;
		})
		.catch((err: AxiosError) => {
			return {
				records: [],
				count: 0,
				error: true,
				message: 'Error',
				status: 500
			};
		});
};

const getUserInfo = async (id?: string): Promise<IResponseMessage<IUser>> => {
	return await api.Get<IUser>(`user/1aac97bf-913b-4ba2-6a4b-08da7f06e0eb${id ?? ''}`)
		.then((response: AxiosResponse<IResponseMessage<IUser>>) => {
			return response.data;
		})
		.catch((err: AxiosError) => {
			return {
				records: [],
				count: 0,
				error: true,
				message: 'Error',
				status: 500
			};
		});
};

const postUser = async (data: IUser): Promise<IResponseMessage<IUser>> => {
	return await api.Post('user/', data)
		.then((response: AxiosResponse<IResponseMessage<IUser>>) => {
			return response.data;
		})
		.catch((err: AxiosError) => {
			return {
				records: [],
				count: 0,
				error: true,
				message: 'Error',
				status: 500
			};
		});
};

const putUser = async (id: string, data: IUser): Promise<IResponseMessage<IUser>> => {
	return await api.Put(`user/${id}`, data)
		.then((response: AxiosResponse<IResponseMessage<IUser>>) => {
			return response.data;
		})
		.catch((err: AxiosError) => {
			return {
				records: [],
				count: 0,
				error: true,
				message: 'Error',
				status: 500
			};
		});
};

const deleteUser = async (id?: string): Promise<IResponseMessage<boolean>> => {
	return await api.Delete<boolean>(`user/${id}`)
		.then((response: AxiosResponse<IResponseMessage<boolean>>) => {
			return response.data;
		})
		.catch((err: AxiosError) => {
			return {
				records: [],
				count: 0,
				error: true,
				message: 'Error',
				status: 500
			};
		});
};

export default {
	getUser,
	getUserInfo,
	postUser,
	putUser,
	deleteUser
};
