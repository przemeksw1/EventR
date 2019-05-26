import "./Login.css";
import React, { Component } from "react";
import { Button, FormControl, FormGroup, Panel } from "react-bootstrap";
import { translate } from "react-switch-lang";
import AuthService from "../services/AuthService";

class Login extends Component {
  constructor(props) {
    super(props);
    this.authService = new AuthService();
  }
  state = { nickname: "", password: "" };

  validateForm = () => {
    return this.state.nickname.length > 0 && this.state.password.length > 0;
  };

  handleChange = event => {
    this.setState({
      [event.target.id]: event.target.value
    });
  };

  render() {
    const { t } = this.props;
    return (
      <div className="login">
        <Panel>
          <Panel.Heading>{t("login.heading")}</Panel.Heading>
          <form
            onSubmit={e => {
              this.authService.login(this.state.nickname, this.state.password);
              e.preventDefault();
            }}
          >
            <FormGroup controlId="nickname">
              <FormControl
                autoFocus
                type="text"
                value={this.state.nickname}
                onChange={this.handleChange}
                placeholder="Podaj nazwę użytkownika"
                name="nickname"
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
              {t("login.login")}
            </Button>
          </form>
        </Panel>
      </div>
    );
  }
}

export default translate(Login);
