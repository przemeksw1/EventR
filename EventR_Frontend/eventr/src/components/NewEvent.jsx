import "./NewEvent.css";

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
  state = { show: false, datestart: new Date(), dateend: new Date() };

  onchangestart = datestart => {
    this.setState({ datestart });
  };

  onchangeend = dateend => {
    this.setState({ dateend });
  };

  render() {
    return (
      <Modal
        show={this.props.show}
        onHide={this.props.hideHandler}
        dialogClassName="custom-modal"
      >
        <Modal.Header>
          <Modal.Title>Stwórz swój event!</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <div className="newevent">
            <div className="imagepreview">
              <OverlayTrigger
                overlay={<Tooltip id={1}>Wybierz zdjęcie</Tooltip>}
                delayShow={150}
              >
                <button>
                  <div className="placeholder">{}</div>
                  <div className="image">{}</div>
                </button>
              </OverlayTrigger>
            </div>
            <div className="neweventname">
              <FormGroup style={{ textAlign: "left" }}>
                <ControlLabel>Nazwa: </ControlLabel>
                <FormControl />
              </FormGroup>
            </div>
            <div className="datetimestart">
              <FormGroup style={{ textAlign: "left" }}>
                <ControlLabel>Data i godzina rozpoczęcia: </ControlLabel>
                <DateTimePicker
                  value={this.state.datestart}
                  onChange={this.onchangestart}
                />
              </FormGroup>
            </div>
            <div className="datetimeend">
              <FormGroup style={{ textAlign: "left" }}>
                <ControlLabel>Data i godzina zakończenia: </ControlLabel>
                <DateTimePicker
                  value={this.state.dateend}
                  onChange={this.onchangeend}
                />
              </FormGroup>
            </div>
            <div className="selectcategory">
              <FormGroup style={{ textAlign: "left" }}>
                <ControlLabel>Kategoria: </ControlLabel>
                <FormControl componentClass="select" placeholder="Kategoria">
                  <option value="music">Muzyczny</option>
                  <option value="sport">Sportowy</option>
                  <option value="sport">Obóz</option>
                  <option value="sport">Kino i film</option>
                  <option value="sport">E-sport</option>
                  <option value="sport">Spotkanie grupowe</option>
                </FormControl>
              </FormGroup>
            </div>
            <div className="eventdetails">
              <FormGroup style={{ textAlign: "left" }}>
                <ControlLabel>Szczegóły: </ControlLabel>
                <FormControl
                  componentClass="textarea"
                  placeholder="Szczegóły"
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
            onClick={this.props.hideHandler}
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
