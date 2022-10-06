import IUser from '../models/IUser';
import IResponseMessage from '../models/IResponseMessage';

export default interface IUserContextService {
	getUserInfo(id?: string): Promise<IResponseMessage<IUser>>;
}