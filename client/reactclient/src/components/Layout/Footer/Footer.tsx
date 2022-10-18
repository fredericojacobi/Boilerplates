import React from 'react';
import Container from '@mui/material/Container';
import styles from './Footer.module.scss';

export default function Footer(): JSX.Element {
	return (
		<footer className={styles.footer}>
			<Container maxWidth="xl">
				Footer
			</Container>
		</footer>
	);
}