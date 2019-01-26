import React, { Component } from "react";
import TableRow from "./TableRow";

class Table extends Component {
  constructor(props) {
    super(props);
    this.renderHeaders = this.renderHeaders.bind(this);
  }

  renderHeaders() {
    const heads = [];
    if (this.props.data.length > 0) {
      const keys = Object.keys(this.props.data[0]);
      for (let i = 0; i < keys.length; i++) {
        let header = "s";
        switch (keys[i]) {
          case "ownerId":
            header = "Id organizatora";
            break;
          case "localization":
            header = "Lokalizacja";
            break;
          case "id":
            header = "Id";
            break;
          case "name":
            header = "Nazwa";
            break;
          case "categoryId":
            header = "Kategoria";
            break;
          case "isHidden":
            header = "Ukryty";
            break;
          case "expertEmail":
            header = "Mail eksperta";
            break;
          case "pricePln":
            header = "Cena PLN";
            break;
          case "taxRate":
            header = "Stopa podatkowa";
            break;
          case "discount":
            header = "Zniżka";
            break;
          case "amountAvailable":
            header = "Dostępne";
            break;
          case "boughtTimes":
            header = "Kupiono";
            break;
          case "imageBase64":
            header = "Obrazek";
            break;
          case "superiorCategoryId":
            header = "Kategoria nadrzędna";
            break;
          case "subCategories":
            header = "Podkategorie";
            break;
          default:
            continue;
        }
        heads.push(
          <th key={i} style={{ textAlign: "center" }}>
            {header}
          </th>
        );
      }
    }
    return heads;
  }

  render() {
    return (
      <main>
        <table className="table table-striped">
          <thead>
            <tr>{this.renderHeaders()}</tr>
          </thead>
          <tbody>
            {this.props.data.map(data => (
              <TableRow
                key={data.id}
                rowData={data}
                Auth={this.props.Auth}
                apiUrl={this.props.apiUrl}
                categories={this.props.categories}
                updateData={this.props.updateData}
              />
            ))}
          </tbody>
        </table>
      </main>
    );
  }
}

export default Table;
