import React from 'react';
import {useEffect, useState} from 'react';
import {useUserService} from '../../hooks/useUserService';
import IUser from '../../interfaces/models/IUser';

interface IHomeProps {
	id?: number;
}

export default function Home(props: IHomeProps): JSX.Element {
	const userService = useUserService();
	const [user, setUser] = useState<IUser>();

	useEffect(() => {
		userService.getUserInfo()
			.then((response) => {
				setUser(response.records[0]);
			});
	}, []);

	return (
		<>
			<h4>Username: {user?.id}</h4>
			<span>Home</span>
		</>
	);
}