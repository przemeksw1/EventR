import React, { Component } from "react";
import Table from "./Table";
import EventService from "../services/EventService";

class AdminPanel extends Component {
  constructor(props) {
    super(props);
    this.eventService = new EventService();
    this.state = {
      data: []
    };
  }

  componentDidMount() {
    this.eventService
      .getEvents()
      .then(res => res.json)
      .then(events => this.setState({ data: events }));
  }

  reload = () => {
    window.location.reload(true);
  };

  render() {
    return (
      <div className="container-fluid">
        <div className="row content">
          <div className="col-sm-3 sidenav">
            {/*left side*/}
            <div className="panel panel-default">
              <div className="panel-body">
                <h4>Tabele</h4>
                <ul className="nav nav-pills nav-stacked">
                  <li className="active">
                    <a
                      href="#"
                      onClick={() => this.setState({ data: this.props.users })}
                    >
                      Użytkownicy
                    </a>
                  </li>
                  <li className="active">
                    <a
                      href="#"
                      onClick={() => this.setState({ data: this.props.events })}
                    >
                      Eventy
                    </a>
                  </li>
                </ul>
                <br />
              </div>
            </div>
          </div>
          {/*right side*/}
          <div className="col-sm-9">
            <div className="panel panel-default">
              <div className="panel-body">
                <Table data={this.state.data} />
              </div>
            </div>
          </div>
        </div>
      </div>
    );
  }
}

export default AdminPanel;
