import * as React from 'react';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import IconButton from '@mui/material/IconButton';
import Menu from '@mui/material/Menu';
import Container from '@mui/material/Container';
import Avatar from '@mui/material/Avatar';
import Tooltip from '@mui/material/Tooltip';
import MenuItem from '@mui/material/MenuItem';
import AdbIcon from '@mui/icons-material/Adb';
import Link from '../../Link/Link';
import styles from './Header.module.scss';
import {Routes} from '../../../enums/Routes';

const settings = ['Settings 1', 'Settings 2', 'Settings 3'];

export default function Header(): JSX.Element {
	const [anchorElUser, setAnchorElUser] = React.useState<null | HTMLElement>(null);

	const handleOpenUserMenu = (event: React.MouseEvent<HTMLElement>) => {
		setAnchorElUser(event.currentTarget);
	};

	const handleCloseUserMenu = () => {
		setAnchorElUser(null);
	};

	return (
		<header>
			<AppBar position="static" className={styles.content}>
				<Container maxWidth="xl">
					<Toolbar disableGutters sx={{display: 'flex'}}>
						<Container sx={{display: 'flex'}}>
							<AdbIcon sx={{display: 'flex',mr: 1}}/>
						</Container>
						<Box sx={{flexGrow: 0}}>
							<Tooltip title="Open settings">
								<IconButton onClick={handleOpenUserMenu} sx={{p: 0}}>
									<Avatar src="/static/images/avatar/2.jpg"/>
								</IconButton>
							</Tooltip>
							<Menu
								sx={{mt: '45px'}}
								id="menu-appbar"
								anchorEl={anchorElUser}
								anchorOrigin={{
									vertical: 'top',
									horizontal: 'right',
								}}
								keepMounted
								transformOrigin={{
									vertical: 'top',
									horizontal: 'right',
								}}
								open={Boolean(anchorElUser)}
								onClose={handleCloseUserMenu}
							>
								{settings.map((setting) => (
									<MenuItem key={setting} onClick={handleCloseUserMenu}>
										<Link route={Routes.Home}>
											{setting}
										</Link>
									</MenuItem>
								))}
							</Menu>
						</Box>
					</Toolbar>
				</Container>
			</AppBar>
		</header>
	);
}
