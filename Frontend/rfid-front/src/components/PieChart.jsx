import React, { useEffect, useState } from "react";
import ZingChart from "zingchart";

const PieChart = ({ data, info }) => {
  const [chartConfig, setChartConfig] = useState(null);

  useEffect(() => {
    const config = {
      type: "ring",
      title: {
        text: "Потери по всем видам АСО за 2023 г.",
        fontSize: 20,
        alpha: 1,
        adjustLayout: true,
      },
      plot: {
        slice: 50,
        valueBox: {
          placement: "out",
          text: "%t\n%npv%",
          fontFamily: "Open Sans",
        },
        tooltip: {
          fontSize: "15",
          fontFamily: "Open Sans",
          padding: "5 10",
          text: "%t было утеряно: %v штук",
        },
        animation: {
          effect: 2,
          method: 5,
          speed: 900,
          sequence: 1,
          delay: 3000,
        },
      },
      plotarea: {
        margin: "0 0 0 0",
      },
      series: data.map((item) => ({
        text: item.label,
        values: [item.value],
        backgroundColor: item.color,
      })),
    };
    setChartConfig(config);
  }, [data, info]);

  useEffect(() => {
    if (chartConfig) {
      ZingChart.render({
        id: "chart-container",
        data: chartConfig,
        height: "400px",
        width: "700px",
      });
    }
  }, [chartConfig]);

  return (
    <div id="chart-container" style={{ width: "100%", display: "flex",
    flexDirection: "row",
    alignItems: "center",
    justifyContent: "space-between" }}>
      <a
        className="zc-ref"
        href="https://www.zingchart.com/"
        style={{ display: "none" }}
      >
        Charts by ZingChart
      </a>
      <div className="infoArea" >
        <h4>Общая информация, сформированная за 2023 год</h4>
        <div>Всего оборудования отсканировано: {info[0]}</div>
        <div>Всего самолетов проверено: {info[1]}</div>
        <div>Всего сформировано отчетов: {info[2]}</div>
        <div>
          Среднее время проведения полной проверки самолета: 00:35:45
        </div>
      </div>
    </div>
  );
};

export default PieChart;
