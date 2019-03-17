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
    const date = new Date(this.state.event.data);
    return (
      <div className="event-page">
        <div className="title-bar">{this.state.event.nazwa}</div>
        <div className="event-content">
          {this.state.event.kategoria +
            " o tematyce " +
            this.state.event.tematyka}
          <br />
          <b>
            {date.toLocaleDateString("pl-PL") +
              " o " +
              date.getHours() +
              ":" +
              date.getHours()}
          </b>
          <br />
          <br />
          {this.state.event.opis}
        </div>
        <div className="event-image" />
      </div>
    );
  }
}

export default EventPage;
