import React, {useEffect} from 'react';
import {
	useLocation,
	useNavigate
} from 'react-router-dom';
import {useAuthService} from '../../hooks/useAuthService';
import {parseJwt} from '../../functions/util';
import {getPage} from '../../routes/Pages';
import {Routes} from '../../enums/Routes';

interface IAuthenticationVerifyProps {
	children: JSX.Element[];
}

export default function AuthenticationVerify(props: IAuthenticationVerifyProps): JSX.Element {

	const location = useLocation();
	const authService = useAuthService();
	const navigate = useNavigate();

	useEffect(() => {
		const user = authService.getCurrentUser();

		if (user.token !== undefined) {
			const decodedJwt = parseJwt(user.token);

			if (decodedJwt.exp * 1000 < Date.now()) {
				authService.signOut();
				navigate(getPage(Routes.Home).path);
			}
		} else {
			authService.signOut();
			navigate(getPage(Routes.Home).path);
		}
	}, [location]);

	return <>{props.children}</>;

}