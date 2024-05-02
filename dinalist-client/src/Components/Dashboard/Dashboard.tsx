import React from "react";

function Dashboard() {
  return (
    <div className="dark:bg-gray-800 bg-white flex h-full w-full">
      <div className="m-auto">
        <h1 className="dark:text-white text-center text-black text-4xl font-bold">
          Dinalist
        </h1>
        <h2 className="dark:text-gray-50 text-gray-500 text-2xl mb-4">
          Welcome to Dinalist! What is your next step:
        </h2>
        <div className="w-full flex justify-center gap-x-4">
          <button className="text-white p-6 font-semibold bg-green-400 rounded-md">
            Make a diningroom
          </button>
          <button className="text-white p-6 font-semibold bg-blue-400 rounded-md">
            Join a diningroom
          </button>
        </div>
      </div>
    </div>
  );
}

export default Dashboard;
