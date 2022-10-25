import api from '../../config/Api';
import IUser from '../../interfaces/models/IUser';
import {AxiosResponse} from 'axios';
import IResponseMessage from '../../interfaces/models/IResponseMessage';
import IUserService from '../../interfaces/services/IUserService';

export const UserService: IUserService = {

	getUser: async (id: string): Promise<IResponseMessage<IUser>> => {
		return await api.Get<IUser>(`user/${id}`)
			.then((response: AxiosResponse<IResponseMessage<IUser>>) => {
				return response.data;
			})
			.catch((err: IResponseMessage<IUser>) => {
				return err;
			});
	},

	getUserInfo: async (id?: string): Promise<IResponseMessage<IUser>> => {
		return await api.Get<IUser>(`user/1aac97bf-913b-4ba2-6a4b-08da7f06e0eb${id ?? ''}`)
			.then((response: AxiosResponse<IResponseMessage<IUser>>) => {
				return response.data;
			})
			.catch((err: IResponseMessage<IUser>) => {
				return err;
			});
	},

	postUser: async (data: IUser): Promise<IResponseMessage<IUser>> => {
		return await api.Post('user/', data)
			.then((response: AxiosResponse<IResponseMessage<IUser>>) => {
				return response.data;
			})
			.catch((err: IResponseMessage<IUser>) => {
				return err;
			});
	},

	putUser: async (id: string, data: IUser): Promise<IResponseMessage<IUser>> => {
		return await api.Put(`user/${id}`, data)
			.then((response: AxiosResponse<IResponseMessage<IUser>>) => {
				return response.data;
			})
			.catch((err: IResponseMessage<IUser>) => {
				return err;
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