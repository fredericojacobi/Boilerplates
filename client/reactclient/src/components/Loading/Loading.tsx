import React from 'react';
import {
	Backdrop,
} from '@mui/material';
import Typography from '@mui/material/Typography';
import Box from '@mui/material/Box';

interface ILoadingProps extends IBaseLoadingProps {
	backdrop: boolean,
	children: JSX.Element
}

export default function Loading(props: ILoadingProps): JSX.Element {
	return (
		<>
			{props.backdrop
				? <BackdropLoading value={props.value} component={props.component} visible={props.visible} color={props.color}/>
				: <BaseLoading component={props.component} value={props.value} visible={props.visible} color={props.color}/>
			}
			{props.children}
		</>
	);
}

interface IBaseLoadingProps {
	component: JSX.Element,
	value: number,
	visible: boolean,
	color: string
}

function BackdropLoading(props: IBaseLoadingProps): JSX.Element {
	return (
		<Backdrop open={props.visible} sx={{zIndex: 1}}>
			<BaseLoading component={props.component} value={props.value} visible={props.visible} color={props.color}/>
		</Backdrop>);
}

function BaseLoading(props: IBaseLoadingProps): JSX.Element {
	return (
		props.visible ?
			<Box sx={{
				position: 'absolute',
				top: 0,
				left: 0,
				bottom: 0,
				right: 0,
				display: 'flex',
				alignItems: 'center',
				justifyContent: 'center',
				zIndex: 1
			}}>
				{props.component}
				<Box
					sx={{
						top: 0,
						left: 0,
						bottom: 0,
						right: 0,
						position: 'absolute',
						display: 'flex',
						alignItems: 'center',
						justifyContent: 'center',
					}}
				>
					<Typography
						variant="caption"
						component="div"
						color={props.color}
					>{`${Math.round(props.value)}%`}</Typography>
				</Box>
			</Box> :
			<></>
	);
}