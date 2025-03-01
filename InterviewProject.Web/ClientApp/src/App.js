import React from "react";
import Weather from "./components/Weather/Weather";
import Navbar from "./components/NavBar/NavBar";

const App = () => {
  return (
    <div>
      <Navbar />
      <Weather />
    </div>
  );
};

export default App;
