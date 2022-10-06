import api from '../config/Api';
import IBoilerplate from '../interfaces/models/IBoilerplate';
import {AxiosError, AxiosResponse} from 'axios';
import IResponseMessage from '../interfaces/models/IResponseMessage';

function getBoilerplates(id?: number): IBoilerplate[] {
	api.Get<IBoilerplate>(`boilerplate/${id}`)
		.then((response: AxiosResponse<IResponseMessage<IBoilerplate>>) => {
			console.warn('then');
			return response;
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
	return [];
}

function postBoilerplates(data: IBoilerplate): IBoilerplate | boolean {
	api.Post('boilerplate/', data)
		.then((response: AxiosResponse<IResponseMessage<IBoilerplate>>) => {
			console.warn('then');
			return response.data.records;
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
	return false;
}

function putBoilerplates(id: number, data: IBoilerplate): boolean {
	api.Put(`boilerplate/${id}`, data)
		.then((response: AxiosResponse<IResponseMessage<IBoilerplate>>) => {
			console.warn('then');
			return response.data.records;
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
	return false;
}

function deleteBoilerplates(id?: number): boolean {
	api.Delete<boolean>(`boilerplate/${id}`)
		.then((response: AxiosResponse<IResponseMessage<boolean>>) => {
			console.warn('then');
			return !response.data.error;
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
	return false;
}

export {
	getBoilerplates,
	postBoilerplates,
	putBoilerplates,
	deleteBoilerplates
};
