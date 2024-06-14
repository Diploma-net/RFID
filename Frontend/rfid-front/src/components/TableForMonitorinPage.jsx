import React from "react";
import Table from "react-bootstrap/Table";
import { Button } from "react-bootstrap";
import { useNavigate } from "react-router-dom";
import {checkTypes} from "../const/checkTypes";

export default function TableForMonitorinPage({ data, textForButton }) {
  const navigate = useNavigate();
  const options = { year: 'numeric', month: '2-digit', day: '2-digit', hour: '2-digit', minute: '2-digit', second: '2-digit' };

  return (
    <Table striped style={{ marginTop: "50px" }}>
      <thead>
        <tr>
          <th>#</th>
          <th style={{textAlign: "center"}}>Название самолета</th>
          <th style={{textAlign: "center"}}>Тип проверки</th>
          <th style={{textAlign: "center"}}>Дата начала проверки</th>
        </tr>
      </thead>
      <tbody>
        {Array.from(data.entries()).map(([key, value]) => (
          <tr key={key}>
            <td>{Number(Number(key)+1)}</td>
            <td style={{textAlign: "center"}}>{value.namePlane}</td>
            <td style={{textAlign: "center"}}>{checkTypes[value.reportType]}</td>
            <td style={{textAlign: "center"}}>{ new Date(value.dateTimeStart).toLocaleString('ru', options)}</td>
            <td style={{textAlign: "center"}}>
              <Button
                onClick={() => navigate(`/monitor/${value.namePlane}`, { replace: false })}
                style={{ height: "30px", alignSelf: "center", padding: "5px", fontSize: "large" }}>
                {textForButton}
              </Button>
            </td>
          </tr>
        ))}
      </tbody>
    </Table>
  );
}
