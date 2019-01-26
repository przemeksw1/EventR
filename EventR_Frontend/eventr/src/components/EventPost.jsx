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
          {post.date}, {post.localization}
        </div>
        <div className="posttext">{post.text}</div>
      </div>
    );
  }
}

export default EventPost;
