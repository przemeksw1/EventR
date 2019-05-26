import "./Register.css";
import React, { Component } from "react";
import { Button, FormControl, FormGroup, Panel } from "react-bootstrap";
import AuthService from "../services/AuthService";

class Register extends Component {
  constructor(props) {
    super(props);
    this.authService = new AuthService();
  }
  state = {
    nickname: "",
    email: "",
    password: "",
    repeatedPassword: "",
    firstName: "",
    lastName: ""
  };

  validateForm() {
    if (
      !(
        this.state.nickname.length > 0 &&
        this.state.email.length > 0 &&
        this.state.password.length > 0 &&
        this.state.firstName.length > 0 &&
        this.state.lastName.length > 0
      )
    )
      return false;
    if (this.state.password !== this.state.repeatedPassword) return false;
    return true;
  }

  handleChange = event => {
    this.setState({
      [event.target.id]: event.target.value
    });
  };

  render() {
    return (
      <div className="register">
        {console.log(window.location.href)}
        <Panel>
          <Panel.Heading>Rejestracja</Panel.Heading>
          <form
            onSubmit={e => {
              this.authService.register(
                this.state.nickname,
                this.state.password,
                this.state.firstName,
                this.state.lastName,
                this.state.email
              );
              e.preventDefault();
            }}
          >
            <FormGroup controlId="nickname">
              <FormControl
                value={this.state.nickname}
                onChange={this.handleChange}
                type="text"
                name="nickname"
                placeholder="Podaj nazwę użytkownika"
              />
            </FormGroup>
            <FormGroup controlId="email">
              <FormControl
                autoFocus
                type="email"
                value={this.state.email}
                onChange={this.handleChange}
                placeholder="Podaj adres email"
                name="email"
              />
            </FormGroup>
            <FormGroup controlId="password">
              <FormControl
                value={this.state.password}
                onChange={this.handleChange}
                type="password"
                name="password"
                placeholder="Podaj hasło"
              />
            </FormGroup>
            <FormGroup controlId="repeatedPassword">
              <FormControl
                value={this.state.repeatedPassword}
                onChange={this.handleChange}
                type="password"
                name="repeatedPassword"
                placeholder="Wpisz hasło jeszcze raz"
              />
            </FormGroup>

            <FormGroup controlId="firstName">
              <FormControl
                value={this.state.firstName}
                onChange={this.handleChange}
                type="text"
                name="firstName"
                placeholder="Imię"
              />
            </FormGroup>
            <FormGroup controlId="lastName">
              <FormControl
                value={this.state.lastName}
                onChange={this.handleChange}
                type="text"
                name="lastName"
                placeholder="Nazwisko"
              />
            </FormGroup>

            <Button
              disabled={!this.validateForm()}
              type="submit"
              className="btn btn-success"
              block
            >
              Zarejestruj się
            </Button>
          </form>
        </Panel>
      </div>
    );
  }
}

export default Register;
