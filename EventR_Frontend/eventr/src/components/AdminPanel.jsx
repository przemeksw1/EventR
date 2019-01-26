import React, { Component } from "react";
import Table from "./Table";
import { Button } from "react-bootstrap";

// import FormBuilder from './FormBuilder';

class AdminPanel extends Component {
  constructor(props) {
    super(props);
    this.state = {
      data: [
        { id: 1, name: "Event1", localization: "Białystok", ownerId: 54 },
        { id: 2, name: "Event2", localization: "Warszawa", ownerId: 76 }
      ],
      categories: [],
      apiUrl: { plural: "products", singular: "product" },
      showCreateForm: false
    };
    this.handleChange = this.handleChange.bind(this);
    this.hideForm = this.hideForm.bind(this);
    this.updateData = this.updateData.bind(this);
  }

  handleChange = event => {
    this.setState({
      ["form-" + event.target.id]: event.target.value
    });
  };

  hideForm() {
    this.setState({ showCreateForm: false });
  }

  updateData(model) {
    window.location.reload(true);
  }

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
                      href="#section"
                      onClick={() => {
                        this.setState({
                          apiUrl: { plural: "users", singular: "user" }
                        });
                      }}
                    >
                      Użytkownicy
                    </a>
                  </li>
                  <li className="active">
                    <a
                      href="#section2"
                      onClick={() => {
                        this.setState({
                          apiUrl: { plural: "events", singular: "event" }
                        });
                      }}
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
                <Button
                  onClick={() => {
                    this.setState({ showCreateForm: true });
                  }}
                >
                  Utwórz
                </Button>
                {/* <FormBuilder
                  model={this.state.apiUrl.singular}
                  apiUrl={this.state.apiUrl}
                  apiAction={"add"}
                  categories={this.state.categories}
                  showForm={this.state.showCreateForm}
                  title={"Utwórz"}
                  hideForm={this.hideForm}
                  updateData={this.updateData}
                /> */}
                <Table
                  apiUrl={this.state.apiUrl}
                  data={this.state.data}
                  categories={this.state.categories}
                  updateData={this.updateData}
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
