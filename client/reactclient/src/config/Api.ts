import Axios, {
	AxiosInstance,
	AxiosResponse
} from 'axios';
import IResponseMessage from '../interfaces/models/IResponseMessage';
import IUser from '../interfaces/models/IUser';
import {log} from '../functions/util';
import {getToken} from '../services/Auth/AuthService';

//region axios instance config
const api: AxiosInstance = Axios.create({
	baseURL: 'https://localhost:7048/api/',
	headers: {
		'Content-Type': 'application/json',
		'Authorization': `Bearer ${getToken()}`,
	},
});
//endregion

//region http methods
function Get<T>(url: string): Promise<AxiosResponse<IResponseMessage<T>>> {
	return api.get(url);
}

function Post<T>(url: string, data: T): Promise<AxiosResponse<IResponseMessage<T>>> {
	return api.post(url, data);
}

function Put<T>(url: string, data: T): Promise<AxiosResponse<IResponseMessage<T>>> {
	return api.put(url, data);
}

function Delete<T>(url: string): Promise<AxiosResponse<IResponseMessage<T>>> {
	return api.delete(url);
}
//endregion

export default {
	Get,
	Post,
	Put,
	Delete,
};