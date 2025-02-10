const axios = require("axios");

// Set the base URL for your API. Change if necessary.
const baseURL = process.env.BASE_URL || "http://localhost:5192";

// Test function for User endpoints
async function testUser() {
  let results = { passed: 0, failed: 0 };
  console.log("--- Testing User Endpoints ---");

  // 1. GET /api/User
  try {
    const res = await axios.get(`${baseURL}/api/User`);
    console.log(`GET /api/User: ${res.status}`, res.data);
    if (res.status === 200) {
      console.log("GET /api/User: PASS");
      results.passed++;
    } else {
      console.log("GET /api/User: FAIL");
      results.failed++;
    }
  } catch (error) {
    console.log("GET /api/User: FAIL", error.message);
    results.failed++;
  }

  // 2. POST /api/User
  let createdUser = null;
  try {
    const userData = {
      name: "Test User",
      email: "testuser@example.com",
    };
    const res = await axios.post(`${baseURL}/api/User`, userData);
    console.log(`POST /api/User: ${res.status}`, res.data);
    if (res.status === 200 || res.status === 201) {
      console.log("POST /api/User: PASS");
      createdUser = res.data;
      results.passed++;
    } else {
      console.log("POST /api/User: FAIL");
      results.failed++;
    }
  } catch (error) {
    console.log("POST /api/User: FAIL", error.message);
    results.failed++;
  }

  // 3. GET /api/User/{id}
  try {
    if (createdUser && createdUser.id) {
      const res = await axios.get(`${baseURL}/api/User/${createdUser.id}`);
      console.log(`GET /api/User/${createdUser.id}: ${res.status}`, res.data);
      if (res.status === 200) {
        console.log(`GET /api/User/${createdUser.id}: PASS`);
        results.passed++;
      } else {
        console.log(`GET /api/User/${createdUser.id}: FAIL`);
        results.failed++;
      }
    } else {
      console.log("GET /api/User/{id}: SKIPPED (no created user)");
    }
  } catch (error) {
    console.log("GET /api/User/{id}: FAIL", error.message);
    results.failed++;
  }

  // 4. PUT /api/User/{id}
  try {
    if (createdUser && createdUser.id) {
      const updatedData = { ...createdUser, name: "Updated Test User" };
      const res = await axios.put(
        `${baseURL}/api/User/${createdUser.id}`,
        updatedData
      );
      console.log(`PUT /api/User/${createdUser.id}: ${res.status}`, res.data);
      if (res.status === 200 || res.status === 204) {
        console.log(`PUT /api/User/${createdUser.id}: PASS`);
        results.passed++;
      } else {
        console.log(`PUT /api/User/${createdUser.id}: FAIL`);
        results.failed++;
      }
    } else {
      console.log("PUT /api/User/{id}: SKIPPED (no created user)");
    }
  } catch (error) {
    console.log("PUT /api/User/{id}: FAIL", error.message);
    results.failed++;
  }

  // 5. DELETE /api/User/{id}
  try {
    if (createdUser && createdUser.id) {
      const res = await axios.delete(`${baseURL}/api/User/${createdUser.id}`);
      console.log(
        `DELETE /api/User/${createdUser.id}: ${res.status}`,
        res.data
      );
      if (res.status === 200 || res.status === 204) {
        console.log(`DELETE /api/User/${createdUser.id}: PASS`);
        results.passed++;
      } else {
        console.log(`DELETE /api/User/${createdUser.id}: FAIL`);
        results.failed++;
      }
    } else {
      console.log("DELETE /api/User/{id}: SKIPPED (no created user)");
    }
  } catch (error) {
    console.log("DELETE /api/User/{id}: FAIL", error.message);
    results.failed++;
  }

  return results;
}

// Run the test and print a report
async function runTests() {
  let totalPassed = 0,
    totalFailed = 0;
  console.log("=== Starting User API Tests ===\n");

  const userResults = await testUser();
  totalPassed += userResults.passed;
  totalFailed += userResults.failed;

  console.log("\n=== User API Test Report ===");
  console.log(`Total Passed: ${totalPassed}`);
  console.log(`Total Failed: ${totalFailed}`);
  console.log(`Results: ${JSON.stringify(userResults)}`);
}

runTests();
