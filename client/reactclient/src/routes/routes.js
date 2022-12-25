import React from 'react';
import {
	BrowserRouter as Router,
	Routes,
	Route
} from 'react-router-dom';
import {Pages} from './Pages';

export default function AppRouter() {

	return (
		<Router>
			<Routes>
				{Pages.map((route, key) => {
					return <Route key={key} path={route.path} element={route.element}/>;
				})}
			</Routes>
		</Router>
	);
}