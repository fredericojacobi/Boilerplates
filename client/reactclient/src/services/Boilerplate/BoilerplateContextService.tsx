import React from 'react';
import {BoilerplateServiceContext} from '../../contexts/BoilerplateServiceContext';
import * as BoilerplateService from './BoilerplateService';
import IBoilerplate from '../../interfaces/models/IBoilerplate';

export default function BoilerplateContextService({children}: any): JSX.Element {
	const boilerplateService = {
		getBoilerplates(): IBoilerplate[] {
			return BoilerplateService.getBoilerplates();
		}
	};

	return (
		<BoilerplateServiceContext.Provider value={boilerplateService}>
			{children}
		</BoilerplateServiceContext.Provider>
	);
}