import React, { Component } from "react";
import "./EventPage.css";

class EventPage extends Component {
  state = {
    event: {}
  };

  componentDidMount() {
    fetch(
      "http://localhost:52719/api/wydarzenias/" +
        this.props.match.params.id_Wydarzenia
    )
      .then(res => res.json())
      .then(event => {
        console.log(event);
        this.setState({ event });
      });
  }

  render() {
    return (
      <div className="event-page">
        <div className="title-bar">{this.state.event.nazwa}</div>
        <div className="event-content">
          {this.state.event.kategoria +
            " o tematyce " +
            this.state.event.tematyka}
          <br />
          {this.state.event.opis}
        </div>
      </div>
    );
  }
}

export default EventPage;
