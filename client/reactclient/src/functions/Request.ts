import IResponseMessage from '../interfaces/models/IResponseMessage';
import IUser from '../interfaces/models/IUser';
import axios, {AxiosError} from 'axios';
import {log} from './util';
import {parseResponseMessage} from './ResponseMessage';
import {IPagination} from '../interfaces/models/IPagination';

export const setErrorResponseObject = (err: IResponseMessage<IUser>): IResponseMessage<IUser> => {
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

export const setErrorResponsePaginationObject = (err: IResponseMessage<IPagination<IUser>>): IResponseMessage<IPagination<IUser>> => {
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