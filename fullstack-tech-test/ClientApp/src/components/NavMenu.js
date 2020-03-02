import React, { Component } from 'react';
import { Container, Navbar, NavbarBrand } from 'reactstrap';
import { Header } from 'semantic-ui-react';
import './NavMenu.css';

export class NavMenu extends Component {

  constructor (props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true
    };
  }

  toggleNavbar () {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  render () {
    return (
      <header>
        <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
                <Container>
                    <NavbarBrand href="/"><Header as="h1" color="grey">Full Stack Tech Test</Header></NavbarBrand>
          </Container>
        </Navbar>
      </header>
    );
  }
}
