import React from 'react';
import IUser from '../../interfaces/models/IUser';
import IResponseMessage from '../../interfaces/models/IResponseMessage';
import {AuthServiceContext} from '../../contexts/AuthServiceContext';
import {AuthService} from './AuthService';
import IAuthService from '../../interfaces/services/IAuthService';

export default function AuthContextService({children}: any): JSX.Element {
	const authService: IAuthService = {

		//region userActions
		async signIn(data: IUser): Promise<IResponseMessage<IUser>> {
			return await AuthService.signIn(data);
		},
		async signUp(data: IUser): Promise<IResponseMessage<IUser>> {
			return await AuthService.signUp(data);
		},
		signOut(): boolean {
			return AuthService.signOut();
		},
		//endregion

		//region userInfos
		getCurrentUser(): IUser {
			return AuthService.getCurrentUser();
		},
		isLoggedIn(): boolean {
			return AuthService.isLoggedIn();
		}
		//endregion
	};

	return (
		<AuthServiceContext.Provider value={authService}>
			{children}
		</AuthServiceContext.Provider>
	);
}