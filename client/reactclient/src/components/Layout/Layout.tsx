import React, {
	useEffect,
	useState
} from 'react';
import Header from './Header/Header';
import Footer from './Footer/Footer';
import styles from './Layout.module.scss';
import Box from '@mui/material/Box';
import DashboardMenu from './DashboardMenu/DashboardMenu';
import AuthenticationVerify from '../AuthenticationVerify/AuthenticationVerify';
import {log} from '../../functions/util';
import {useAuthService} from '../../hooks/useAuthService';
import {useLocation} from 'react-router-dom';

interface ILayoutProps {
	page: JSX.Element;
	dashboard?: boolean;
}

export default function Layout(props: ILayoutProps): JSX.Element {
	//region consts
	const location = useLocation();
	const authService = useAuthService();
	const [isLoggedIn, setIsLoggedIn] = useState<boolean>(false);
	//endregion

	//region hooks
	useEffect(() => {
		setIsLoggedIn(authService.isLoggedIn());
	}, [location]);
	//endregion

	return (
		<AuthenticationVerify>
			<Header
				isLoggedIn={isLoggedIn}
			/>
			<Box
				sx={{
					display: 'flex',
					height: '76vh'
				}}>
				<DashboardMenu
					visible={props.dashboard ?? false}
				/>
				<Box
					className={styles.mainContent}
				>
					{props.page}
				</Box>
			</Box>
			<Footer/>
		</AuthenticationVerify>
	);
}