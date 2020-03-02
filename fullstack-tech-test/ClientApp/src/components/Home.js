import React, { Component } from 'react';
import { Button, Icon } from 'semantic-ui-react'
import { Link } from 'react-router-dom'

export class Home extends Component {

  render () {
    return (
      <div>
            <Button icon labelPosition='right' as={Link} to="/people" color='blue'>
                Load People Skills
                <Icon name='right arrow' />
            </Button>
      </div>
    );
  }
}
