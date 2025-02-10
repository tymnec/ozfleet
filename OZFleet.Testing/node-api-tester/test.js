const axios = require("axios");

// Set the base URL for your API (change as needed)
const baseURL = process.env.BASE_URL || "http://localhost:5192";

/**
 * Helper function to check if a response status is acceptable.
 * Acceptable statuses vary depending on the operation:
 * - GET: [200, 204]
 * - POST: [200, 201, 204]
 * - PUT: [200, 204]
 * - DELETE: [200, 204]
 */
function isAllowedStatus(actual, allowedStatuses) {
  return allowedStatuses.includes(actual);
}

// =====================
// Test for Driver API
// =====================
async function testDriver() {
  let results = { passed: 0, failed: 0 };
  console.log("\n--- Testing Driver Endpoints ---");

  // GET all drivers
  try {
    const res = await axios.get(`${baseURL}/api/Driver`);
    if (isAllowedStatus(res.status, [200, 204])) {
      console.log(`GET /api/Driver: PASS (${res.status})`);
      results.passed++;
    } else {
      console.log(`GET /api/Driver: FAIL (${res.status})`);
      results.failed++;
    }
  } catch (error) {
    console.log("GET /api/Driver: FAIL", error.message);
    results.failed++;
  }

  // POST a new driver
  let createdDriver = null;
  try {
    const driverData = {
      name: "Test Driver",
      licenseNumber: "DRIVER123",
      licenseExpiry: "2026-12-31T00:00:00Z",
    };
    const res = await axios.post(`${baseURL}/api/Driver`, driverData);
    if (isAllowedStatus(res.status, [200, 201, 204])) {
      console.log(`POST /api/Driver: PASS (${res.status})`);
      createdDriver = res.data;
      if (!createdDriver || !createdDriver.id) {
        console.warn(
          "POST /api/Driver returned no content. Subsequent tests may be skipped."
        );
      }
      results.passed++;
    } else {
      console.log(`POST /api/Driver: FAIL (${res.status})`);
      results.failed++;
    }
  } catch (error) {
    console.log("POST /api/Driver: FAIL", error.message);
    results.failed++;
  }

  // GET driver by id
  if (createdDriver && createdDriver.id) {
    try {
      const res = await axios.get(`${baseURL}/api/Driver/${createdDriver.id}`);
      if (isAllowedStatus(res.status, [200, 204])) {
        console.log(
          `GET /api/Driver/${createdDriver.id}: PASS (${res.status})`
        );
        results.passed++;
      } else {
        console.log(
          `GET /api/Driver/${createdDriver.id}: FAIL (${res.status})`
        );
        results.failed++;
      }
    } catch (error) {
      console.log(`GET /api/Driver/${createdDriver.id}: FAIL`, error.message);
      results.failed++;
    }
  } else {
    console.log("GET /api/Driver/{id}: SKIPPED (no created driver)");
  }

  // PUT (update) driver by id
  if (createdDriver && createdDriver.id) {
    try {
      const updatedData = { ...createdDriver, name: "Updated Test Driver" };
      const res = await axios.put(
        `${baseURL}/api/Driver/${createdDriver.id}`,
        updatedData
      );
      if (isAllowedStatus(res.status, [200, 204])) {
        console.log(
          `PUT /api/Driver/${createdDriver.id}: PASS (${res.status})`
        );
        results.passed++;
      } else {
        console.log(
          `PUT /api/Driver/${createdDriver.id}: FAIL (${res.status})`
        );
        results.failed++;
      }
    } catch (error) {
      console.log(`PUT /api/Driver/${createdDriver.id}: FAIL`, error.message);
      results.failed++;
    }
  } else {
    console.log("PUT /api/Driver/{id}: SKIPPED (no created driver)");
  }

  // DELETE driver by id
  if (createdDriver && createdDriver.id) {
    try {
      const res = await axios.delete(
        `${baseURL}/api/Driver/${createdDriver.id}`
      );
      if (isAllowedStatus(res.status, [200, 204])) {
        console.log(
          `DELETE /api/Driver/${createdDriver.id}: PASS (${res.status})`
        );
        results.passed++;
      } else {
        console.log(
          `DELETE /api/Driver/${createdDriver.id}: FAIL (${res.status})`
        );
        results.failed++;
      }
    } catch (error) {
      console.log(
        `DELETE /api/Driver/${createdDriver.id}: FAIL`,
        error.message
      );
      results.failed++;
    }
  } else {
    console.log("DELETE /api/Driver/{id}: SKIPPED (no created driver)");
  }

  // Negative test: GET non-existent driver
  try {
    const nonExistentId = 999999;
    await axios.get(`${baseURL}/api/Driver/${nonExistentId}`);
    console.log(`GET /api/Driver/${nonExistentId}: FAIL (unexpected success)`);
    results.failed++;
  } catch (error) {
    if (error.response && error.response.status === 404) {
      console.log(`GET /api/Driver/999999: PASS (404 as expected)`);
      results.passed++;
    } else {
      console.log(`GET /api/Driver/999999: FAIL`, error.message);
      results.failed++;
    }
  }

  return results;
}

