import React from 'react';
import Header from './Header/Header';
import Footer from './Footer/Footer';
import {Container} from '@mui/material';
import styles from './Layout.module.scss';

interface ILayoutProps {
	page: JSX.Element;
}

export default function Layout(props: ILayoutProps): JSX.Element {
	return (
		<>
			<Header/>
			<Container maxWidth="xl" className={styles.mainContent}>
				{props.page}
			</Container>
			<Footer/>
		</>
	);
}