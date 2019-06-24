import "./EventPost.css";
import React, { Component } from "react";
import { Glyphicon } from "react-bootstrap";

class EventPost extends Component {
  render() {
    const { post } = this.props;

    return (
      <div className="eventpost">
        <div className="postimage" />
        <div className="postname">{post.name}</div>
        <div className="postdateandlocale">
          <Glyphicon glyph="calendar" />
          {new Date(post.dateStart).toLocaleDateString("pl-PL")}
        </div>
        <div className="posttext">{post.description}</div>
      </div>
    );
  }
}

export default EventPost;
