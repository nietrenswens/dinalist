import React, { useEffect, useState } from "react";
import Login from "./Components/Login/Login";
import Dashboard from "./Components/Dashboard/Dashboard";

async function checkToken(token: string) {
  const API_HOST: string = process.env.REACT_APP_API_URL || "";
  const response = await fetch(API_HOST + "/api/login/istokenvalid", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ token }),
  });
  const data = await response.json();
  if (!data) return false;
  return data.isValid;
}

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const token = localStorage.getItem("token");

  useEffect(() => {
    const validateToken = async () => {
      if (token !== null) {
        const isTokenValid = await checkToken(token);
        setIsLoggedIn(isTokenValid);
        if (!isTokenValid) {
          localStorage.removeItem("token");
          localStorage.removeItem("id");
          window.location.href = "/";
        }
      }
    };
    validateToken();
  }, [token]);

    if (isLoggedIn) {
      return (
        <div className="h-screen">
          <Dashboard />
        </div>
      );
    }
    return (
      <div className="h-screen">
        <Login />
      </div>
    );
}

export default App;
