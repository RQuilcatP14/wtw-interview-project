import React, { useState } from "react";
import SearchBar from "../SearchBar/SearchBar";
import WeatherTable from "./WeatherTable";
import Backdrop from "../Backdrop/Backdrop"

const Weather = () => {
  const [city, setCity] = useState("");
  const [forecasts, setForecasts] = useState([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState("");

  const fetchWeatherData = async () => {
    setLoading(true);
    setError("");
    try {
      const response = await fetch(`api/weather/${city}`);

      if (response.status === 204) {
        setForecasts([]);
        setError("Data Not Found");
      } else {
        const data = await response.json();
        setForecasts(data.list || []);
      }

      setCity("");
    } catch (error) {
      console.error("Error fetching weather data:", error);
      setError("An error occurred. Please try again.");
    }
    setLoading(false);
  };

  return (
    <div className="container mt-4">
      <SearchBar city={city} setCity={setCity} onSearch={fetchWeatherData} />
      {loading && <Backdrop />}
      {error && <h2 className="text-center mt-3 text-danger"><b>{error}</b></h2>}
      {forecasts.length > 0 && <WeatherTable forecasts={forecasts} />}
    </div>
  );
};

export default Weather;
