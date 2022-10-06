import * as React from 'react';
import Typography from '@mui/material/Typography';
import {Link as LinkRouter} from 'react-router-dom';

interface ILinkProps {
	to: string,
	children: string
}

export default function Link({to, children, ...props}: ILinkProps & React.ComponentProps<typeof Typography>) {
	return (
		<Typography
			textAlign="center"
			color="textPrimary"
			style={{textDecoration: 'none', boxShadow: 'none'}}
			component={LinkRouter}
			to={to}
		>
			{children}
		</Typography>
	);
}