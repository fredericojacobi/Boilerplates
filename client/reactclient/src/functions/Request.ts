import IResponseMessage from '../interfaces/models/IResponseMessage';
import IUser from '../interfaces/models/IUser';
import axios, {AxiosError} from 'axios';
import {log} from './util';
import {parseResponseMessage} from './ResponseMessage';
import IPagination from '../interfaces/models/IPagination';

export const setErrorResponseObject = <T>(err: IResponseMessage<T>): IResponseMessage<T> => {
	if (axios.isAxiosError(err)) {
		if (err.code === 'ERR_NETWORK') {
			return {
				count: 0,
				error: true,
				message: 'Woops! Something went wrong',
				records: [],
				status: 503
			};
		} else if (Number(err.response?.status)) {
			return parseResponseMessage(err.request.response);
		}
	}
	return err;
};

export const setErrorResponsePaginationObject = <T>(err: IResponseMessage<IPagination<T>>): IResponseMessage<IPagination<T>> => {
	if (axios.isAxiosError(err)) {
		if (err.code === 'ERR_NETWORK') {
			return {
				count: 0,
				error: true,
				message: 'Woops! Something went wrong',
				records: [],
				status: 503
			};
		} else if (Number(err.response?.status)) {
			return parseResponseMessage(err.request.response);
		}
	}
	return err;
};