// ========================
// Test for FuelRecord API
// ========================
async function testFuelRecord() {
  let results = { passed: 0, failed: 0 };
  console.log("\n--- Testing FuelRecord Endpoints ---");

  // GET all fuel records
  try {
    const res = await axios.get(`${baseURL}/api/FuelRecord`);
    if (isAllowedStatus(res.status, [200, 204])) {
      console.log(`GET /api/FuelRecord: PASS (${res.status})`);
      results.passed++;
    } else {
      console.log(`GET /api/FuelRecord: FAIL (${res.status})`);
      results.failed++;
    }
  } catch (error) {
    console.log("GET /api/FuelRecord: FAIL", error.message);
    results.failed++;
  }

  // POST a new fuel record
  let createdFuelRecord = null;
  try {
    // Assuming vehicleId: 1 and driverId: 1 exist in your system
    const fuelRecordData = {
      vehicleId: 1,
      driverId: 1,
      fuelDate: "2025-01-01T00:00:00Z",
      fuelAmount: 50.0,
      cost: 100.0,
      odometerReading: 1000.0,
    };
    const res = await axios.post(`${baseURL}/api/FuelRecord`, fuelRecordData);
    if (isAllowedStatus(res.status, [200, 201, 204])) {
      console.log(`POST /api/FuelRecord: PASS (${res.status})`);
      createdFuelRecord = res.data;
      if (!createdFuelRecord || !createdFuelRecord.id) {
        console.warn(
          "POST /api/FuelRecord returned no content. Subsequent tests may be skipped."
        );
      }
      results.passed++;
    } else {
      console.log(`POST /api/FuelRecord: FAIL (${res.status})`);
      results.failed++;
    }
  } catch (error) {
    console.log("POST /api/FuelRecord: FAIL", error.message);
    results.failed++;
  }

  // GET fuel record by id
  if (createdFuelRecord && createdFuelRecord.id) {
    try {
      const res = await axios.get(
        `${baseURL}/api/FuelRecord/${createdFuelRecord.id}`
      );
      if (isAllowedStatus(res.status, [200, 204])) {
        console.log(
          `GET /api/FuelRecord/${createdFuelRecord.id}: PASS (${res.status})`
        );
        results.passed++;
      } else {
        console.log(
          `GET /api/FuelRecord/${createdFuelRecord.id}: FAIL (${res.status})`
        );
        results.failed++;
      }
    } catch (error) {
      console.log(
        `GET /api/FuelRecord/${createdFuelRecord.id}: FAIL`,
        error.message
      );
      results.failed++;
    }
  } else {
    console.log("GET /api/FuelRecord/{id}: SKIPPED (no created fuel record)");
  }

  // PUT (update) fuel record by id
  if (createdFuelRecord && createdFuelRecord.id) {
    try {
      const updatedData = { ...createdFuelRecord, cost: 110.0 };
      const res = await axios.put(
        `${baseURL}/api/FuelRecord/${createdFuelRecord.id}`,
        updatedData
      );
      if (isAllowedStatus(res.status, [200, 204])) {
        console.log(
          `PUT /api/FuelRecord/${createdFuelRecord.id}: PASS (${res.status})`
        );
        results.passed++;
      } else {
        console.log(
          `PUT /api/FuelRecord/${createdFuelRecord.id}: FAIL (${res.status})`
        );
        results.failed++;
      }
    } catch (error) {
      console.log(
        `PUT /api/FuelRecord/${createdFuelRecord.id}: FAIL`,
        error.message
      );
      results.failed++;
    }
  } else {
    console.log("PUT /api/FuelRecord/{id}: SKIPPED (no created fuel record)");
  }

  // DELETE fuel record by id
  if (createdFuelRecord && createdFuelRecord.id) {
    try {
      const res = await axios.delete(
        `${baseURL}/api/FuelRecord/${createdFuelRecord.id}`
      );
      if (isAllowedStatus(res.status, [200, 204])) {
        console.log(
          `DELETE /api/FuelRecord/${createdFuelRecord.id}: PASS (${res.status})`
        );
        results.passed++;
      } else {
        console.log(
          `DELETE /api/FuelRecord/${createdFuelRecord.id}: FAIL (${res.status})`
        );
        results.failed++;
      }
    } catch (error) {
      console.log(
        `DELETE /api/FuelRecord/${createdFuelRecord.id}: FAIL`,
        error.message
      );
      results.failed++;
    }
  } else {
    console.log(
      "DELETE /api/FuelRecord/{id}: SKIPPED (no created fuel record)"
    );
  }

  // Negative test: GET non-existent fuel record
  try {
    const nonExistentId = 999999;
    await axios.get(`${baseURL}/api/FuelRecord/${nonExistentId}`);
    console.log(
      `GET /api/FuelRecord/${nonExistentId}: FAIL (unexpected success)`
    );
    results.failed++;
  } catch (error) {
    if (error.response && error.response.status === 404) {
      console.log(`GET /api/FuelRecord/999999: PASS (404 as expected)`);
      results.passed++;
    } else {
      console.log(`GET /api/FuelRecord/999999: FAIL`, error.message);
      results.failed++;
    }
  }
  return results;
}

