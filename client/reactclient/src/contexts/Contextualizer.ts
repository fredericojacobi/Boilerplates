import React, {useContext} from 'react';
import {ProvidedServices} from '../enums/ProvidedServices';

const contexts = new Map<ProvidedServices, React.Context<any | undefined>>();

export const Contextualizer = {
	createContext: <T>(service: ProvidedServices): React.Context<T | undefined> => {
		const context = React.createContext<T | undefined>(undefined);
		contexts.set(service, context);
		return context;
	},

	use: <T>(services: ProvidedServices): T => {
		const context = contexts.get(services);
		if(context === undefined) {
			throw new Error(`${ProvidedServices[services]} wasn't created`);
		}
		const service = useContext(context);

		if(service === undefined){
			throw new Error(`You must use ${ProvidedServices[services]} from within it's service`);
		}
		return service;
	},

	clear(){
		contexts.clear();
	},
};