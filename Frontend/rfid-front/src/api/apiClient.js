import axios from "axios";

const apiClient = axios.create({
  baseURL: "https://10.147.17.151:5032",
});

export const postStartMonitoring = async (planeName) => {
  const response = await apiClient
    .post("/plane/start-monitoring", { planeName: planeName })
    .catch((error) => {
      console.error(
        "Какая-то проблема с получение данных о мониторинге: ",
        error
      );
    });
  return response.data;
};

export const postSignIn = async (login, pass) => {
  const response = await apiClient
    .post(`/auth/login-and-password`, {
      login: login,
      password: pass,
    })
    .catch((error) => {
      console.error("Проблема с логином и паролем: ", error);
    });
  return response.data;
};

export const getMonitoringAllPlane = async () => {
  const responce = await apiClient
    .get("/report/get-reports", {
      params: {
        reportResult: true,
      },
    })
    .catch((error) => {
      console.error(
        "Какая-то проблема с получением всех самолетов по мониторингу: ",
        error
      );
    });
  return responce.data;
};

export const getReports = async (planeName, reportDate, reportType) => {
  const responce = await apiClient
    .get("/report/get-reports", {
      params: {
        reportResult: false,
        planeName: planeName,
        reportDate: reportDate,
        reportType: reportType,
      },
    })
    .catch((error) => {
      console.error("Какая-то проблема с получением всех отчетов: ", error);
    });
  return responce.data;
};

export const getOneReport = async (idReport) => {
  const responce = await apiClient
    .get("/report/get-report", {
      params: {
        idReport: idReport,
      },
    })
    .catch((error) => {
      console.error("Какая-то проблема с получением данных по отчету: ", error);
    });
  return responce.data;
};

export const getAnalisticData = async () => {
  const responce = await apiClient
    .get("/analytic/global-analytic")
    .catch((error) => {
      console.log(
        "Какая-то проблема с получением данных для аналитики: ",
        error
      );
    });
  return responce.data;
};
