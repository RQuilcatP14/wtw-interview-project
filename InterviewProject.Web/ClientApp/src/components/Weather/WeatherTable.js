import React from "react";
import formatDate from "../../utils/formatDate";

const WeatherTable = ({ forecasts }) => {
  return (
    <table className="table table-striped mt-4">
      <thead>
        <tr>
          <th>Date</th>
          <th>Temperature (°C)</th>
        </tr>
      </thead>
      <tbody>
        {forecasts.map((forecast, index) => (
          <tr key={index}>
            <td>{formatDate(forecast.dt_txt)}</td>
            <td>{forecast.main.temp}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
};

export default WeatherTable;