import React from 'react';
import Layout from '../components/Layout/Layout';
import Home from '../pages/Home/Home';
import SignIn from '../pages/Account/SignIn';
import SignUp from '../pages/Account/SignUp';
import Contact from '../pages/Contact/Contact';
import Dashboard from '../pages/Dashboard/Dashboard';
import {Routes} from '../enums/Routes';
import HomeIcon from '@mui/icons-material/Home';
import DashboardIcon from '@mui/icons-material/Dashboard';
import GroupIcon from '@mui/icons-material/Group';
import Users from '../pages/Dashboard/Users/Users';

interface IPages {
	type: Routes,
	label: string,
	path: string,
	icon?: JSX.Element,
	element: JSX.Element
}

export const Pages: Array<IPages> = [
	{
		type: Routes.Home,
		label: 'Home',
		path: '/',
		icon: <HomeIcon/>,
		element: <Layout page={<Home/>}/>
	},
	{
		type: Routes.SignIn,
		label: 'SignIn',
		path: '/account/signin',
		element: <Layout page={<SignIn/>}/>
	},
	{
		type: Routes.SignUp,
		label: 'SignUp',
		path: '/account/signup',
		element: <Layout page={<SignUp/>}/>
	},
	{
		type: Routes.Contact,
		label: 'Contact',
		path: '/contact',
		element: <Layout page={<Contact/>}/>
	},
	{
		type: Routes.Dashboard,
		label: 'Dashboard',
		path: '/dashboard',
		icon: <DashboardIcon/>,
		element: <Layout dashboard={true} page={<Dashboard/>}/>
	},
	{
		type: Routes.Dashboard,
		label: 'Users',
		path: '/dashboard/users',
		icon: <GroupIcon/>,
		element: <Layout dashboard={true} page={<Users/>}/>
	},

];

export const getPage = (type: Routes): IPages => Pages.find((item) => item.type === type) ?? Pages[0];