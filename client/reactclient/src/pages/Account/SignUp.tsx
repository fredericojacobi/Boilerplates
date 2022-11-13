import React, {
	useEffect,
	useState
} from 'react';
import {
	Button,
	CircularProgress,
	FormControl,
	Stack,
	TextField
} from '@mui/material';
import Typography from '@mui/material/Typography';
import Box from '@mui/material/Box';
import Link from '../../components/Link/Link';
import IUser from '../../interfaces/models/IUser';
import * as Yup from 'yup';
import {useForm} from 'react-hook-form';
import {yupResolver} from '@hookform/resolvers/yup';
import Loading from '../../components/Loading/Loading';
import {log} from '../../functions/util';
import IResponseMessage from '../../interfaces/models/IResponseMessage';
import {useAuthService} from '../../hooks/useAuthService';
import {Routes} from '../../enums/Routes';
import useUpdateEffect from '../../hooks/useUpdateEffect';

export default function SignUp(): JSX.Element {

	const authService = useAuthService();
	const [errorMessage, setErrorMessage] = useState<string>('');
	const [loading, setLoading] = useState<boolean>(false);
	const [loadingPercentage, setLoadingPercentage] = useState<number>(0);

	useEffect(() => {
		if (loading) {
			setTimeout(() => {
				setLoadingPercentage(loadingPercentage + 1);
			}, 1800);
		}
	}, [loadingPercentage]);

	const onSubmit = async (data: IUser) => {
		setLoading(true);
		await authService.signUp(data)
			.then((response: IResponseMessage<IUser>) => {
				if (response.error) {
					setErrorMessage(response.message);
				}
			});
		setLoading(false);
	};

	const validationSchema = Yup.object().shape({
		email: Yup.string()
			.required('Email invalid')
			.email('Email invalid'),
		username: Yup.string()
			.required('Username is required')
			.min(6, 'Username must be at least 6 characters'),
		password: Yup.string()
			.required('Password is required')
			.min(6, 'Password must be at least 6 characters')
	});

	const passwordErrorMessage = (): string => errors?.password?.message?.toString() ?? '';
	const usernameErrorMessage = (): string => errors?.username?.message?.toString() ?? '';
	const emailErrorMessage = (): string => errors?.email?.message?.toString() ?? '';

	const {
		register,
		control,
		handleSubmit,
		formState: {errors}
	} = useForm({
		resolver: yupResolver(validationSchema)
	});

	return (
		<Loading
			backdrop={true}
			component={<CircularProgress color="info"/>}
			value={loadingPercentage}
			visible={loading}
			color="white"
		>
			<Box sx={{
				position: 'relative',
				backgroundColor: 'white',
				height: '70vh',
				padding: '10px'
			}}
			>
				<Stack
					direction="column"
					justifyContent="center"
					alignItems="center"
					height="64vh"
					spacing={5}
				>
					<Stack
						direction="column"
						padding="10px"
					>
						<Typography>Sign Up</Typography>
					</Stack>
					<Stack
						direction="column"
						justifyContent="center"
						alignItems="center"
					>
						<Box
							sx={{
								display: errorMessage ? 'flex' : 'flex',
								padding: '10px'
							}}
						>
							<Typography
								sx={{
									display: errorMessage ? 'flex' : 'flex',
									padding: '10px',
									color: 'red'
								}}
							>
								{errorMessage}
							</Typography>
						</Box>
						<Box>
							<FormControl
								component="form"
								variant="filled"
								sx={{width: '400px'}}
							>
								<TextField
									required
									id="email"
									label="Email"
									type="email"
									sx={{marginBottom: '5px'}}
									{...register('email')}
									error={!!errors.email}
									helperText={emailErrorMessage()}
								/>
								<TextField
									required
									id="username"
									label="Username"
									sx={{marginBottom: '5px'}}
									{...register('username')}
									error={!!errors.username}
									helperText={usernameErrorMessage()}
								/>
								<TextField
									required
									id="password"
									label="Password"
									type="password"
									{...register('password')}
									error={!!errors.password}
									helperText={passwordErrorMessage()}
								/>
								<Button
									onClick={handleSubmit(onSubmit)}
									sx={{marginTop: '10px'}}
								>
									Sign Up
								</Button>
								<Typography fontSize={14}>
									Already registered? <Link route={Routes.SignIn}>Click here</Link> to sign in.
								</Typography>
							</FormControl>
						</Box>
					</Stack>
				</Stack>
			</Box>
		</Loading>
	);
}