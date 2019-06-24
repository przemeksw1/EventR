import "./NewEvent.css";

import EventService from "../services/EventService";
import React, { Component } from "react";
import DateTimePicker from "react-datetime-picker";
import {
  ControlLabel,
  FormControl,
  FormGroup,
  Modal,
  Button,
  Tooltip,
  OverlayTrigger
} from "react-bootstrap";

class NewEvent extends Component {
  constructor(props) {
    super(props);
    this.eventService = new EventService();
  }
  state = {
    event: {
      name: "",
      description: "",
      dateStart: new Date(),
      dateEnd: new Date(),
      category: "",
      state: false,
      subject: "",
      imageMainLink: ""
    }
  };

  onchangestart = dateStart => {
    let eventState = this.state.event;
    eventState.dateStart = dateStart;
    this.setState({ event: eventState });
  };

  onchangeend = dateEnd => {
    let eventState = this.state.event;
    eventState.dateEnd = dateEnd;
    this.setState({ event: eventState });
  };

  handleChange = event => {
    let eventState = this.state.event;
    console.log(event.target.name, event.target.value);
    eventState[event.target.name] = event.target.value;
    this.setState({ event: eventState });
  };

  handleSubmit = () => {
    this.eventService.addEvent(this.state.event);
    this.props.hideHandler();
  };

  render() {
    return (
      <Modal show={this.props.show} dialogClassName="custom-modal">
        <Modal.Header>
          <Modal.Title>Stwórz swój event!</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <div className="newevent">
            <div className="neweventname">
              <FormGroup style={{ textAlign: "left" }}>
                <ControlLabel>Nazwa: </ControlLabel>
                <FormControl
                  value={this.state.event.name}
                  onChange={this.handleChange}
                  name="name"
                />
              </FormGroup>
            </div>
            <div className="neweventlink">
              <FormGroup style={{ textAlign: "left" }}>
                <ControlLabel>Link do zdjęcia: </ControlLabel>
                <FormControl
                  value={this.state.event.imageMainLink}
                  onChange={this.handleChange}
                  onBlur={this.loadImage}
                  name="imageMainLink"
                />
              </FormGroup>
            </div>
            <div className="datetimestart">
              <FormGroup style={{ textAlign: "left" }}>
                <ControlLabel>Data i godzina rozpoczęcia: </ControlLabel>
                <DateTimePicker
                  value={this.state.event.dateStart}
                  onChange={this.onchangestart}
                />
              </FormGroup>
            </div>
            <div className="datetimeend">
              <FormGroup style={{ textAlign: "left" }}>
                <ControlLabel>Data i godzina zakończenia: </ControlLabel>
                <DateTimePicker
                  value={this.state.event.dateEnd}
                  onChange={this.onchangeend}
                />
              </FormGroup>
            </div>
            <div className="neweventsubject">
              <FormGroup style={{ textAlign: "left" }}>
                <ControlLabel>Tematyka: </ControlLabel>
                <FormControl
                  value={this.state.event.subject}
                  onChange={this.handleChange}
                  name="subject"
                />
              </FormGroup>
            </div>
            <div className="selectcategory">
              <FormGroup style={{ textAlign: "left" }}>
                <ControlLabel>Kategoria: </ControlLabel>
                <FormControl
                  componentClass="select"
                  placeholder="Kategoria"
                  name="category"
                  value={this.state.event.category}
                  onChange={this.handleChange}
                >
                  <option value="Muzyka">Muzyka</option>
                  <option value="Sport">Sport</option>
                  <option value="Obóz">Obóz</option>
                  <option value="Kino i film">Kino i film</option>
                  <option value="E-sport">E-sport</option>
                  <option value="Spotkanie grupowe">Spotkanie grupowe</option>
                </FormControl>
              </FormGroup>
            </div>
            <div className="eventdetails">
              <FormGroup style={{ textAlign: "left" }}>
                <ControlLabel>Szczegóły: </ControlLabel>
                <FormControl
                  componentClass="textarea"
                  placeholder="Szczegóły"
                  value={this.state.event.description}
                  onChange={this.handleChange}
                  name="description"
                />
              </FormGroup>
            </div>
          </div>
        </Modal.Body>
        <Modal.Footer>
          <Button
            bsStyle="primary"
            type="submit"
            form="createForm"
            onClick={this.handleSubmit}
          >
            Zatwierdź
          </Button>
          <Button onClick={this.props.hideHandler}>Anuluj</Button>
        </Modal.Footer>
      </Modal>
    );
  }
}

export default NewEvent;
