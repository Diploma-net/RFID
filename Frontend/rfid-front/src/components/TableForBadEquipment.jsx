import React from "react";
import Table from "react-bootstrap/Table";

export default function TableForMonitorinOnePlane({ data }) {
  const statusName = {
    2: "Утеряно", // NotFound
    3: "До истечения срока годности остался месяц", // DateFail
    4: "Срок годности истек", // DateMonth
    5: "Аварийно-спасательное оборудование со скалада", // Archive
  };
  let sortData = new Map();
  Array.from(data.entries()).map(([key, value]) => {
    if (value != 1 && value != 0) {
      sortData.set(key, value);
    }
  });

  return (
    <Table striped>
      <thead >
        <tr>
          <th style={{textAlign: "center"}}>Место</th>
          <th style={{textAlign: "center"}}>Проблема</th>
        </tr>
      </thead>
      <tbody>
        {[...sortData].map(([key, value]) => (
          <tr key={key}>
            <td style={{textAlign: "center"}}>{key}</td>
            <td style={{paddingLeft: "100px"}}>{statusName[value]}</td>
          </tr>
        ))}
      </tbody>
    </Table>
  );
}
