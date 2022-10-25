import React from 'react';
import UserContextService from './User/UserContextService';
import AuthContextService from './Auth/AuthContextService';

export default function GlobalServices({children}: any): JSX.Element {
	return (
		<AuthContextService>
			<UserContextService>
				{children}
			</UserContextService>
		</AuthContextService>
	);
}