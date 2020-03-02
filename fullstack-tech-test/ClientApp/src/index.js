import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import registerServiceWorker from './registerServiceWorker';

import { Provider } from 'react-redux';
import { BrowserRouter as Router } from 'react-router-dom'
import store from './store/configureStore';

ReactDOM.render(
    (
        <Provider store={store}>
            <Router>
                <App />
            </Router>
        </Provider>
    ), document.getElementById('root'));

registerServiceWorker();

