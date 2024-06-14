import React, { useEffect, useState } from "react";
import ZingChart from "zingchart";

const BarChart = ({ data }) => {
  const [config, setConfig] = useState(null);

  useEffect(() => {
    const config = {
      type: "bar",
      plotarea: {
        margin: "dynamic",
      },
      title: {
        text: "Статистика отсканированного АСО за 2023 г.",
        backgroundColor: "none",
        fontSize: "22px",
        alpha: 1,
        adjustLayout: true,
      },
      plot: {
        barsSpaceLeft: 0.15,
        barsSpaceRight: 0.15,
        tooltip: {
          text: "%v штук",
          thousandsSeparator: " ",
          align: "left",
          borderRadius: "3px",
          decimals: 0,
          fontColor: "#ffffff",
        },
        valueBox: [
          {
            text: "%v",
            thousandsSeparator: " ",
            fontColor: "#666666",
            rules: [
              {
                rule: "%v > 10000",
                visible: false,
              },
            ],
          },
          {
            text: "%v",
            thousandsSeparator: " ",
            placement: "middle",
            fontColor: "#ffffff",
            rules: [
              {
                rule: "%v <= 10000",
                visible: false,
              },
            ],
          },
        ],
      },
      series: [
        {
          values: data,
          backgroundColor: "#1715ab",
          borderColor: "#000000",
        },
      ],
      scaleY: {
        format: "%v",
        values: "0:5000:300",
        guide: {
          visible: true,
        },
      },
      scaleX: {
        labels: [
          "Проблем не обнаружено",
          "Утеряно",
          "Истек срок годности",
          "Годен еще месяц",
          "На складе",
        ],
      },
    };
    setConfig(config);
  }, []);

  useEffect(() => {
    if (config) {
      ZingChart.render({
        id: "chart-container-bar",
        data: config,
        height: 400,
        width: "100%",
      });
    }
  }, [config]);

  return (
    <div id="chart-container-bar">
      {" "}
      <a
        className="zc-ref"
        href="https://www.zingchart.com/"
        style={{ display: "none" }}
      >
        Charts by ZingChart
      </a>
    </div>
  );
};

export default BarChart;
