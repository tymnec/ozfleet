import React, { useEffect, useState } from "react";
import apiClient from "../apiClient";

const VehicleList = () => {
  const [vehicles, setVehicles] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    // Example API call to fetch vehicles
    apiClient
      .get("/api/Vehicle")
      .then((response) => {
        setVehicles(response.data);
        setLoading(false);
      })
      .catch((err) => {
        setError(err.message || "Error fetching vehicles");
        setLoading(false);
      });
  }, []);

  if (loading) return <div>Loading vehicles...</div>;
  if (error) return <div>Error: {error}</div>;

  return (
    <div>
      <h1>Fleet Vehicles</h1>
      <ul>
        {vehicles.map((vehicle) => (
          <li key={vehicle.id}>
            {vehicle.make} {vehicle.model} ({vehicle.year})
          </li>
        ))}
      </ul>
    </div>
  );
};

export default VehicleList;
