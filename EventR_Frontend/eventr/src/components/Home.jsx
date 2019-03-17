import "./Home.css";

import { Link } from "react-router-dom";
import React, { Component } from "react";
import Calendar from "react-calendar";
import { FormControl } from "react-bootstrap";
import EventPost from "./EventPost";

class Home extends Component {
  state = {};

  componentDidMount() {}

  render() {
    return (
      <div className="home">
        <div className="banner">
          <div className="bannerimage">
            <p>EventR</p>
            <FormControl placeholder="Szukaj eventu" />
          </div>
        </div>
        <div className="main">
          {this.props.posts.map(post => (
            <Link to={"/event/" + post.id_Wydarzenia}>
              <EventPost key={post.nazwa} post={post} />
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
            Kalendarz eventów
          </span>
          <Calendar />
        </div>
      </div>
    );
  }
}

export default Home;
