import api from '../../config/Api';
import IUser from '../../interfaces/models/IUser';
import {
	AxiosResponse
} from 'axios';
import IResponseMessage from '../../interfaces/models/IResponseMessage';
import IAuthService from '../../interfaces/services/IAuthService';
import {setErrorResponseObject} from '../../functions/Request';
import {log} from '../../functions/util';

export const AuthService: IAuthService = {

	signIn: async (data: IUser): Promise<IResponseMessage<IUser>> => {
		return await api.Post<IUser>('user/signin', data)
			.then((response: AxiosResponse<IResponseMessage<IUser>>) => {
				if (response.data.records[0]?.token) {
					localStorage.setItem('user', JSON.stringify(response.data.records[0]));
				}
				return response.data;
			})
			.catch((err: IResponseMessage<IUser>) => {
				return setErrorResponseObject(err);
			});
	},

	signUp: async (data: IUser): Promise<IResponseMessage<IUser>> => {
		return await api.Post<IUser>('user/signup', data)
			.then((response: AxiosResponse<IResponseMessage<IUser>>) => {
				return response.data;
			})
			.catch((err: IResponseMessage<IUser>) => {
				return setErrorResponseObject(err);
			});
	},

	signOut: (): boolean => {
		localStorage.removeItem('user');
		return localStorage.getItem('user') === null;
	},

	getCurrentUser: (): IUser => {
		const userData = localStorage.getItem('user') ?? '';
		return JSON.parse('[{}]');
	},

	isLoggedIn: (): boolean => {
		return !!AuthService.getCurrentUser().token;
	}
};