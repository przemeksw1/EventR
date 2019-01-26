import React, { Component } from "react";
import "./App.css";

import Routes from "./Routes";
import EventRNavbar from "./components/EventRNavbar";

class App extends Component {
  state = {
    isUserLoggedIn: false,
    users: [{ email: "sznurek05@gmail.com", password: "drucik05" }]
  };

  logUserIn = user => {
    let valid = false;
    this.state.users.forEach(element => {
      if (element.email === user.email && element.password === user.password)
        valid = true;
    });
    if (!valid) alert("Nieprawidłowe dane logowania!");
    this.setState({ isUserLoggedIn: valid });
    //window.location.href = "/";
  };

  logUserOut = () => {
    this.setState({ isUserLoggedIn: false });
    window.location.href = "/";
  };

  addUser = user => {
    var users = this.state.users;
    users.push(user);
    this.setState({ users });
    //window.location.href = "/";
  };

  render() {
    return (
      <div className="App">
        {console.log(window.location.href)}
        <EventRNavbar
          isUserLoggedIn={this.state.isUserLoggedIn}
          logUserOut={this.logUserOut}
        />
        <Routes addUser={this.addUser} logUserIn={this.logUserIn} />
      </div>
    );
  }
}

export default App;
