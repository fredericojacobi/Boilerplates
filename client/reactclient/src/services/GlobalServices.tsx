import React from 'react';
import BoilerplateContextService from './Boilerplate/BoilerplateContextService';
import UserContextService from './User/UserContextService';

export default function GlobalServices({children}: any): JSX.Element {
	return (
		<UserContextService>
			<BoilerplateContextService>
				{children}
			</BoilerplateContextService>
		</UserContextService>
	);
}