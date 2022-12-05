import api from '../../config/Api';
import IUser from '../../interfaces/models/IUser';
import {AxiosResponse} from 'axios';
import IResponseMessage from '../../interfaces/models/IResponseMessage';
import IUserService from '../../interfaces/services/IUserService';
import {
	setErrorResponseObject,
	setErrorResponsePaginationObject
} from '../../functions/Request';
import {IPagination} from '../../interfaces/models/IPagination';
import {log} from '../../functions/util';

export const UserService: IUserService = {

	getUser: async (id: string): Promise<IResponseMessage<IUser>> => {
		return await api.Get<IUser>(`user/${id}`)
			.then((response: AxiosResponse<IResponseMessage<IUser>>) => {
				return response.data;
			})
			.catch((err: IResponseMessage<IUser>) => {
				return setErrorResponseObject(err);
			});
	},

	getUsers: async (page?: number, limit?: number): Promise<IResponseMessage<IPagination<IUser>>> => {
		return await api.Get<IPagination<IUser>>(`user?page=${page ?? 1}&limit=${limit ?? 10}`)
			.then((response: AxiosResponse<IResponseMessage<IPagination<IUser>>>) => {
				return response.data;
			})
			.catch((err: IResponseMessage<IPagination<IUser>>) => {
				return setErrorResponsePaginationObject(err);
			});
	},

	getUserInfo: async (id?: string): Promise<IResponseMessage<IUser>> => {
		return await api.Get<IUser>(`user/${id ?? ''}`)
			.then((response: AxiosResponse<IResponseMessage<IUser>>) => {
				return response.data;
			})
			.catch((err: IResponseMessage<IUser>) => {
				return setErrorResponseObject(err);
			});
	},

	postUser: async (data: IUser): Promise<IResponseMessage<IUser>> => {
		return await api.Post('user/', data)
			.then((response: AxiosResponse<IResponseMessage<IUser>>) => {
				return response.data;
			})
			.catch((err: IResponseMessage<IUser>) => {
				return setErrorResponseObject(err);
			});
	},

	putUser: async (id: string, data: IUser): Promise<IResponseMessage<IUser>> => {
		return await api.Put(`user/${id}`, data)
			.then((response: AxiosResponse<IResponseMessage<IUser>>) => {
				return response.data;
			})
			.catch((err: IResponseMessage<IUser>) => {
				return setErrorResponseObject(err);
			});
	},

	deleteUser: async (id?: string): Promise<IResponseMessage<boolean>> => {
		return await api.Delete<boolean>(`user/${id}`)
			.then((response: AxiosResponse<IResponseMessage<boolean>>) => {
				return response.data;
			})
			.catch((err: IResponseMessage<boolean>) => {
				return err;
			});
	}
};