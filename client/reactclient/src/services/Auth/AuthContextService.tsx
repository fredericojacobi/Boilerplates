import React from 'react';
import IUser from '../../interfaces/models/IUser';
import IResponseMessage from '../../interfaces/models/IResponseMessage';
import {AuthServiceContext} from '../../contexts/AuthServiceContext';
import {AuthService} from './AuthService';
import IAuthService from '../../interfaces/services/IAuthService';
import {useAuthService} from '../../hooks/useAuthService';

export default function AuthContextService({children}: any): JSX.Element {
	const authService: IAuthService = {
		getCurrentUser(): IUser {
			return AuthService.getCurrentUser();
		},
		signOut(): boolean {
			return AuthService.signOut();
		},
		async signUp(username: string, password: string, email: string): Promise<IResponseMessage<IUser>> {
			return await AuthService.signUp(username, password, email);
		},
		async signIn(username: string, password: string): Promise<IResponseMessage<IUser>> {
			return await AuthService.signIn(username, password);
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