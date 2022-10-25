import React from 'react';
import IUser from '../../interfaces/models/IUser';
import {UserServiceContext} from '../../contexts/UserServiceContext';
import {UserService} from './UserService';
import IResponseMessage from '../../interfaces/models/IResponseMessage';

export default function UserContextService({children}: any): JSX.Element {
	const userService = {
		async getUserInfo(): Promise<IResponseMessage<IUser>> {
			return await UserService.getUserInfo();
		},
	};
	return (
		<UserServiceContext.Provider value={userService}>
			{children}
		</UserServiceContext.Provider>
	);
}