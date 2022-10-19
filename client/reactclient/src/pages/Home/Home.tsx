import React from 'react';
import styles from './Home.module.scss';
import Container from '@mui/material/Container';

export default function Home(): JSX.Element {

	return (
		<Container
			maxWidth="xl"
			className={styles.content}
		>
			<span>Home</span>
		</Container>
	);
}