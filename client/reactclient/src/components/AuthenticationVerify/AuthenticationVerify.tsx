import React, {useEffect} from 'react';
import {
	Location,
	NavigateFunction,
	useLocation,
	useNavigate
} from 'react-router-dom';
import {useAuthService} from '../../hooks/useAuthService';
import {
	log,
} from '../../functions/util';
import {
	getPage,
	isPublicPage,
} from '../../routes/Pages';
import {Routes} from '../../enums/Routes';
import IAuthService from '../../interfaces/services/IAuthService';

interface IAuthenticationVerifyProps {
	children: JSX.Element[];
}

export default function AuthenticationVerify(props: IAuthenticationVerifyProps): JSX.Element {
	const location = useLocation();
	const authService = useAuthService();
	const navigate = useNavigate();

	useEffect(() => {
		handleAuthentication(navigate, authService, location);
	}, [location]);

	return <>{props.children}</>;
}

const handleAuthentication = (navigate: NavigateFunction, authService: IAuthService, location: Location) => {
	if(isPublicPage(location) || authService.isLoggedIn())
		return;
	else
		navigate(getPage(Routes.Home).path);
};