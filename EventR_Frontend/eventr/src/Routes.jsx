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
        <Route exact path="/login" render={props => <Login {...props} />} />
        <Route
          exact
          path="/register"
          render={props => <Register {...props} />}
        />
        <Route
          exact
          path="/admin"
          render={props => <AdminPanel {...props} events={this.props.events} />}
        />
        <Route
          exact
          path="/event/:eventId"
          render={props => (
            <EventPage {...props} eventId={this.props.eventId} />
          )}
        />
      </Switch>
    );
  }
}
export default Routes;
