import React from "react";

const SearchBar = ({ city, setCity, onSearch }) => {
  return (
    <div className="d-flex justify-content-center align-items-center gap-3 mt-3">
      <input
        type="text"
        className="form-control"
        style={{ width: "300px", height: "50px", marginRight: "10px" }}
        placeholder="Enter city"
        value={city}
        onChange={(e) => setCity(e.target.value)}
      />
      <button className="btn btn-primary btn-lg" onClick={onSearch}>
        Search
      </button>
    </div>
  );
};

export default SearchBar;
