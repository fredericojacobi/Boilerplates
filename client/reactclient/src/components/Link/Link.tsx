import * as React from 'react';
import Typography from '@mui/material/Typography';
import {Link as LinkRouter} from 'react-router-dom';
import styles from './Link.module.scss';
import {Routes} from '../../enums/Routes';
import {getPage} from '../../routes/Pages';

interface ILinkProps extends React.ComponentProps<typeof Typography> {
	route: Routes,
	children: string,
}

export default function Link({route, children, ...props}: ILinkProps & React.ComponentProps<typeof Typography>) {
	return (
		<Typography
			textAlign={props.textAlign}
			color={props.color}
			component={LinkRouter}
			to={getPage(route).path}
			className={styles.content}
		>
			{children}
		</Typography>
	);
}