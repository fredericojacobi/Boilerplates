import IResponseMessage from '../interfaces/models/IResponseMessage';
import IUser from '../interfaces/models/IUser';
import axios from 'axios';

export const setErrorResponseObject = (err: IResponseMessage<IUser>): IResponseMessage<IUser> => {
	if (axios.isAxiosError(err) && err.code === 'ERR_NETWORK') {
		return {
			count: 0,
			error: true,
			message: 'Service unavailable',
			records: [],
			status: 503
		};
	}
	return err;
};