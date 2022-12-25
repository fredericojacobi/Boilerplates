import api from '../../config/Api';
import IUser from '../../interfaces/models/IUser';
import {AxiosResponse} from 'axios';
import IResponseMessage from '../../interfaces/models/IResponseMessage';
import IAuthService from '../../interfaces/services/IAuthService';
import {setErrorResponseObject} from '../../functions/Request';
import {useNavigate} from 'react-router-dom';
import {getPage} from '../../routes/Pages';
import {Routes} from '../../enums/Routes';
import {log} from '../../functions/util';

export const AuthService: IAuthService = {

	//region userActions
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
	//endregion

	//region userInfos
	getCurrentUser: (): IUser => {
		const userData = localStorage.getItem('user') ?? '[]';
		return JSON.parse(userData);
	},

	isLoggedIn: (): boolean => {
		const user = AuthService.getCurrentUser();

		if (user.token !== undefined) {
			if (getTokenExpirationDate(user.token) * 1000 < Date.now()) {
				AuthService.signOut();
			}
		}
		return !!AuthService.getCurrentUser().token;
	}
	//endregion
};

//region functions
const parseJwt = (token: string) => {
	try {
		return JSON.parse(atob(token.split('.')[1]));
	}
	catch (e) {
		return null;
	}
};

export const getToken = ():string => {
	const userStorage = localStorage.getItem('user') ?? '';
	if (userStorage !== '') {
		const user: IUser = JSON.parse(userStorage);
		return user.token ?? '';
	}
	return '';
};

const getTokenExpirationDate = (token:string):number => parseJwt(token ?? '[]');
//endregion