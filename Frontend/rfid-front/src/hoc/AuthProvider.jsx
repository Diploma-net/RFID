import axios from "axios";
import { createContext, useState } from "react";

export const AuthContext = createContext(null);

export default function AuthProvider({ children }) {
  const [userInfo, setUser] = useState([]);
  const [error, setError] = useState();

  const signin = async (login, pass, cb) => {
    const response = await axios
      .post(`https://10.147.17.151:5032/auth/login-and-password`, {
        login: login,
        password: pass,
      })
      .catch((error) => {
        setError(error)
      });
      setUser(response.data)

    localStorage.setItem("user", response.data.userName);
    cb();
  };
  const signout = (cb) => {
    setUser(null);
    localStorage.removeItem("user");
    cb();
  };

  const value = { userInfo, error,  signin, signout };

  return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
}