// =========================
// Test for Maintenance API
// =========================
async function testMaintenance() {
  let results = { passed: 0, failed: 0 };
  console.log("\n--- Testing Maintenance Endpoints ---");

  // GET all maintenance records
  try {
    const res = await axios.get(`${baseURL}/api/Maintenance`);
    if (isAllowedStatus(res.status, [200, 204])) {
      console.log(`GET /api/Maintenance: PASS (${res.status})`);
      results.passed++;
    } else {
      console.log(`GET /api/Maintenance: FAIL (${res.status})`);
      results.failed++;
    }
  } catch (error) {
    console.log("GET /api/Maintenance: FAIL", error.message);
    results.failed++;
  }

  // POST a new maintenance record
  let createdMaintenance = null;
  try {
    // Assuming vehicleId: 1 exists in your system
    const maintenanceData = {
      vehicleId: 1,
      maintenanceDate: "2025-01-10T00:00:00Z",
      description: "Oil Change",
      cost: 75.0,
      nextDueDate: "2025-06-10T00:00:00Z",
    };
    const res = await axios.post(`${baseURL}/api/Maintenance`, maintenanceData);
    if (isAllowedStatus(res.status, [200, 201, 204])) {
      console.log(`POST /api/Maintenance: PASS (${res.status})`);
      createdMaintenance = res.data;
      if (!createdMaintenance || !createdMaintenance.id) {
        console.warn(
          "POST /api/Maintenance returned no content. Subsequent tests may be skipped."
        );
      }
      results.passed++;
    } else {
      console.log(`POST /api/Maintenance: FAIL (${res.status})`);
      results.failed++;
    }
  } catch (error) {
    console.log("POST /api/Maintenance: FAIL", error.message);
    results.failed++;
  }

  // GET maintenance record by id
  if (createdMaintenance && createdMaintenance.id) {
    try {
      const res = await axios.get(
        `${baseURL}/api/Maintenance/${createdMaintenance.id}`
      );
      if (isAllowedStatus(res.status, [200, 204])) {
        console.log(
          `GET /api/Maintenance/${createdMaintenance.id}: PASS (${res.status})`
        );
        results.passed++;
      } else {
        console.log(
          `GET /api/Maintenance/${createdMaintenance.id}: FAIL (${res.status})`
        );
        results.failed++;
      }
    } catch (error) {
      console.log(
        `GET /api/Maintenance/${createdMaintenance.id}: FAIL`,
        error.message
      );
      results.failed++;
    }
  } else {
    console.log("GET /api/Maintenance/{id}: SKIPPED (no created maintenance)");
  }

  // PUT (update) maintenance record by id
  if (createdMaintenance && createdMaintenance.id) {
    try {
      const updatedData = { ...createdMaintenance, cost: 80.0 };
      const res = await axios.put(
        `${baseURL}/api/Maintenance/${createdMaintenance.id}`,
        updatedData
      );
      if (isAllowedStatus(res.status, [200, 204])) {
        console.log(
          `PUT /api/Maintenance/${createdMaintenance.id}: PASS (${res.status})`
        );
        results.passed++;
      } else {
        console.log(
          `PUT /api/Maintenance/${createdMaintenance.id}: FAIL (${res.status})`
        );
        results.failed++;
      }
    } catch (error) {
      console.log(
        `PUT /api/Maintenance/${createdMaintenance.id}: FAIL`,
        error.message
      );
      results.failed++;
    }
  } else {
    console.log("PUT /api/Maintenance/{id}: SKIPPED (no created maintenance)");
  }

  // DELETE maintenance record by id
  if (createdMaintenance && createdMaintenance.id) {
    try {
      const res = await axios.delete(
        `${baseURL}/api/Maintenance/${createdMaintenance.id}`
      );
      if (isAllowedStatus(res.status, [200, 204])) {
        console.log(
          `DELETE /api/Maintenance/${createdMaintenance.id}: PASS (${res.status})`
        );
        results.passed++;
      } else {
        console.log(
          `DELETE /api/Maintenance/${createdMaintenance.id}: FAIL (${res.status})`
        );
        results.failed++;
      }
    } catch (error) {
      console.log(
        `DELETE /api/Maintenance/${createdMaintenance.id}: FAIL`,
        error.message
      );
      results.failed++;
    }
  } else {
    console.log(
      "DELETE /api/Maintenance/{id}: SKIPPED (no created maintenance)"
    );
  }

  // Negative test: GET non-existent maintenance record
  try {
    const nonExistentId = 999999;
    await axios.get(`${baseURL}/api/Maintenance/${nonExistentId}`);
    console.log(
      `GET /api/Maintenance/${nonExistentId}: FAIL (unexpected success)`
    );
    results.failed++;
  } catch (error) {
    if (error.response && error.response.status === 404) {
      console.log(`GET /api/Maintenance/999999: PASS (404 as expected)`);
      results.passed++;
    } else {
      console.log(`GET /api/Maintenance/999999: FAIL`, error.message);
      results.failed++;
    }
  }
  return results;
}

