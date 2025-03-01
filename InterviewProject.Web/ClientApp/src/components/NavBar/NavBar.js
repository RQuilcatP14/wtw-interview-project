import React from "react";
import "./NavBar.css";

const Navbar = () => {
  return (
    <nav className="d-flex align-items-center p-3" style={{ justifyContent: "start" }}>
      <img src="https://upload.wikimedia.org/wikipedia/commons/e/e9/Logo_WTW.png" alt="Company Logo" className="logo" />
      <h3 className="m-0"><b>Interview Weather Forecast Project</b></h3>
    </nav>
  );
};

export default Navbar;
