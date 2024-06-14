import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";
import { Routes, Route } from "react-router-dom";
import Layout from "./components/Layout";
import Homepage from "./pages/HomePage";
import Monitoringpage from "./pages/MonitoringPage";
import MonitoringOnePlane from "./pages/MonitoringOnePlane";
import Reportpage from "./pages/ReportPage";
import OneReportPage from "./pages/OneReportPage";
import Dashboardpage from "./pages/DashboardPage";
import Notfoundpage from "./pages/NotFoundPage";
import LoginPage from "./pages/LoginPage";
import RequireAuth from "./hoc/RequireAuth";
import AuthProvider from "./hoc/AuthProvider";

function App() {
  return (
      <AuthProvider>
        <Routes>
          <Route path="/" element={<Layout />}>
            <Route index element={<Homepage />} />
            <Route element={<RequireAuth />}>
              <Route path="monitor" element={<Monitoringpage />} />
              <Route path="report" element={<Reportpage />} />
              <Route path="dashborad" element={<Dashboardpage />} />
            </Route>
            <Route path="*" element={<Notfoundpage />} />
            <Route path="login" element={<LoginPage />} />
            <Route path="monitor/:idPlane" element={<MonitoringOnePlane />} />
            <Route path="report/:idReport" element={<OneReportPage />} />
          </Route>
        </Routes>
      </AuthProvider>
  );
}

export default App;
