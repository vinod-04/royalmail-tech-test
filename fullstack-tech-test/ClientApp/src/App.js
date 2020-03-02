import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import People from './components/people';
import PersonEditForm from './components/people/people-edit';
import APIOffline from './components/api-offline';

import './custom.css'

export default class App extends Component {

    render() {
        return (
            <Layout>
                <Route exact path='/' component={Home} />
                <Route exact path='/people' component={People} />
                <Route exact path='/api-offline' component={APIOffline} />
                <Route path='/people/:personId' component={PersonEditForm} />
            </Layout>
        );
    }
}
