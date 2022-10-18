import React from 'react';
import styles from './Dashboard.module.scss';
import Container from '@mui/material/Container';

export default function Dashboard(): JSX.Element {
	return (
		<Container className={styles.content}>
			Dashboard page
		</Container>
	);
}