import React from 'react';
import UserContextService from './User/UserContextService';
import AuthContextService from './Auth/AuthContextService';
import OrderContextService from './Order/OrderContextService';

export default function GlobalServices({children}: any): JSX.Element {
	return (
		<AuthContextService>
			<UserContextService>
        <OrderContextService>
				  {children}
        </OrderContextService>
			</UserContextService>
		</AuthContextService>
	);
}