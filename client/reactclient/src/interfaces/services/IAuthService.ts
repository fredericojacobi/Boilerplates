import IUser from '../models/IUser';
import IResponseMessage from '../models/IResponseMessage';

export default interface IAuthService {
	signIn(username: string, password: string): Promise<IResponseMessage<IUser>>,
	signUp(username: string, password: string, email: string): Promise<IResponseMessage<IUser>>,
	signOut(): boolean,
	getCurrentUser(): IUser,
	isLoggedIn(): boolean
}