import { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import { getOneReport } from "../api/apiClient";
import Spinner from "react-bootstrap/Spinner";
import { checkTypes } from "../const/checkTypes";
import ReportPDF from "../components/DocumentPDF";

export default function OneReportPage() {
  const { idReport } = useParams();
  const [infoAboutReport, setInfoAboutReport] = useState(null);
  const [isLoading, setIsLoading] = useState(true);

  const options = {
    year: "numeric",
    month: "2-digit",
    day: "2-digit",
    hour: "2-digit",
    minute: "2-digit",
    second: "2-digit",
  };
  const statusName = {
    0: "Всё в порядке",
    1: "Место не было отсканировано",
    2: "Утеряно", // NotFound
    3: "До истечения срока годности остался месяц", // DateFail
    4: "Срок годности истек", // DateMonth
    5: "Аварийно-спасательное оборудование со скалада", // Archive
  };

  useEffect(() => {
    const getInfoAboutReport = async () => {
      try {
        const response = await getOneReport(idReport);
        setInfoAboutReport(response);
        setIsLoading(false);
      } catch (error) {
        console.error(
          "Какая-то проблема при получении данных об одном отчете:",
          error
        );
      }
    };
    getInfoAboutReport();
  }, [idReport]);

  return (
    <>
      {isLoading ? (
        <div
          style={{
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
            margin: "auto",
          }}
        >
          <Spinner animation="border" variant="primary" />
        </div>
      ) : (
            <ReportPDF
              infoAboutReport={infoAboutReport}
              checkTypes={checkTypes}
              statusName={statusName}
            />
        )
      }
    </>
  );
}
