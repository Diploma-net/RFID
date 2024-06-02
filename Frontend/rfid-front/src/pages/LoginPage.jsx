import { useState, useEffect } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import useAuth from "../hook/useAuth";
import FloatingLabel from "react-bootstrap/FloatingLabel";
import Form from "react-bootstrap/Form";
import { Button, Alert } from "react-bootstrap";

export default function LoginPage() {
  const navigate = useNavigate();
  const location = useLocation();
  const { signin, error } = useAuth();
  const [errorMassage, setErrorMassage] = useState("");

  const fromPage = location.state?.from?.pathname || "/";

  useEffect(() => {
    if (error) {
      setErrorMassage("Логин или пароль неверные. Пожалуйста, попробуйте снова.");
    } else {
      setErrorMassage("");
    }
  }, [error]);

  const handleSubmit = (event) => {
    event.preventDefault();
    const form = event.target;
    const user = form.username.value;
    const password = form.password.value;

    signin(user, password, () => navigate(fromPage, { replace: true }));
  };

  return (
    <div className="container-login">
      <div className="title-holder">
        <h1>Добро пожаловать!</h1>
        <div className="subtitle">
          <p>
            Введите свой логин и пароль или запросить их у администратора системы
          </p>
        </div>
      </div>
      {errorMassage && <Alert variant="danger">{errorMassage}</Alert>}
      <form onSubmit={handleSubmit} style={{ width: "70%", alignSelf: "center" }}>
        <FloatingLabel controlId="username" label="Логин" className="mb-3">
          <Form.Control type="text" placeholder="name@example.com" required />
        </FloatingLabel>
        <FloatingLabel controlId="password" label="Пароль">
          <Form.Control type="password" placeholder="Password" required />
        </FloatingLabel>
        <div className="button-div">
          <Button type="submit">Войти &#8594;</Button>
        </div>
      </form>
    </div>
  );
}
