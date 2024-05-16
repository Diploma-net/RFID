import { useState } from "react";
import Logo from "./rfid-logo.svg";
import { Link } from "react-router-dom";

export default function Monitoringpage() {
  const [idSearch, setIdSearch] = useState("");
  
  return (
    <>
      <img src={Logo} style={{ width: "25%", alignSelf: "center" }} />
      <div className="search-form">
        <input
          type="text"
          name="search"
          placeholder="Введите название самолета"
          autoComplete="off"
          className="input-search"
          style={{ border: "none" }}
          onChange={(e) => setIdSearch(e.target.value)}
        />
        <Link style={{ border: "none", background: "none" }} to={`${idSearch}`}>
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
    </>
  );
}
