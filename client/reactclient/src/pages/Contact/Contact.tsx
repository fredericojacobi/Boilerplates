import React from 'react';
import styles from './Contact.module.scss';
import Container from '@mui/material/Container';

export default function Contact(): JSX.Element {

	return (
		<Container
			maxWidth="xl"
			className={styles.content}
		>
			<span>Contact</span>
		</Container>
	);
}