// ====================
// Test for Trip API
// ====================
async function testTrip() {
  let results = { passed: 0, failed: 0 };
  console.log("\n--- Testing Trip Endpoints ---");

  // GET all trips
  try {
    const res = await axios.get(`${baseURL}/api/Trip`);
    if (isAllowedStatus(res.status, [200, 204])) {
      console.log(`GET /api/Trip: PASS (${res.status})`);
      results.passed++;
    } else {
      console.log(`GET /api/Trip: FAIL (${res.status})`);
      results.failed++;
    }
  } catch (error) {
    console.log("GET /api/Trip: FAIL", error.message);
    results.failed++;
  }

  // POST a new trip
  let createdTrip = null;
  try {
    const tripData = {
      vehicleId: 1,
      driverId: 1,
      startTime: "2025-01-01T08:00:00Z",
      endTime: "2025-01-01T10:00:00Z",
      startLocation: "Location A",
      endLocation: "Location B",
      distance: 120.0,
    };
    const res = await axios.post(`${baseURL}/api/Trip`, tripData);
    if (isAllowedStatus(res.status, [200, 201, 204])) {
      console.log(`POST /api/Trip: PASS (${res.status})`);
      createdTrip = res.data;
      if (!createdTrip || !createdTrip.id) {
        console.warn(
          "POST /api/Trip returned no content. Subsequent tests may be skipped."
        );
      }
      results.passed++;
    } else {
      console.log(`POST /api/Trip: FAIL (${res.status})`);
      results.failed++;
    }
  } catch (error) {
    console.log("POST /api/Trip: FAIL", error.message);
    results.failed++;
  }

  // GET trip by id
  if (createdTrip && createdTrip.id) {
    try {
      const res = await axios.get(`${baseURL}/api/Trip/${createdTrip.id}`);
      if (isAllowedStatus(res.status, [200, 204])) {
        console.log(`GET /api/Trip/${createdTrip.id}: PASS (${res.status})`);
        results.passed++;
      } else {
        console.log(`GET /api/Trip/${createdTrip.id}: FAIL (${res.status})`);
        results.failed++;
      }
    } catch (error) {
      console.log(`GET /api/Trip/${createdTrip.id}: FAIL`, error.message);
      results.failed++;
    }
  } else {
    console.log("GET /api/Trip/{id}: SKIPPED (no created trip)");
  }

  // PUT (update) trip by id
  if (createdTrip && createdTrip.id) {
    try {
      const updatedData = { ...createdTrip, distance: 130.0 };
      const res = await axios.put(
        `${baseURL}/api/Trip/${createdTrip.id}`,
        updatedData
      );
      if (isAllowedStatus(res.status, [200, 204])) {
        console.log(`PUT /api/Trip/${createdTrip.id}: PASS (${res.status})`);
        results.passed++;
      } else {
        console.log(`PUT /api/Trip/${createdTrip.id}: FAIL (${res.status})`);
        results.failed++;
      }
    } catch (error) {
      console.log(`PUT /api/Trip/${createdTrip.id}: FAIL`, error.message);
      results.failed++;
    }
  } else {
    console.log("PUT /api/Trip/{id}: SKIPPED (no created trip)");
  }

  // DELETE trip by id
  if (createdTrip && createdTrip.id) {
    try {
      const res = await axios.delete(`${baseURL}/api/Trip/${createdTrip.id}`);
      if (isAllowedStatus(res.status, [200, 204])) {
        console.log(`DELETE /api/Trip/${createdTrip.id}: PASS (${res.status})`);
        results.passed++;
      } else {
        console.log(`DELETE /api/Trip/${createdTrip.id}: FAIL (${res.status})`);
        results.failed++;
      }
    } catch (error) {
      console.log(`DELETE /api/Trip/${createdTrip.id}: FAIL`, error.message);
      results.failed++;
    }
  } else {
    console.log("DELETE /api/Trip/{id}: SKIPPED (no created trip)");
  }

  // Negative test: GET non-existent trip
  try {
    const nonExistentId = 999999;
    await axios.get(`${baseURL}/api/Trip/${nonExistentId}`);
    console.log(`GET /api/Trip/${nonExistentId}: FAIL (unexpected success)`);
    results.failed++;
  } catch (error) {
    if (error.response && error.response.status === 404) {
      console.log(`GET /api/Trip/999999: PASS (404 as expected)`);
      results.passed++;
    } else {
      console.log(`GET /api/Trip/999999: FAIL`, error.message);
      results.failed++;
    }
  }
  return results;
}

