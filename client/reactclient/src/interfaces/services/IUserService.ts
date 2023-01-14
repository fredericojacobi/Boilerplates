import IUser from '../models/IUser';
import IResponseMessage from '../models/IResponseMessage';
import IPagination from '../models/IPagination';

export default interface IUserService {
	getUser(id: string): Promise<IResponseMessage<IUser>>,
	getUsers(page?: number, limit?: number): Promise<IResponseMessage<IPagination<IUser>>>,
	getUserInfo(id?: string): Promise<IResponseMessage<IUser>>,
	postUser(data: IUser): Promise<IResponseMessage<IUser>>,
	putUser(id: string, data: IUser): Promise<IResponseMessage<IUser>>,
	deleteUser(id?: string): Promise<IResponseMessage<boolean>>
}