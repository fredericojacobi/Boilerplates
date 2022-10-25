import React from 'react';
import Header from './Header/Header';
import Footer from './Footer/Footer';
import styles from './Layout.module.scss';
import Box from '@mui/material/Box';
import DashboardMenu from './DashboardMenu/DashboardMenu';

interface ILayoutProps {
	page: JSX.Element;
	dashboard?: boolean;
}

export default function Layout(props: ILayoutProps): JSX.Element {
	return (
		<>
			<Header/>
			<Box sx={{display: 'flex', height: '76vh'}}>
				<DashboardMenu visible={props.dashboard ?? false}/>
				<Box
					className={styles.mainContent}
				>
					{props.page}
				</Box>
			</Box>
			<Footer/>
		</>
	);
}