import React, {
	useEffect,
	useState
} from 'react';
import Box from '@mui/material/Box';
import IUser from '../../interfaces/models/IUser';
import Typography from '@mui/material/Typography';
import {
	Button,
	CircularProgress,
	FormControl,
	Stack,
	TextField
} from '@mui/material';
import Link from '../../components/Link/Link';
import {useAuthService} from '../../hooks/useAuthService';
import Loading from '../../components/Loading/Loading';
import IResponseMessage from '../../interfaces/models/IResponseMessage';
import * as Yup from 'yup';
import {useForm} from 'react-hook-form';
import {yupResolver} from '@hookform/resolvers/yup';
import {Routes} from '../../enums/Routes';
import useUpdateEffect from '../../hooks/useUpdateEffect';
import {useNavigate} from 'react-router-dom';
import {getPage} from '../../routes/Pages';
import {log} from '../../functions/util';

export default function SignIn(): JSX.Element {
	//region consts
	const authService = useAuthService();
	const navigate = useNavigate();

	const [errorMessage, setErrorMessage] = useState<string>('');
	const [loading, setLoading] = useState<boolean>(false);
	const [loadingPercentage, setLoadingPercentage] = useState<number>(0);
	//endregion

	//region hooks
	useEffect(() => {
		if (authService.isLoggedIn()) {
			navigate(`${getPage(Routes.Dashboard).path}`);
		}
	}, []);

	useUpdateEffect(() => {
		if (loading && loadingPercentage < 100) {
			setTimeout(() => {
				setLoadingPercentage(loadingPercentage + 1);
			}, 95);
		}
	}, [loadingPercentage]);
	//endregion

	//region onFunctions
	const onSubmit = async (data: IUser) => {
		setLoadingPercentage(1);
		setLoading(true);
		setTimeout(async () => {
			setTimeout(async () => {
				setTimeout(async () => {
					await authService.signIn(data)
						.then((response: IResponseMessage<IUser>) => {
							response.error
								? setErrorMessage(response.message)
								: navigate(getPage(Routes.Dashboard).path);
							setLoading(false);
						});
				}, 600);
			}, 1000);
		}, 400);
	};
	//endregion

	//region validations
	const validationSchema = Yup.object().shape({
		username: Yup.string()
			.required('Username is required')
			.min(6, 'Username must be at least 6 characters'),
		password: Yup.string()
			.required('Password is required')
			.min(6, 'Password must be at least 6 characters')
	});

	const passwordErrorMessage = (): string => errors?.password?.message?.toString() ?? '';
	const usernameErrorMessage = (): string => errors?.username?.message?.toString() ?? '';

	const {
		register,
		control,
		handleSubmit,
		formState: {errors}
	} = useForm({
		resolver: yupResolver(validationSchema)
	});
	//endregion

	return (
		<Loading
			color="white"
			value={loadingPercentage}
			backdrop={true}
			component={<CircularProgress color="info"/>}
			visible={loading}
		>
			<Box
				sx={{
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
						<Typography>Welcome back!</Typography>
					</Stack>
					<Stack
						direction="column"
						justifyContent="center"
						alignItems="center"
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
						<Box>
							<FormControl
								component="form"
								variant="filled"
								sx={{width: '400px'}}
							>
								<TextField
									required
									id="username"
									label="Username"
									sx={{marginBottom: '20px'}}
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
									Sign In
								</Button>
								<Typography fontSize={14}>
									Not registered? <Link route={Routes.SignUp}>Click here</Link> to create your account.
								</Typography>
							</FormControl>
						</Box>
					</Stack>
				</Stack>
			</Box>
		</Loading>
	);
}