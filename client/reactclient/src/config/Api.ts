import Axios, {
	AxiosError,
	AxiosInstance,
	AxiosResponse
} from 'axios';
import IResponseMessage from '../interfaces/models/IResponseMessage';
import {getToken} from '../services/Auth/AuthService';
import {log} from '../functions/util';

//region Axios config
const api: AxiosInstance = Axios.create({
	baseURL: 'https://localhost:7048/api/',
	headers: {
		'Content-Type': 'application/json',
		'Authorization': `Bearer ${getToken()}`,
	},
});

api.interceptors.response.use((response: AxiosResponse) => {
	return response;
}, (error: AxiosError) => {
	if (error === undefined || error.response?.data === undefined)
		return {};
	if (error.code === '401')
		localStorage.removeItem('user');
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