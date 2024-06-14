import { useLocation, useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { postStartMonitoring } from "../api/apiClient";
import { containerSvgPlane, planePlaces } from "../const/plane";
import { SvgPlane } from "../components/SvgPlane";
import TableForMonitorinOnePlane from "../components/TableForBadEquipment";
import { HubConnectionBuilder, LogLevel } from "@microsoft/signalr";

export default function MonitoringOnePlane() {
  const { idPlane } = useParams();
  const [idSearch, setIdSearch] = useState("");
  const location = useLocation();

  const initPlaneStatuses = () => {
    const statuses = new Map();
    for (const place of planePlaces) {
      statuses.set(place.id, "1");
    }
    return statuses;
  };

  const [placeStatuses, setPlaceStatuses] = useState(initPlaneStatuses);

  const handleSocketUpdate = (updatedSeatStatus) => {
    const placeId = Object.keys(updatedSeatStatus).join('');
    const status = Object.values(updatedSeatStatus).join('');
    updatePlaceStatus(placeId, status);
  };

  const updatePlaceStatus = (placeId, status) => {
    placeStatuses.delete(placeId)
    placeStatuses.set(placeId, status);
    setPlaceStatuses(new Map(placeStatuses));
  };

  const startMonitoring = async () => {
    try {
      const response = await postStartMonitoring(idPlane);
      for (const [key, value] of Object.entries(response)) {
        placeStatuses.set(key, value);
      }
      setPlaceStatuses(new Map(placeStatuses));
    } catch (error) {
      console.error("Какая-то проблема с началом мониторинга:", error);
    }
  };

  const updateByHub = async () => {
    try {
      const conn = new HubConnectionBuilder()
        .withUrl("https://10.147.17.151:5032/hub")
        .configureLogging(LogLevel.Information)
        .build();
      conn.on("JoinInMonitoringPlane");
      conn.on("Handle", () => {
        handleSocketUpdate(massages);
      });
      await conn.start();
      await conn.invoke("JoinInMonitoringPlane");
    } catch (error) {
      console.log("Проблема с веб-сокетом:", error);
    }
  };

  useEffect(() => {
    initPlaneStatuses();
    startMonitoring();
    updateByHub();
  }, [idPlane]);

  const fromPage = location.pathname;
  const newUrl = fromPage.split("/").slice(0, 2).join("/");

  return (
    <>
      <div className="search-form">
        <input
          type="text"
          name="search"
          placeholder="Введите название другого самолета"
          autoComplete="off"
          className="input-search"
          style={{ border: "none" }}
          onChange={(e) => setIdSearch(e.target.value)}
        />
        <Link
          style={{ border: "none", background: "none" }}
          to={`${newUrl}` + "/" + `${idSearch}`}
        >
          <svg
            className="fas fa-search"
            width="26"
            height="26"
            viewBox="0 0 26 26"
            fill="none"
            xmlns="http://www.w3.org/2000/svg"
          >
            <rect
              x="19.5138"
              y="18.5495"
              width="8"
              height="2"
              transform="rotate(45 19.5138 18.5495)"
              style={{ fill: "#000" }}
            />
            <circle
              cx="11.5"
              cy="11.5"
              r="10.5"
              style={{ stroke: "#000", strokeWidth: "2" }}
            />
          </svg>
        </Link>
      </div>
      <h2 style={{ alignSelf: "center", marginTop: "18px" }}>
        Мониторинг самолета "{idPlane}"
      </h2>
      <div className="containerSvgPlane" style={containerSvgPlane}>
        <SvgPlane placeStatuses={placeStatuses} />
      </div>
      <div
        className="containerTable"
        style={{
          width: "80%",
          margin: "5px auto",
        }}
      >
        <div style={{ textAlign: "center", fontSize: "x-large" }}>
          Список проблем аварийно-спасательного оборудования самолета "{idPlane}
          "
        </div>
        <TableForMonitorinOnePlane data={placeStatuses} />
      </div>
    </>
  );
}