// ====================
// Test for User API
// ====================
async function testUser() {
  let results = { passed: 0, failed: 0 };
  console.log("\n--- Testing User Endpoints ---");

  // GET all users
  try {
    const res = await axios.get(`${baseURL}/api/User`);
    if (isAllowedStatus(res.status, [200, 204])) {
      console.log(`GET /api/User: PASS (${res.status})`);
      results.passed++;
    } else {
      console.log(`GET /api/User: FAIL (${res.status})`);
      results.failed++;
    }
  } catch (error) {
    console.log("GET /api/User: FAIL", error.message);
    results.failed++;
  }

  // POST a new user
  let createdUser = null;
  try {
    const userData = {
      name: "Test User",
      email: "testuser@example.com",
    };
    const res = await axios.post(`${baseURL}/api/User`, userData);
    if (isAllowedStatus(res.status, [200, 201, 204])) {
      console.log(`POST /api/User: PASS (${res.status})`);
      createdUser = res.data;
      if (!createdUser || !createdUser.id) {
        console.warn(
          "POST /api/User returned no content. Subsequent tests may be skipped."
        );
      }
      results.passed++;
    } else {
      console.log(`POST /api/User: FAIL (${res.status})`);
      results.failed++;
    }
  } catch (error) {
    console.log("POST /api/User: FAIL", error.message);
    results.failed++;
  }

  // GET user by id
  if (createdUser && createdUser.id) {
    try {
      const res = await axios.get(`${baseURL}/api/User/${createdUser.id}`);
      if (isAllowedStatus(res.status, [200, 204])) {
        console.log(`GET /api/User/${createdUser.id}: PASS (${res.status})`);
        results.passed++;
      } else {
        console.log(`GET /api/User/${createdUser.id}: FAIL (${res.status})`);
        results.failed++;
      }
    } catch (error) {
      console.log(`GET /api/User/${createdUser.id}: FAIL`, error.message);
      results.failed++;
    }
  } else {
    console.log("GET /api/User/{id}: SKIPPED (no created user)");
  }

  // PUT (update) user by id
  if (createdUser && createdUser.id) {
    try {
      const updatedData = { ...createdUser, name: "Updated Test User" };
      const res = await axios.put(
        `${baseURL}/api/User/${createdUser.id}`,
        updatedData
      );
      if (isAllowedStatus(res.status, [200, 204])) {
        console.log(`PUT /api/User/${createdUser.id}: PASS (${res.status})`);
        results.passed++;
      } else {
        console.log(`PUT /api/User/${createdUser.id}: FAIL (${res.status})`);
        results.failed++;
      }
    } catch (error) {
      console.log(`PUT /api/User/${createdUser.id}: FAIL`, error.message);
      results.failed++;
    }
  } else {
    console.log("PUT /api/User/{id}: SKIPPED (no created user)");
  }

  // DELETE user by id
  if (createdUser && createdUser.id) {
    try {
      const res = await axios.delete(`${baseURL}/api/User/${createdUser.id}`);
      if (isAllowedStatus(res.status, [200, 204])) {
        console.log(`DELETE /api/User/${createdUser.id}: PASS (${res.status})`);
        results.passed++;
      } else {
        console.log(`DELETE /api/User/${createdUser.id}: FAIL (${res.status})`);
        results.failed++;
      }
    } catch (error) {
      console.log(`DELETE /api/User/${createdUser.id}: FAIL`, error.message);
      results.failed++;
    }
  } else {
    console.log("DELETE /api/User/{id}: SKIPPED (no created user)");
  }

  // Negative test: GET non-existent user
  try {
    const nonExistentId = 999999;
    await axios.get(`${baseURL}/api/User/${nonExistentId}`);
    console.log(`GET /api/User/${nonExistentId}: FAIL (unexpected success)`);
    results.failed++;
  } catch (error) {
    if (error.response && error.response.status === 404) {
      console.log(`GET /api/User/999999: PASS (404 as expected)`);
      results.passed++;
    } else {
      console.log(`GET /api/User/999999: FAIL`, error.message);
      results.failed++;
    }
  }
  return results;
}

