import React from 'react';
import { Message, Icon } from 'semantic-ui-react';

const Spinner = () => (
    <Message icon>
        <Icon name='circle notched' loading />
        <Message.Content>
            <Message.Header>Loading...</Message.Header>
    </Message.Content>
    </Message>
)

export default Spinner