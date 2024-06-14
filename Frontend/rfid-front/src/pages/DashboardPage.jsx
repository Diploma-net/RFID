import { useEffect, useState } from "react";
import PieChart from "../components/PieChart";
import { getAnalisticData } from "../api/apiClient";
import LineChart from "../components/LineChart";
import BarChart from "../components/BarChart";
import Spinner from "react-bootstrap/Spinner";

export default function Dashboardpage() {
  const [infoAnalistic, setInfoAnalistic] = useState(null);
  const [dataRing, setDataRing] = useState([]);
  const [dataBar, setDataBar] = useState([]);
  const [dataInfo, setDataInfo] = useState([]);
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    const getInfoAnalistic = async () => {
      try {
        const response = await getAnalisticData();
        setInfoAnalistic(response);
      } catch (error) {
        console.error(
          "Какая-то проблема при получении данных аналитики:",
          error
        );
      }
    };

    getInfoAnalistic();
  }, []);

  useEffect(() => {
    if (infoAnalistic) {
      setDataRing([
        {
          label: "Огнетушители",
          value: infoAnalistic.equipAnalytic.equipTypeLost.fireExtinguisherLost,
          color: "#1715ab",
        },
        {
          label: "Информационные карточки",
          value: infoAnalistic.equipAnalytic.equipTypeLost.informationCardLost,
          color: "#42aaff",
        },
        {
          label: "Кислородные маски",
          value: infoAnalistic.equipAnalytic.equipTypeLost.oxygenMaskLost,
          color: "#87cefa",
        },
      ]);
      setDataBar([
        infoAnalistic.equipAnalytic.statusAnalytic.ok,
        infoAnalistic.equipAnalytic.statusAnalytic.notFound,
        infoAnalistic.equipAnalytic.statusAnalytic.dateFail,
        infoAnalistic.equipAnalytic.statusAnalytic.dateMonth,
        infoAnalistic.equipAnalytic.statusAnalytic.arсhive,
      ]);
      setDataInfo([
        infoAnalistic.equipAnalytic.count,
        infoAnalistic.planeAnalytic.count,
        infoAnalistic.reportAnalytic.count,
        infoAnalistic.reportAnalytic.averageTimeReport,
      ]);
      setIsLoading(false);
    }
  }, [infoAnalistic]);

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
        <div className="all-charts-conteiner">
          <PieChart data={dataRing} info={dataInfo} />
          <LineChart />
          <BarChart data={dataBar} />
        </div>
      )}
    </>
  );
}