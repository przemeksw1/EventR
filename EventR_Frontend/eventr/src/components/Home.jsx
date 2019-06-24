import "./Home.css";

import { Link } from "react-router-dom";
import React, { Component } from "react";
import Calendar from "react-calendar";
import { FormControl } from "react-bootstrap";
import EventPost from "./EventPost";
import { translate } from "react-switch-lang";

class Home extends Component {
  state = {
    user: {},
    observedEvents: [
      { eventId: 3, date: new Date(2019, 7, 20).toUTCString() },
      { eventId: 8, date: new Date(2019, 6, 28).toUTCString() }
    ],
    likedEvents: [
      { eventId: 3, date: new Date(2019, 6, 15).toUTCString() },
      { eventId: 8, date: new Date(2019, 6, 25).toUTCString() }
    ],
    searchVal: ""
  };

  componentDidMount() {}

  handleChange = e => {
    this.setState({ searchVal: e.target.value });
  };

  render() {
    const { t } = this.props;
    return (
      <div className="home">
        <div className="banner">
          <div className="bannerimage">
            <p>EventR</p>
            <FormControl
              placeholder={t("home.searchEvent")}
              onChange={this.handleChange}
              value={this.state.searchVal}
            />
          </div>
        </div>
        <div className="main">
          {this.props.posts
            .filter(post =>
              post.name
                .toLowerCase()
                .includes(this.state.searchVal.toLowerCase())
            )
            .sort(
              (event1, event2) =>
                new Date(event2.dateStart).getMilliseconds() -
                new Date(event1.dateStart).getMilliseconds()
            )
            .map(post => (
              <Link key={post.eventId} to={"/event/" + post.eventId}>
                <EventPost post={post} />
              </Link>
            ))}
        </div>
        <div className="side">
          <span
            style={{
              color: "white",
              fontSize: "24px"
            }}
          >
            {t("home.calendar")}
          </span>
          {console.log(this.state.observedEvents)}
          <Calendar
            tileContent={({ date, view }) =>
              view === "month" &&
              this.state.observedEvents.filter(
                obj =>
                  new Date(obj.date).getDate() == date.getDate() &&
                  new Date(obj.date).getMonth() == date.getMonth()
              ).length > 0 ? (
                <div className="calendar-tile-observe" />
              ) : view === "month" &&
                this.state.likedEvents.filter(
                  obj =>
                    new Date(obj.date).getDate() == date.getDate() &&
                    new Date(obj.date).getMonth() == date.getMonth()
                ).length > 0 ? (
                <div className="calendar-tile-like" />
              ) : null
            }
          />
        </div>
      </div>
    );
  }
}

export default translate(Home);
