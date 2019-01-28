import React, { Component } from "react";

// import FormBuilder from "./FormBuilder";

class TableRow extends Component {
  constructor(props) {
    super(props);
    this.state = {
      isHiddenChecked: false,
      showDeleteForm: false,
      showEditForm: false
    };
    this.hideEditForm = this.hideEditForm.bind(this);
    this.hideDeleteForm = this.hideDeleteForm.bind(this);
  }

  componentDidMount() {
    const rowKeys = Object.keys(this.props.rowData);
    for (let i = 0; i < rowKeys.length; i++) {
      this.setState({ [rowKeys[i]]: this.props.rowData[rowKeys[i]] });
    }
  }

  hideEditForm() {
    this.setState({ showEditForm: false });
  }

  hideDeleteForm() {
    this.setState({ showDeleteForm: false });
  }

  render() {
    const { rowData } = this.props;
    const rowKeys = Object.keys(rowData);
    const rows = [];
    let content = {};
    for (let i = 0; i < rowKeys.length; i++) {
      // TODO: przenieść do funkcji translatującej
      switch (rowKeys[i]) {
        case "id":
          content = rowData[rowKeys[i]];
          break;
        case "name":
          content = rowData[rowKeys[i]];
          break;
        case "categoryId":
          content = this.getCategoryName(rowData[rowKeys[i]]);
          break;
        case "localization":
          content = rowData[rowKeys[i]];
          break;
        case "ownerId":
          content = rowData[rowKeys[i]];
          break;
        case "imageBase64":
          content = (
            <img src={"data:image/jpeg;base64," + rowData[rowKeys[i]]} alt="" />
          );
          break;
        default:
          continue;
      }
      rows.push(<td key={i}>{content}</td>);
    }

    return (
      <tr>
        {rows}
        <td>
          {/* eslint-disable-next-line */}
          <a
            href="#"
            style={{ marginRight: "8px" }}
            onClick={() => {
              this.setState({ showEditForm: true });
            }}
          >
            <i className="fa fa-pencil fa-2x" aria-hidden="true" />
          </a>
          <a
            href="#"
            onClick={() => {
              this.setState({ showDeleteForm: true });
            }}
          >
            <i className="fa fa-trash fa-2x" aria-hidden="true" />
          </a>
        </td>
      </tr>
    );
  }
}

export default TableRow;
