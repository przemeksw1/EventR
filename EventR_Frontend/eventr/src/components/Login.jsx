import "./Login.css";
import React, { Component } from "react";
import { Button, FormControl, FormGroup, Panel } from "react-bootstrap";

class Login extends Component {
  state = { email: "", password: "" };

  validateForm = () => {
    return this.state.email.length > 0 && this.state.password.length > 0;
  };

  handleChange = event => {
    this.setState({
      [event.target.id]: event.target.value
    });
  };

  render() {
    return (
      <div className="login">
        <Panel>
          <Panel.Heading>Logowanie</Panel.Heading>
          <form
            onSubmit={e => {
              this.props.logUserIn({
                email: this.state.email,
                password: this.state.password
              });
              console.log("dupa");
              e.preventDefault();
            }}
          >
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
            <Button
              disabled={!this.validateForm()}
              type="submit"
              className="btn btn-success"
              block
            >
              Zaloguj się
            </Button>
          </form>
        </Panel>
      </div>
    );
  }
}

export default Login;
