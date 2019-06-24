import "./EventRNavbar.css";
import pl from "../translations/pl.json";
import en from "../translations/en.json";
import React, { Component } from "react";

import { Navbar, NavItem, Nav, Glyphicon, NavDropdown } from "react-bootstrap";
import { Form, FormControl, Button } from "react-bootstrap";
import { LinkContainer } from "react-router-bootstrap";
import { Link } from "react-router-dom";
import { setLanguage, translate } from "react-switch-lang";

import NewEvent from "./NewEvent";
import AuthService from "../services/AuthService";

class EventRNavbar extends Component {
  constructor(props) {
    super(props);
    this.authService = new AuthService();
  }
  state = {
    showCreateForm: false,
    isUserLoggedIn: false
  };
  componentDidMount() {
    const isUserLoggedIn = this.authService.loggedIn();
    this.setState({ isUserLoggedIn });
  }

  hideForm = () => {
    this.setState({ showCreateForm: false });
  };

  render() {
    const { t } = this.props;
    const loginControl = this.state.isUserLoggedIn ? (
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
          <NavItem
            onClick={() => {
              this.authService.logout();
            }}
          >
            {t("navbar.logout")}
          </NavItem>
        </Nav>
      </Navbar.Collapse>
    ) : (
      <Navbar.Collapse>
        <Nav pullRight>
          <NavDropdown title={t("navbar.language")} id="lang-dropdown">
            <NavItem onClick={() => setLanguage("pl")}>Polski</NavItem>
            <NavItem onClick={() => setLanguage("en")}>English</NavItem>
          </NavDropdown>
          <LinkContainer to="/login">
            <NavItem>{t("navbar.login")}</NavItem>
          </LinkContainer>
          <LinkContainer to="/register">
            <NavItem>{t("navbar.signin")}</NavItem>
          </LinkContainer>
        </Nav>
      </Navbar.Collapse>
    );
    return (
      <Navbar collapseOnSelect>
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
export default translate(EventRNavbar);
