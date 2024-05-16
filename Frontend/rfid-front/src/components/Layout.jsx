import { Outlet } from "react-router-dom";
import AppHeader from './Header'

export default function Layout() {
  return (
    <>
      <header id="header">
        <AppHeader />
      </header>

      <main className="container">
        <Outlet />
      </main>
    </>
  );
}
