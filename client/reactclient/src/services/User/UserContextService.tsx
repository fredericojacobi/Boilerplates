import React from 'react';
import IUser from '../../interfaces/models/IUser';
import {UserServiceContext} from '../../contexts/UserServiceContext';
import {UserService} from './UserService';
import IResponseMessage from '../../interfaces/models/IResponseMessage';
import IUserService from '../../interfaces/services/IUserService';
import {IPagination} from '../../interfaces/models/IPagination';

export default function UserContextService({children}: any): JSX.Element {
	const userService: IUserService = {
		//region GET
		async getUser(id: string): Promise<IResponseMessage<IUser>> {
			return await UserService.getUser(id);
		},
		async getUsers(page?: number, limit?: number): Promise<IResponseMessage<IPagination<IUser>>> {
			return await UserService.getUsers(page, limit);
		},
		async getUserInfo(): Promise<IResponseMessage<IUser>> {
			return await UserService.getUserInfo();
		},
		//endregion

		//region POST
		async postUser(data: IUser): Promise<IResponseMessage<IUser>> {
			return await UserService.postUser(data);
		},
		//endregion

		//region PUT
		async putUser(id: string, data: IUser): Promise<IResponseMessage<IUser>> {
			return await UserService.putUser(id, data);
		},
		//endregion

		//region DELETE
		async deleteUser(id?: string): Promise<IResponseMessage<boolean>> {
			return await UserService.deleteUser(id);
		},
		//endregion
	};
	return (
		<UserServiceContext.Provider value={userService}>
			{children}
		</UserServiceContext.Provider>
	);
}