import * as React from 'react';
import Typography from '@mui/material/Typography';
import {Link as LinkRouter} from 'react-router-dom';
import styles from './Link.module.scss';

interface ILinkProps extends React.ComponentProps<typeof Typography> {
	to: string,
	children: string,
}

export default function Link({to, children, ...props}: ILinkProps & React.ComponentProps<typeof Typography>) {
	return (
		<Typography
			textAlign={props.textAlign}
			color={props.color}
			component={LinkRouter}
			to={to}
			className={styles.content}
		>
			{children}
		</Typography>
	);
}