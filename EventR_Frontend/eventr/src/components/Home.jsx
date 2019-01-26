import "./Home.css";

import React, { Component } from "react";
import Calendar from "react-calendar";
import { FormControl } from "react-bootstrap";
import EventPost from "./EventPost";

class Home extends Component {
  state = {
    Posts: [
      {
        imagepath:
          "C:/Users/Admin/Desktop/code/eventr/src/components/img/postimage.jpg",
        date: "11/12/2018",
        name: "Event1",
        localization: "Białystok",
        text:
          "Lorem ipsum, dolor sit amet consectetur adipisicing elit. Iste laborum nihil, a modi maxime, deserunt maiores necessitatibus aliquam cum placeat aut rerum! Adipisci ullam ea obcaecati incidunt quibusdam corrupti omnis inventore ab repellendus quasi, quisquam quos dicta cumque quod reprehenderit suscipit consequatur id debitis reiciendis eaque fuga nobis deserunt fugiat."
      },
      {
        imagepath:
          "C:/Users/Admin/Desktop/code/eventr/src/components/img/postimage.jpg",
        date: "20/02/2019",
        name: "Event2",
        localization: "Warszawa",
        text:
          "Lorem ipsum, dolor sit amet consectetur adipisicing elit. Iste laborum nihil, a modi maxime, deserunt maiores necessitatibus aliquam cum placeat aut rerum! Adipisci ullam ea obcaecati incidunt quibusdam corrupti omnis inventore ab repellendus quasi, quisquam quos dicta cumque quod reprehenderit suscipit consequatur id debitis reiciendis eaque fuga nobis deserunt fugiat."
      }
    ]
  };
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
          {this.state.Posts.map(post => (
            <EventPost key={post.name} post={post} />
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
