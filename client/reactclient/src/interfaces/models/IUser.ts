import IModelBase from './IModelBase';

export default interface IUser extends IModelBase{
	userName?: string,
	email?: string,
	token?: string,
	password?: string
}