import React from 'react';
import BoilerplateContextService from './BoilerplateContextService';
import UserContextService from './UserContextService';

export default function GlobalServices({children}: any): JSX.Element {
	return (
		<UserContextService>
			<BoilerplateContextService>
				{children}
			</BoilerplateContextService>
		</UserContextService>
	);
}