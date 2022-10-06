import React from 'react';
import {BrowserRouter as Router, Routes, Route} from 'react-router-dom';
import Home from '../pages/Home/Home';
import Layout from '../components/Layout/Layout';
import Contact from '../pages/Contact/Contact';

export default function AppRouter() {
	return (
		<Router>
			<Routes>
				<Route path="/" element={<Layout page={<Home/>}/>}/>
				<Route path="/contact" element={<Layout page={<Contact/>}/>}/>
			</Routes>
		</Router>
	);
}