// =======================
// Test for Vehicle API
// =======================
async function testVehicle() {
  let results = { passed: 0, failed: 0 };
  console.log("\n--- Testing Vehicle Endpoints ---");

  // GET all vehicles
  try {
    const res = await axios.get(`${baseURL}/api/Vehicle`);
    if (isAllowedStatus(res.status, [200, 204])) {
      console.log(`GET /api/Vehicle: PASS (${res.status})`);
      results.passed++;
    } else {
      console.log(`GET /api/Vehicle: FAIL (${res.status})`);
      results.failed++;
    }
  } catch (error) {
    console.log("GET /api/Vehicle: FAIL", error.message);
    results.failed++;
  }

  // POST a new vehicle
  let createdVehicle = null;
  try {
    const vehicleData = {
      make: "Toyota",
      model: "Camry",
      year: 2020,
    };
    const res = await axios.post(`${baseURL}/api/Vehicle`, vehicleData);
    if (isAllowedStatus(res.status, [200, 201, 204])) {
      console.log(`POST /api/Vehicle: PASS (${res.status})`);
      createdVehicle = res.data;
      if (!createdVehicle || !createdVehicle.id) {
        console.warn(
          "POST /api/Vehicle returned no content. Subsequent tests may be skipped."
        );
      }
      results.passed++;
    } else {
      console.log(`POST /api/Vehicle: FAIL (${res.status})`);
      results.failed++;
    }
  } catch (error) {
    console.log("POST /api/Vehicle: FAIL", error.message);
    results.failed++;
  }

  // GET vehicle by id
  if (createdVehicle && createdVehicle.id) {
    try {
      const res = await axios.get(
        `${baseURL}/api/Vehicle/${createdVehicle.id}`
      );
      if (isAllowedStatus(res.status, [200, 204])) {
        console.log(
          `GET /api/Vehicle/${createdVehicle.id}: PASS (${res.status})`
        );
        results.passed++;
      } else {
        console.log(
          `GET /api/Vehicle/${createdVehicle.id}: FAIL (${res.status})`
        );
        results.failed++;
      }
    } catch (error) {
      console.log(`GET /api/Vehicle/${createdVehicle.id}: FAIL`, error.message);
      results.failed++;
    }
  } else {
    console.log("GET /api/Vehicle/{id}: SKIPPED (no created vehicle)");
  }

  // PUT (update) vehicle by id
  if (createdVehicle && createdVehicle.id) {
    try {
      const updatedData = { ...createdVehicle, model: "Corolla" };
      const res = await axios.put(
        `${baseURL}/api/Vehicle/${createdVehicle.id}`,
        updatedData
      );
      if (isAllowedStatus(res.status, [200, 204])) {
        console.log(
          `PUT /api/Vehicle/${createdVehicle.id}: PASS (${res.status})`
        );
        results.passed++;
      } else {
        console.log(
          `PUT /api/Vehicle/${createdVehicle.id}: FAIL (${res.status})`
        );
        results.failed++;
      }
    } catch (error) {
      console.log(`PUT /api/Vehicle/${createdVehicle.id}: FAIL`, error.message);
      results.failed++;
    }
  } else {
    console.log("PUT /api/Vehicle/{id}: SKIPPED (no created vehicle)");
  }

  // DELETE vehicle by id
  if (createdVehicle && createdVehicle.id) {
    try {
      const res = await axios.delete(
        `${baseURL}/api/Vehicle/${createdVehicle.id}`
      );
      if (isAllowedStatus(res.status, [200, 204])) {
        console.log(
          `DELETE /api/Vehicle/${createdVehicle.id}: PASS (${res.status})`
        );
        results.passed++;
      } else {
        console.log(
          `DELETE /api/Vehicle/${createdVehicle.id}: FAIL (${res.status})`
        );
        results.failed++;
      }
    } catch (error) {
      console.log(
        `DELETE /api/Vehicle/${createdVehicle.id}: FAIL`,
        error.message
      );
      results.failed++;
    }
  } else {
    console.log("DELETE /api/Vehicle/{id}: SKIPPED (no created vehicle)");
  }

  // Negative test: GET non-existent vehicle
  try {
    const nonExistentId = 999999;
    await axios.get(`${baseURL}/api/Vehicle/${nonExistentId}`);
    console.log(`GET /api/Vehicle/${nonExistentId}: FAIL (unexpected success)`);
    results.failed++;
  } catch (error) {
    if (error.response && error.response.status === 404) {
      console.log(`GET /api/Vehicle/999999: PASS (404 as expected)`);
      results.passed++;
    } else {
      console.log(`GET /api/Vehicle/999999: FAIL`, error.message);
      results.failed++;
    }
  }
  return results;
}

// ====================
// Run All Tests & Report
// ====================
async function runTests() {
  let totalPassed = 0,
    totalFailed = 0;
  console.log("=== Starting API Tests ===\n");

  const driverResults = await testDriver();
  totalPassed += driverResults.passed;
  totalFailed += driverResults.failed;

  const fuelRecordResults = await testFuelRecord();
  totalPassed += fuelRecordResults.passed;
  totalFailed += fuelRecordResults.failed;

  const maintenanceResults = await testMaintenance();
  totalPassed += maintenanceResults.passed;
  totalFailed += maintenanceResults.failed;

  const tripResults = await testTrip();
  totalPassed += tripResults.passed;
  totalFailed += tripResults.failed;

  const userResults = await testUser();
  totalPassed += userResults.passed;
  totalFailed += userResults.failed;

  const vehicleResults = await testVehicle();
  totalPassed += vehicleResults.passed;
  totalFailed += vehicleResults.failed;

  console.log("\n=== Final API Test Report ===");
  console.log(`Total Passed: ${totalPassed}`);
  console.log(`Total Failed: ${totalFailed}`);
}

runTests();
