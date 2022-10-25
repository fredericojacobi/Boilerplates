import React, {
	ChangeEvent,
	useEffect,
	useRef,
	useState
} from 'react';
import {
	Button,
	FormControl,
	Stack,
	TextField
} from '@mui/material';
import Typography from '@mui/material/Typography';
import Box from '@mui/material/Box';
import Link from '../../components/Link/Link';
import IUser from '../../interfaces/models/IUser';

export default function SignUp(): JSX.Element {
	const userRef = useRef<IUser>({});
	const errorRef = useRef();

	const [username, setUsername] = useState<string>('');
	const [password, setPassword] = useState<string>('');
	const [errorMessage, setErrorMessage] = useState<string>('');
	const [success, setSuccess] = useState<boolean>(false);

	useEffect(() => {
		// userRef.current.focus();
	}, []);

	useEffect(() => {
		setErrorMessage('');

	}, [username, password]);

	const handleChangeUsername = (e: ChangeEvent<HTMLTextAreaElement | HTMLInputElement>) => {
		setUsername(e.target.value);
	};

	const handleChangePassword = (e: ChangeEvent<HTMLTextAreaElement | HTMLInputElement>) => {
		setPassword(e.target.value);
	};

	const handleSubmit = async (e: React.MouseEvent<HTMLButtonElement, MouseEvent>) => {
		e.preventDefault();
		console.log(username, password);
		setUsername('');
		setPassword('');
		setSuccess(true);
	};

	return (
		<Box sx={{position: 'relative', backgroundColor: 'white', height: '70vh', padding: '10px'}}>
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
					<Box ref={errorRef} sx={{display: errorMessage ? 'flex' : 'flex', padding: '10px'}}>
						<Typography>
							{/*{errorMessage}*/}
							errorMsg
						</Typography>
					</Box>
					<Box>
						<FormControl
							component="form"
							variant="filled"
							sx={{width: '400px'}}
						>
							<TextField
								id="username"
								label="Username"
								onChange={handleChangeUsername}
								value={username}
								helperText="Invalid field."
								sx={{marginBottom: '5px'}}
							/>
							<TextField
								error
								id="password"
								label="Password"
								type="password"
								onChange={handleChangePassword}
								value={password}
								helperText="Invalid field."
							/>
							<Button onClick={handleSubmit} sx={{marginTop: '10px'}}>Sign Up</Button>
							<Typography fontSize={14}>
								Already registered? <Link to="/user/signin">Click here</Link> to sign in.
							</Typography>
						</FormControl>
					</Box>
				</Stack>
			</Stack>
		</Box>
	);
}