import React, { useState, useEffect } from "react";
import ZingChart from "zingchart";

const LineChart = () => {
  const [config, setConfig] = useState(null);

  useEffect(() => {
    const chartConfig = {
      type: "line",
      utc: true,
      title: {
        text: "Затраты на АСО за 2023 год",
        fontSize: 20,
        textAlign: "center",
        adjustLayout: true,
      },
      plotarea: {
        margin: "dynamic 45 60 dynamic",
      },
      legend: {
        layout: "float",
        backgroundColor: "none",
        borderWidth: 0,
        shadow: 0,
        align: "center",
        adjustLayout: true,
        toggleAction: "remove",
        item: {
          padding: 7,
          marginRight: 17,
          cursor: "hand",
        },
      },
      scaleX: {
        values: [
            'Январь', 'Февраль', 'Март', 'Апрель', 'Май', 'Июнь', 'Июль', 'Август', 'Сентябрь', 'Октябрь', 'Ноябрь', 'Декабрь'
        ],
        shadow: 0,
        step: "auto",
        label: {
          visible: false,
        },
        minorTicks: 0,
      },

      scaleY: {
        lineColor: "#f6f7f8",
        shadow: 0,
        guide: {
          lineStyle: "dashed",
        },
        label: {
          text: "Рублей, тыс",
        },
        minorTicks: 0,
        thousandsSeparator: ",",
      },
      crosshairX: {
        lineColor: "#efefef",
        plotLabel: {
          borderRadius: "5px",
          borderWidth: "1px",
          borderColor: "#f6f7f8",
          padding: "10px",
          fontWeight: "bold",
        },
        scaleLabel: {
          fontColor: "#000",
          backgroundColor: "#f6f7f8",
          borderRadius: "5px",
        },
      },
      tooltip: {
        visible: false,
      },

      plot: {
        highlight: true,
        tooltipText: "%t views: %v<br>%k",
        shadow: 0,
        lineWidth: "2px",
        marker: {
          type: "circle",
          size: 3,
        },
        highlightState: {
          lineWidth: 3,
        },
        animation: {
          effect: 1,
          sequence: 2,
          speed: 100,
        },
      },
      series: [
        {
          values: [
            149.2, 174.3, 187.7, 147.1, 129.6, 189.6, 230, 164.5, 171.7, 163.4,
            194.5, 200.1, 193.4,
          ],
          text: "Информационные карточки",
          lineColor: "#42aaff",
          legendItem: {
            backgroundColor: "#42aaff",
            borderRadius: 5,
            fontColor: "white",
          },
          legendMarker: {
            visible: false,
          },
          marker: {
            backgroundColor: "#42aaff",
            borderWidth: 1,
            shadow: 0,
            borderColor: "white",
          },
          highlightMarker: {
            size: 6,
            backgroundColor: "#42aaff",
          },
        },
        {
          values: [
            714.6, 656.3, 660.6, 729.8, 731.6, 682.3, 654.6, 673.5, 700.6,
            755.2, 817.8, 809.1, 815.2, 836.6,
          ],
          text: "Кислородные маски",
          lineColor: "#87cefa",
          legendItem: {
            backgroundColor: "#87cefa",
            borderRadius: 5,
            fontColor: "white",
          },
          legendMarker: {
            visible: false,
          },
          marker: {
            backgroundColor: "#87cefa",
            borderWidth: 1,
            shadow: 0,
            borderColor: "white",
          },
          highlightMarker: {
            size: 6,
            backgroundColor: "#87cefa",
          },
        },
        {
          values: [
            536.9, 576.4, 639.3, 669.4, 708.7, 691.5, 681.7, 673, 701.8, 636.4,
            637.8, 640.5, 653.1,
          ],
          text: "Огнетушители",
          lineColor: "#1715ab",
          legendItem: {
            backgroundColor: "#1715ab",
            borderRadius: 5,
            fontColor: "white",
          },
          legendMarker: {
            visible: false,
          },
          marker: {
            backgroundColor: "#1715ab",
            borderWidth: 1,
            shadow: 0,
            borderColor: "white",
          },
          highlightMarker: {
            size: 6,
            backgroundColor: "#1715ab",
          },
        },
      ],
    };

    setConfig(chartConfig);
  }, []);

  useEffect(() => {
    if (config) {
      ZingChart.render({
        id: "line-chart",
        data: config,
      });
    }
  }, [config]);

  return (
    <div id="line-chart" style={{ width: "100%", height: "500px" }}>
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

export default LineChart;
