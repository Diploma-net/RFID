import React, { useRef, useState } from "react";
import { Container, Row, Col, Table } from "react-bootstrap";
import html2canvas from "html2canvas";
import jsPDF from "jspdf";
import { Button } from "react-bootstrap";

 const ReportPDF = ({ infoAboutReport, checkTypes, statusName }) => {
    const [loading, setLoading] = useState(false);
    const reportRef = useRef(null);
  
    const handleDownloadPDF = async () => {
      setLoading(true);
  
      const input = reportRef.current;
      const pdf = new jsPDF();
  
      // Add the Container to the top of the document
      const canvas = await html2canvas(document.getElementById("report-container"), {
        scale: 2,
      });
      const imgData = canvas.toDataURL("image/png");
      const imgProps = pdf.getImageProperties(imgData);
      const pdfWidth = pdf.internal.pageSize.getWidth();
      const pdfHeight = (imgProps.height * pdfWidth) / imgProps.width;
      pdf.addImage(imgData, "PNG", 10, 10, pdfWidth, pdfHeight);
      const canvasTable = await html2canvas(document.getElementById(`zone-0`), {
        scale: 2,
      });

      // Get the image data
      const imgDataTable = canvasTable.toDataURL("image/png");
      const imgPropsTable = pdf.getImageProperties(imgDataTable);
      const pdfWidthTable = pdf.internal.pageSize.getWidth() - 30;
      const pdfHeightTable = (imgPropsTable.height * pdfWidthTable) / imgPropsTable.width;

      // Add the image to the PDF
      pdf.addImage(imgDataTable, "PNG", 15, 40, pdfWidthTable, pdfHeightTable);
      pdf.addPage();
  
      for (let i = 1; i < infoAboutReport.zonesInfo.length; i++) {
        const zone = infoAboutReport.zonesInfo[i];
  
        // Render the table to a canvas
        const canvas = await html2canvas(document.getElementById(`zone-${i}`), {
          scale: 2,
        });
  
        // Get the image data
        const imgData = canvas.toDataURL("image/png");
  
        const imgProps = pdf.getImageProperties(imgData);
        const pdfWidth = pdf.internal.pageSize.getWidth() - 30;
        const pdfHeight = (imgProps.height * pdfWidth) / imgProps.width;

  
        // Add the image to the PDF
        pdf.addImage(imgData, "PNG", 15, 15, pdfWidth, pdfHeight);
  
        // Add a new page for the next table
        if (i < infoAboutReport.zonesInfo.length - 1) {
          pdf.addPage();
        }
      }
  
      pdf.save(`Отчет №${infoAboutReport.idReport}.pdf`);
      setLoading(false);
    };

  const options = {
    year: "numeric",
    month: "2-digit",
    day: "2-digit",
    hour: "2-digit",
    minute: "2-digit",
    second: "2-digit",
  };

  return (
    <div className="fullReport">
      <Container id="report-container">
        <Row>
          <Col>
            <h2>Отчет № {infoAboutReport.idReport}</h2>
          </Col>
        </Row>
        <Row>
          <Col>
            Дата и время начала проверки:{" "}
            {new Date(infoAboutReport.dateTimeStart).toLocaleString(
              "ru",
              options
            )}
          </Col>
          <Col>Название самолета: {infoAboutReport.namePlane}</Col>
        </Row>
        <Row>
          <Col>
            Дата и время окончания проверки:{" "}
            {new Date(infoAboutReport.dateTimeFinish).toLocaleString(
              "ru",
              options
            )}
          </Col>
          <Col>Тип проверки: {checkTypes[infoAboutReport.type]}</Col>
        </Row>
      </Container>
      <Button disabled={loading} onClick={handleDownloadPDF} style={{ height: "30px", alignSelf: "flex-end", padding: "5px", fontSize: "large" }}>
        {loading ? "Сохранение..." : "Скачать PDF"}
      </Button>
      {infoAboutReport.zonesInfo.map((zone, index) => (
        <div key={index} id={`zone-${index}`}>
          <h3>{zone.nameZone}</h3>
          <Table striped bordered hover>
            <thead>
              <tr>
                <th>Код оборудования</th>
                <th>Место</th>
                <th>Статус</th>
                <th>ФИО проверяющего</th>
                <th>Дата и время проверки</th>
              </tr>
            </thead>
            <tbody>
              {zone.equipReports.map((equipReport, index) => (
                <tr key={index}>
                  <td>{equipReport.nameEquip}</td>
                  <td>{equipReport.space}</td>
                  <td>{statusName[equipReport.status]}</td>
                  <td>{equipReport.fullNameUser}</td>
                  <td>
                    {new Date(equipReport.dateTimeCheck).toLocaleString(
                      "ru",
                      options
                    )}
                  </td>
                </tr>
              ))}
            </tbody>
          </Table>
        </div>
      ))}
    </div>
  );
};

export default ReportPDF;
