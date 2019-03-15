import React, { Component } from "react";
import Table from "./Table";

class AdminPanel extends Component {
  constructor(props) {
    super(props);
    this.state = {
      data: []
    };
  }

  componentDidMount() {
    this.setState({ data: this.props.users });
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
                <h4>Tabels</h4>
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
                <Table
                  data={this.state.data}
                  categories={this.state.categories}
                  updateData={this.reload}
                />
              </div>
            </div>
          </div>
        </div>
      </div>
    );
  }
}

export default AdminPanel;
