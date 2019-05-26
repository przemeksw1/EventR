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
import AuthService from "./services/AuthService";
import EventService from "./services/EventService";

class App extends Component {
  constructor(props) {
    super(props);
    this.authService = new AuthService();
    this.eventService = new EventService();
  }
  state = {
    events: []
  };

  componentDidMount() {
    this.getEvents();

    setTranslations({ en, pl });
    setDefaultLanguage("pl");
    setLanguageCookie();
  }

  // addEvent = event => {
  //   fetch("https://eventrwebapi.azurewebsites.net/api/events", {
  //     method: "post",
  //     headers: { "Content-Type": "application/json" },
  //     body: JSON.stringify(event)
  //   });
  //   this.getEvents();
  //   //TODO: przerobić
  // };

  getEvents = () => {
    this.eventService
      .getEvents()
      .then(res => res.json())
      .then(events => this.setState({ events }));
  };

  render() {
    return (
      <div className="App">
        {console.log(window.location.href)}
        <EventRNavbar />
        <Routes events={this.state.events} />
      </div>
    );
  }
}

export default App;
