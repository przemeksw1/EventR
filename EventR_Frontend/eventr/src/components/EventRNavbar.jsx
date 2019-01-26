import "./EventRNavbar.css";
import React, { Component } from "react";

import { Navbar, NavItem, Nav, Glyphicon } from "react-bootstrap";
import { LinkContainer } from "react-router-bootstrap";
import { Link } from "react-router-dom";

import NewEvent from "./NewEvent";

class EventRNavbar extends Component {
  state = {
    showCreateForm: false
  };

  hideForm = () => {
    this.setState({ showCreateForm: false });
  };

  render() {
    const { isUserLoggedIn } = this.props;
    const loginControl = isUserLoggedIn ? (
      <Navbar.Collapse>
        <Nav pullRight>
          <Nav pullRight>
            <NavItem
              onClick={() => {
                this.props.logUserOut();
              }}
            >
              Wyloguj się
            </NavItem>
          </Nav>
        </Nav>
      </Navbar.Collapse>
    ) : (
      <Navbar.Collapse>
        <Nav pullRight>
          <NavItem
            onClick={() => {
              this.setState({ showCreateForm: true });
            }}
          >
            <Glyphicon glyph="plus" style={{ fontSize: "16px" }} />
            <NewEvent
              show={this.state.showCreateForm}
              hideHandler={this.hideForm}
              bsSize="large"
            />
          </NavItem>
          <LinkContainer to="/login">
            <NavItem>Zaloguj się</NavItem>
          </LinkContainer>
          <LinkContainer to="/register">
            <NavItem>Zarejestruj się</NavItem>
          </LinkContainer>
        </Nav>
      </Navbar.Collapse>
    );
    return (
      <Navbar fluid collapseOnSelect>
        <Navbar.Header>
          <Navbar.Brand>
            <Link to="/">EventR</Link>
          </Navbar.Brand>
          <Navbar.Toggle />
        </Navbar.Header>
        {loginControl}
      </Navbar>
    );
  }
}

export default EventRNavbar;
