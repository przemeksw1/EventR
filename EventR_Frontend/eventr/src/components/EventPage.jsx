import React, { Component } from "react";
import "./EventPage.css";
import { EventService } from "../services/EventService";

class EventPage extends Component {
  constructor(props) {
    super(props);
    this.eventService = new EventService();
  }
  state = {
    event: {}
  };

  componentDidMount() {
    this.eventService
      .getEvent(this.props.match.params.eventId)
      .then(res => res.json())
      .then(event => {
        console.log(event);
        this.setState({ event });
      });
  }

  render() {
    const date = new Date(this.state.event.date);
    return (
      <div className="event-page">
        <div className="title-bar">{this.state.event.name}</div>
        <div className="event-content">
          {this.state.event.category +
            " o tematyce " +
            this.state.event.subject}
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
          {this.state.event.description}
        </div>
        <div className="event-image" />
      </div>
    );
  }
}

export default EventPage;
