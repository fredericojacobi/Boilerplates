import React from 'react';
import {
	Divider,
	ListItem,
	ListItemButton,
	ListItemIcon,
	Paper
} from '@mui/material';
import {Home as HomeIcon} from '@mui/icons-material';
import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';
import styles from './DashboardMenu.module.scss';

interface IDashboardMenu {
	visible: boolean;
}

export default function DashboardMenu(props: IDashboardMenu): JSX.Element {

	return (
		props.visible ?
			<Box>
				<Paper
					elevation={0}
					sx={{
						width: 200,
						height: '76vh',
						backgroundColor: 'lightblue',
						borderRadius: '0'
					}}
				>
					<Box className={styles.content}>
						<Typography style={{padding: '25px'}}>Content</Typography>
					</Box>
					<Divider/>
					<ListItem
						component="div"
						disablePadding
					>
						<ListItemButton sx={{height: 56}}>
							<ListItemIcon>
								<HomeIcon color="primary"/>
								<Typography>Home</Typography>
							</ListItemIcon>
						</ListItemButton>
					</ListItem>
				</Paper>
			</Box>
			: <></>
	);
}