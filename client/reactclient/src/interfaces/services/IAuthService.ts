import IUser from '../models/IUser';
import IResponseMessage from '../models/IResponseMessage';

export default interface IAuthService {
	signIn(data: IUser): Promise<IResponseMessage<IUser>>,
	signUp(data: IUser): Promise<IResponseMessage<IUser>>,
	signOut(): boolean,
	getCurrentUser(): IUser,
	isLoggedIn(): boolean
}