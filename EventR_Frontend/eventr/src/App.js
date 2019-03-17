import React, { Component } from "react";
import "./App.css";

import Routes from "./Routes";
import EventRNavbar from "./components/EventRNavbar";

class App extends Component {
  state = {
    isUserLoggedIn: false,
    users: [],
    events: []
  };

  componentDidMount() {
    this.getEvents();
    this.getUsers();
  }

  logUserIn = user => {
    this.setState({ isUserLoggedIn: true });
    this.addUser(user);
  };

  logUserOut = () => {
    this.setState({ isUserLoggedIn: false });
  };

  addUser = user => {
    fetch("http://localhost:52719/api/uzytkownicies", {
      method: "post",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(user)
    });
    this.getUsers();
  };

  addEvent = event => {
    fetch("http://localhost:52719/api/wydarzenias", {
      method: "post",
      headers: { "Content-Type": "application/json" },
      body: event
    });
    this.getEvents();
  };

  getUsers = () => {
    fetch("http://localhost:52719/api/uzytkownicies/")
      .then(res => res.json())
      .then(users => {
        this.setState({ users });
      });
  };

  getEvents = () => {
    fetch("http://localhost:52719/api/wydarzenias/")
      .then(res => res.json())
      .then(events => this.setState({ events }));
  };

  render() {
    return (
      <div className="App">
        {console.log(window.location.href)}
        <EventRNavbar
          isUserLoggedIn={this.state.isUserLoggedIn}
          logUserOut={this.logUserOut}
        />
        <Routes
          addUser={this.addUser}
          addEvent={this.addEvent}
          logUserIn={this.logUserIn}
          users={this.state.users}
          events={this.state.events}
        />
      </div>
    );
  }
}

export default App;
