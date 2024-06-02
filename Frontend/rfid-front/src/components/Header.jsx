import { Button } from "react-bootstrap";
import Offcanvas from "react-bootstrap/Offcanvas";
import Container from "react-bootstrap/Container";
import Nav from "react-bootstrap/Nav";
import Navbar from "react-bootstrap/Navbar";
import { NavLink, Link } from "react-router-dom";
import { useNavigate } from "react-router-dom";
import useAuth from "../hook/useAuth";

export default function AppHeader() {
  const navigate = useNavigate();
  const { userInfo } = useAuth();
  const { signout } = useAuth();

  let loginButton;
  let userMessage;

  if (!userInfo) {
    loginButton = (
      <Button
        onClick={() => navigate("/login", { replace: true })}
        style={{ height: "35px", alignSelf: "center" }}
      >
        Войти в систему
      </Button>
    );
  } else {
    loginButton = (
      <Button
        onClick={() => signout(() => navigate("/", { replace: true }))}
        style={{ height: "35px", alignSelf: "center" }}
      >
        Выйти
      </Button>
    );

    userMessage = userInfo.userName && (
     <p
        style={{ margin: "0 10px 0 0", alignSelf: "center", fontSize: "18px" }}
      >
        Вы вошли как {userInfo.userName.split(' ')[1]}
      </p>
    );
  }
  return (
    <>
      <Navbar expand="lg" className="bg-body-tertiary">
        <Container fluid>
          <Navbar.Brand>RFLOT</Navbar.Brand>
          <Navbar.Toggle aria-controls={`offcanvasNavbar-expand-lg`} />
          <Navbar.Offcanvas
            id={`offcanvasNavbar-expand-lg`}
            aria-labelledby={`offcanvasNavbarLabel-expand-lg`}
            placement="end"
          >
            <Offcanvas.Header closeButton>
              <Offcanvas.Title id={`offcanvasNavbarLabel-expand-lg`}>
                Меню
              </Offcanvas.Title>
            </Offcanvas.Header>
            <Offcanvas.Body>
              <Nav className="justify-content-start flex-grow-1 pe-3">
                <NavLink to="/">Главная</NavLink>
                <NavLink to="/monitor">Мониторинг</NavLink>
                <NavLink to="/report">Отчеты о проверках</NavLink>
                <NavLink to="/dashborad">Дашборды</NavLink>
              </Nav>
              <div
                style={{
                  display: "flex",
                  flexDirection: "row",
                  alignItems: "center",
                }}
              >
                {userMessage}
                {loginButton}
              </div>
            </Offcanvas.Body>
          </Navbar.Offcanvas>
        </Container>
      </Navbar>
    </>
  );
}
