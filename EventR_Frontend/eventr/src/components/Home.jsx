import "./Home.css";

import { Link } from "react-router-dom";
import React, { Component } from "react";
import Calendar from "react-calendar";
import { FormControl } from "react-bootstrap";
import EventPost from "./EventPost";
import { translate } from "react-switch-lang";

class Home extends Component {
  state = {};

  componentDidMount() {}

  render() {
    const { t } = this.props;
    return (
      <div className="home">
        <div className="banner">
          <div className="bannerimage">
            <p>EventR</p>
            <FormControl placeholder={t("home.searchEvent")} />
          </div>
        </div>
        <div className="main">
          {this.props.posts.map(post => (
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
          <Calendar />
        </div>
      </div>
    );
  }
}

export default translate(Home);
