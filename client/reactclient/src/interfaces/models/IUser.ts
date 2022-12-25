import IModelBase from './IModelBase';

export default interface IUser extends IModelBase {
	username?: string,
	email?: string,
	token?: string,
	password?: string
}