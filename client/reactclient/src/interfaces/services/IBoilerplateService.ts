import IBoilerplate from '../models/IBoilerplate';

export default interface IBoilerplateService {
	getBoilerplates(): IBoilerplate[],
	postBoilerplates(): IBoilerplate | boolean,
	putBoilerplates(): boolean,
	deleteBoilerplates(): boolean
}