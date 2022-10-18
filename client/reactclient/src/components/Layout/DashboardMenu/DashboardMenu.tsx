import React from 'react';
import {ListItem, ListItemButton, ListItemIcon, Paper} from '@mui/material';
import {Home as HomeIcon} from '@mui/icons-material';
import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';

interface IDashboardMenu {
	visible: boolean;
}

export default function DashboardMenu(props: IDashboardMenu): JSX.Element {

	return (
		props.visible ?
			<Box>
				<Paper elevation={0} sx={{width: 200, height: '76vh', backgroundColor: 'lightblue', borderRadius: '0'}}>
					<ListItem component="div" disablePadding>
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