import React, { Component } from "react";
import "./EventPage.css";
import { Button } from "react-bootstrap";
import { EventService } from "../services/EventService";
import { AuthService } from "../services/AuthService";

class EventPage extends Component {
  constructor(props) {
    super(props);
    this.eventService = new EventService();
    this.authService = new AuthService();
    this.loggedIn = this.authService.loggedIn();
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

  handleLike = () => {
    this.eventService.likeEvent(this.state.event.eventId);
  };

  handleObserve = () => {
    this.eventService.observeEvent(this.state.event.eventId);
  };

  render() {
    const dateStart = new Date(this.state.event.dateStart);
    const dateEnd = new Date(this.state.event.dateEnd);
    return (
      <div className="event-page">
        <div className="title-bar">{this.state.event.name}</div>
        <div className="event-content">
          {this.state.event.category +
            " o tematyce " +
            this.state.event.subject}
          <br />
          <b>
            {dateStart.toLocaleDateString("pl-PL") +
              " o " +
              dateStart.getHours() +
              ":" +
              dateStart.getMinutes()}
            {dateEnd.getTime() - dateStart.getTime() < 60000
              ? null
              : dateEnd.toLocaleDateString("pl-PL") +
                " o " +
                dateEnd.getHours() +
                ":" +
                dateEnd.getMinutes()}
          </b>
          <br />
          <br />
          {this.state.event.description}
          <br />
          <br />
          {this.loggedIn ? (
            <Button bsStyle="success" onClick={this.handleLike}>
              Weź udział
            </Button>
          ) : null}{" "}
          {this.loggedIn ? (
            <Button bsStyle="warning" onClick={this.handleObserve}>
              Obserwuj
            </Button>
          ) : null}
        </div>
        <img id="event-image" src={this.state.event.imageMainLink} />
      </div>
    );
  }
}

export default EventPage;
