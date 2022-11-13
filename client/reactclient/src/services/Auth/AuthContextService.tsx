import React from 'react';
import IUser from '../../interfaces/models/IUser';
import IResponseMessage from '../../interfaces/models/IResponseMessage';
import {AuthServiceContext} from '../../contexts/AuthServiceContext';
import {AuthService} from './AuthService';
import IAuthService from '../../interfaces/services/IAuthService';

export default function AuthContextService({children}: any): JSX.Element {
	const authService: IAuthService = {
		getCurrentUser(): IUser {
			return AuthService.getCurrentUser();
		},
		signOut(): boolean {
			return AuthService.signOut();
		},
		async signUp(data: IUser): Promise<IResponseMessage<IUser>> {
			return await AuthService.signUp(data);
		},
		async signIn(data: IUser): Promise<IResponseMessage<IUser>> {
			return await AuthService.signIn(data);
		},
		isLoggedIn(): boolean {
			return AuthService.isLoggedIn();
		}
	};

	return (
		<AuthServiceContext.Provider value={authService}>
			{children}
		</AuthServiceContext.Provider>
	);
}