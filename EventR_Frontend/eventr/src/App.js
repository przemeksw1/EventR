import React, { Component } from "react";
import "./App.css";
import pl from "./translations/pl.json";
import en from "./translations/en.json";

import Routes from "./Routes";
import EventRNavbar from "./components/EventRNavbar";
import {
  setTranslations,
  setDefaultLanguage,
  setLanguageCookie
} from "react-switch-lang";

class App extends Component {
  state = {
    isUserLoggedIn: false,
    users: [],
    events: []
  };

  componentDidMount() {
    this.getEvents();
    this.getUsers();

    setTranslations({ en, pl });
    setDefaultLanguage("pl");
    setLanguageCookie();
  }

  logUserIn = user => {
    this.setState({ isUserLoggedIn: true });
    this.addUser(user);
  };

  logUserOut = () => {
    this.setState({ isUserLoggedIn: false });
  };

  addUser = user => {
    fetch("http://localhost:52719/api/users", {
      method: "post",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(user)
    });
    this.getUsers();
  };

  addEvent = event => {
    fetch("http://localhost:52719/api/events", {
      method: "post",
      headers: { "Content-Type": "application/json" },
      body: event
    });
    this.getEvents();
  };

  getUsers = () => {
    fetch("http://localhost:52719/api/users/")
      .then(res => res.json())
      .then(users => {
        this.setState({ users });
      });
  };

  getEvents = () => {
    fetch("http://localhost:52719/api/events/")
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
