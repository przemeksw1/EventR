import React, { Component } from "react";
import { Route, Switch } from "react-router-dom";

import Home from "./components/Home";
import Login from "./components/Login";
import Register from "./components/Register";
import AdminPanel from "./components/AdminPanel";

class Routes extends Component {
  render() {
    return (
      <Switch>
        <Route exact path="/" component={Home} />
        <Route
          exact
          path="/login"
          render={props => (
            <Login {...props} logUserIn={this.props.logUserIn} />
          )}
        />
        <Route
          exact
          path="/register"
          render={props => <Register {...props} addUser={this.props.addUser} />}
        />
        <Route exact path="/admin" component={AdminPanel} />
      </Switch>
    );
  }
}
export default Routes;
