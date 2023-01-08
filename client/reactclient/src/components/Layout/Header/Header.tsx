import React from 'react';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Container from '@mui/material/Container';
import AdbIcon from '@mui/icons-material/Adb';
import Link from '../../Link/Link';
import styles from './Header.module.scss';
import {Routes} from '../../../enums/Routes';
import {getPage} from '../../../routes/Pages';
import {log} from '../../../functions/util';

interface IHeaderProps {
	isLoggedIn: boolean
}

export default function Header(props: IHeaderProps): JSX.Element {

	return (
		<header>
			<AppBar position="static" className={styles.content}>
				<Container maxWidth="xl">
					<Toolbar disableGutters sx={{display: 'flex'}}>
						<Container sx={{display: 'flex'}}>
							<AdbIcon sx={{display: 'flex', mr: 1}}/>
						</Container>
						<Box sx={{flexGrow: 0}}>
							{props.isLoggedIn ? <Link route={Routes.Dashboard}>My Account</Link> : <Link route={Routes.SignIn}>{getPage(Routes.SignIn).label}</Link>}
						</Box>
					</Toolbar>
				</Container>
			</AppBar>
		</header>
	);
}
