import React, { useEffect, useState } from "react";
import { Button, Alert } from "react-bootstrap";
import TableForReports from "../components/TableForReports";
import { getReports } from "../api/apiClient";
import Spinner from "react-bootstrap/Spinner";
import {checkTypes} from "../const/checkTypes"

export default function Reportpage() {
  const [searchName, setSearchName] = useState(null);
  const [searchDate, setSearchDate] = useState(null);
  const [searchType, setSearchType] = useState(null);
  const [allReports, setAllReports] = useState(new Map());
  const [isLoading, setIsLoading] = useState(true);
  const [errorMessage, setErrorMessage] = useState("");


  useEffect(() => {
    const getAllRecords = async () => { 
      try { 
        const response = await getReports(searchName, searchDate, checkTypes[searchType]); 
        if(Array.isArray(response) && response.length === 0) {
          setErrorMessage("По запросу данных не найдено");
        } else {
          const newReports = new Map(); 
          for (const [key, value] of Object.entries(response)) { 
            newReports.set(key, value); 
          } 
          setAllReports(newReports); 
        }
        setIsLoading(false); 
      } catch (error) { 
        console.error("Какая-то проблема с поиском отчетов:", error); 
        setIsLoading(false); 
      } 
    };     
    getAllRecords();
  }, []);

  const handleSearch = async () => {
    setIsLoading(true);
    setErrorMessage("")
    try {
      const response = await getReports(searchName, searchDate, checkTypes[searchType]);
      const newReports = new Map();
      for (const [key, value] of Object.entries(response)) {
        newReports.set(key, value);
      }
      setAllReports(newReports);
      setIsLoading(false);
    } catch (error) {
      console.error("Какая-то проблема с поиском отчетов:", error);
      setErrorMessage("Неправильно введены данные");
      setAllReports(new Map());
      setIsLoading(false);
    }
  }


  const handleSearchName = (e) => {
    setSearchName(e.target.value !== "" ? e.target.value : null);
  };

  const handleSearchDate = (e) => {
    setSearchDate(e.target.value !== "" ? e.target.value : null);
  };

  const handleSearchType = (e) => {
    setSearchType(e.target.value !== "" ? e.target.value : null);
  };

  return (
    <>
      <div className="search-forms">
        <div className="search-form-report">
          <input
            type="text"
            name="searchName"
            placeholder="Введите название самолета"
            autoComplete="off"
            className="input-search"
            style={{ border: "none" }}
            onChange={handleSearchName}
          />
        </div>
        <div className="search-form-report">
          <input
            type="text"
            name="searchDate"
            placeholder="Введите дату проверки"
            autoComplete="off"
            className="input-search"
            style={{ border: "none" }}
            onChange={handleSearchDate}
          />
        </div>
        <div className="search-form-report">
          <input
            type="text"
            name="searchType"
            placeholder="Введите тип проверки"
            autoComplete="off"
            className="input-search"
            style={{ border: "none" }}
            onChange={handleSearchType}
          />
        </div>
        <Button
          onClick={handleSearch}
          style={{
            height: "50px",
            width: "100px",
            alignSelf: "center",
            padding: "5px",
            fontSize: "x-large",
          }}
        >
          Поиск
        </Button>
      </div>
      {errorMessage && <Alert variant="danger" style={{marginTop: "20px"}}>{errorMessage}</Alert>}
      {isLoading && errorMessage === "" ? (
        <div
          style={{
            display: "flex",
            justifyContent: "center",
            alignItems: "center",
            margin: "auto"
          }}
        >
          <Spinner animation="border" variant="primary" style={{marginRight: "20px"}}/>
        </div>
      ) : (
        allReports.size !== 0 && (
          <TableForReports
            data={allReports}
            textForButton={"Перейти к отчету"}
          />
        )
      )}
    </>
  );
}
