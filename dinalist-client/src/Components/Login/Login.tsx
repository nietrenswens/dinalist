import React, { useState } from "react";

function Login() {
  const [error, setError] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  function handleLogin() {
    if (!email || !password) {
      setError("Please fill in all fields");
      return;
    }
    setError("");
    const API_HOST: string = process.env.REACT_APP_API_URL || "";
    if (API_HOST === "") {
      setError(
        "We are having some technical difficulties. Please try again later."
      );
      return;
    }
    fetch(new URL(API_HOST + "/api/login"), {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ email, password }),
    })
      .then((res) => {
        if (res.status === 401) {
          setError("Invalid email or password");
          return;
        }
        return res.json();
      })
      .then((data) => {
        if (!data) return;
        if (data.error) {
          setError(data.error);
        } else {
          localStorage.setItem("token", data.token.value);
          localStorage.setItem("id", data.user.id);
          // Redirect to the home page
          window.location.href = "/";
        }
      })
      .catch((err) => {
        setError("Can't login at the moment. Please try again");
        console.error(err);
      });
  }
  return (
    <div className="dark:bg-gray-800 bg-white flex h-full">
      <div className="m-auto lg:w-1/5 w-64">
        <h1 className="dark:text-white text-black text-4xl font-bold">
          Dinalist
        </h1>
        <p className="dark:text-gray-50 text-gray-500">Sign in to continue</p>
        {error && <p className="text-red-500">{error}</p>}
        <form>
          <div className="mt-4">
            <label
              htmlFor="email"
              className="block dark:text-white text-black mb-2"
            >
              Email
            </label>
            <input
              type="email"
              name="email"
              id="email"
              onChange={(e) => setEmail(e.target.value)}
              className="dark:bg-gray-800 bg-white w-full dark:text-white text-black border border-blue-300 rounded-md p-2"
            />
          </div>
          <div className="mt-4">
            <label
              htmlFor="password"
              className="block dark:text-white text-black mb-2"
            >
              Password
            </label>
            <input
              type="password"
              name="password"
              id="password"
              onChange={(e) => setPassword(e.target.value)}
              className="w-full border dark:bg-gray-800 bg-white dark:text-white text-black border-blue-300 rounded-md p-2"
            />
          </div>
          <div className="mt-6 text-center">
            <button
              type="submit"
              onClick={handleLogin}
              className="bg-blue-500 text-white w-full rounded-md p-2"
            >
              Sign in
            </button>
          </div>
        </form>
      </div>
    </div>
  );
}

export default Login;
