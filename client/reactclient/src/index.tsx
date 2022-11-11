import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import reportWebVitals from './reportWebVitals';
import Router from './routes/routes';
import GlobalServices from './services/GlobalServices';

const root = ReactDOM.createRoot(
	document.getElementById('appRoot') as HTMLElement
);
root.render(
	/*
		According to ref, strictMode was removed to avoid useEffect runs twice in the first rendering
		ref: https://github.com/facebook/react/issues/24502
	 */
	// <React.StrictMode>
	<GlobalServices>
		<Router/>
	</GlobalServices>
	// </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
