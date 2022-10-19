import React from 'react';
import styles from './Dashboard.module.scss';
import Box from '@mui/material/Box';

export default function Dashboard(): JSX.Element {
	return (
		<Box className={styles.content}>
			Dashboard page
		</Box>
	);
}