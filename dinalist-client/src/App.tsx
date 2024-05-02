import React from "react";
import Login from "./Components/Login/Login";

function App() {
  if (localStorage.getItem("token")) {

    // Check token validity
    
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
