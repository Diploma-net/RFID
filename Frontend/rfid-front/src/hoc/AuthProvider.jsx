import { createContext, useState } from "react";
import { postSignIn } from "../api/apiClient"

export const AuthContext = createContext(null);

export default function AuthProvider({ children }) {
  const [userInfo, setUser] = useState("");
  const [error, setError] = useState();

  const signin = async (login, pass, cb) => {
    try{
      const response = await postSignIn(login, pass)
      setUser(response)
      localStorage.setItem("user", response.userName);
    } catch (error){
      setError(error)
    }
         
    cb();
  };
  const signout = (cb) => {
    setUser("");
    localStorage.removeItem("user");
    cb();
  };

  const value = { userInfo, error,  signin, signout };

  return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
}
