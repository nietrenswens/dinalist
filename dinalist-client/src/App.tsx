import React from "react";
import Login from "./Components/Login/Login";

function checkToken(token: string) {
  const API_HOST: string = process.env.REACT_APP_API_URL || "";
  fetch(API_HOST + "/api/login/istokenvalid", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ token }),
  })
    .then((res) => res.json())
    .then((data) => {
      if (!data.isvalid) {
        return false;
      }
      return true;
    }).catch((err) => {
      console.error(err);
    });
  return false;
}

function App() {
  const token = localStorage.getItem("token");
  if (token !== null) {
    if (!checkToken(token))
    {
      localStorage.removeItem("token");
      localStorage.removeItem("id");
      window.location.href = "/";
      return;
    }
    return (
      <div className="h-screen">
        <h1>Logged in</h1>
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
