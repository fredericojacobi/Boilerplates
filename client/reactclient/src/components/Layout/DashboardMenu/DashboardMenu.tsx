import React from 'react';
import {
	Divider,
	List,
	ListItem,
	ListItemButton,
	ListItemIcon,
	ListItemText,
	Paper
} from '@mui/material';
import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';
import styles from './DashboardMenu.module.scss';
import {
	Pages
} from '../../../routes/Pages';
import {randomAlphaNumericId} from '../../../functions/util';
import {useNavigate} from 'react-router-dom';

interface IDashboardMenu {
	visible: boolean;
}

export default function DashboardMenu(props: IDashboardMenu): JSX.Element {
	const navigate = useNavigate();

	const tabs = [Pages[0], Pages[5]];

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
					<List>
						{tabs.map((item) => {
							return (
								<ListItem
									key={randomAlphaNumericId(3)}
									component="div"
									onClick={() => navigate(item.path)}
									disablePadding
								>
									<ListItemButton sx={{height: 56}}>
										<ListItemIcon>
											{item.icon}
										</ListItemIcon>
										<ListItemText>
											{item.label}
										</ListItemText>
									</ListItemButton>
								</ListItem>
							);
						})}
					</List>
				</Paper>
			</Box>
			: <></>
	);
}