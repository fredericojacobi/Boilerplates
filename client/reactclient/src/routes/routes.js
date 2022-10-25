import React from 'react';
import {
	BrowserRouter as Router,
	Routes,
	Route
} from 'react-router-dom';
import Home from '../pages/Home/Home';
import Layout from '../components/Layout/Layout';
import Contact from '../pages/Contact/Contact';
import Dashboard from '../pages/Dashboard/Dashboard';
import SignIn from '../pages/Account/SignIn';
import SignUp from '../pages/Account/SignUp';

export default function AppRouter() {
	return (
		<Router>
			<Routes>
				<Route path="/" element={<Layout page={<Home/>}/>}/>
				<Route path="/user/signin" element={<Layout page={<SignIn/>}/>}/>
				<Route path="/user/signup" element={<Layout page={<SignUp/>}/>}/>
				<Route path="/contact" element={<Layout page={<Contact/>}/>}/>
				<Route path="/dashboard" element={<Layout dashboard={true} page={<Dashboard/>}/>}/>
			</Routes>
		</Router>
	);
}