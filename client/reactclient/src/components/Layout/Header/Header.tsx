import React, {
	useEffect,
	useState
} from 'react';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Container from '@mui/material/Container';
import AdbIcon from '@mui/icons-material/Adb';
import Link from '../../Link/Link';
import styles from './Header.module.scss';
import {Routes} from '../../../enums/Routes';
import {useAuthService} from '../../../hooks/useAuthService';
import {getPage} from '../../../routes/Pages';

export default function Header(): JSX.Element {

	const authService = useAuthService();
	const [isLoggedIn, setIsLoggedIn] = useState<boolean>(false);

	useEffect(() => {
		setIsLoggedIn(authService.isLoggedIn());
	}, []);

	return (
		<header>
			<AppBar position="static" className={styles.content}>
				<Container maxWidth="xl">
					<Toolbar disableGutters sx={{display: 'flex'}}>
						<Container sx={{display: 'flex'}}>
							<AdbIcon sx={{display: 'flex', mr: 1}}/>
						</Container>
						<Box sx={{flexGrow: 0}}>
							{isLoggedIn ? <Link route={Routes.Dashboard}>My Account</Link> : <Link route={Routes.SignIn}>{getPage(Routes.SignIn).label}</Link>}
						</Box>
					</Toolbar>
				</Container>
			</AppBar>
		</header>
	);
}
