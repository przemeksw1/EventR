import React, { Component } from "react";
import { Route, Switch } from "react-router-dom";

import Home from "./components/Home";
import Login from "./components/Login";
import Register from "./components/Register";
import AdminPanel from "./components/AdminPanel";
import EventPage from "./components/EventPage";

class Routes extends Component {
  render() {
    return (
      <Switch>
        <Route
          exact
          path="/"
          render={props => <Home {...props} posts={this.props.events} />}
        />
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
        <Route
          exact
          path="/admin"
          render={props => (
            <AdminPanel
              {...props}
              users={this.props.users}
              events={this.props.events}
            />
          )}
        />
        <Route
          exact
          path="/event/:id_Wydarzenia"
          render={props => (
            <EventPage {...props} eventId={this.props.eventId} />
          )}
        />
      </Switch>
    );
  }
}
export default Routes;
