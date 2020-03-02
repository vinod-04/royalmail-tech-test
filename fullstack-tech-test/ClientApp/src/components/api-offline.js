import React, { Component } from 'react';
import { Message } from 'semantic-ui-react';

export default class APIOffline extends Component {

    render() {
        return (
            <div>
                <Message
                    error
                    header='Seems like People API is offline'
                    list={[
                        'You must run People API for any server side operations.',
                        'Run: https://localhost:44355.',
                    ]}
                />
            </div>
        );
    }
}
