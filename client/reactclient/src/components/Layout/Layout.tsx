import React from 'react';
import Header from './Header/Header';
import Footer from './Footer/Footer';
import {Container} from '@mui/material';

interface ILayoutProps {
	page: JSX.Element;
}

export default function Layout(props: ILayoutProps): JSX.Element {
	return (
		<>
			<Header/>
			<Container>
				{props.page}
			</Container>
			<Footer/>
		</>
	);
}