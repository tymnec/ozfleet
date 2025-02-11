import axios from "axios";

// Create an Axios instance with a base URL (change to your API URL)
const apiClient = axios.create({
  baseURL: process.env.REACT_APP_API_URL || "http://localhost:5192", // API base URL
  timeout: 10000, // 10 seconds timeout
});

// Request Interceptor
apiClient.interceptors.request.use(
  (config) => {
    // For example, attach a token from localStorage to each request
    const token = localStorage.getItem("authToken");
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    console.log("Request:", config); // Debug: log the request configuration
    return config;
  },
  (error) => {
    console.error("Request error:", error);
    return Promise.reject(error);
  }
);

// Response Interceptor
apiClient.interceptors.response.use(
  (response) => {
    console.log("Response:", response); // Debug: log the response
    return response;
  },
  (error) => {
    // You can handle errors globally here.
    console.error("Response error:", error);
    if (error.response && error.response.status === 401) {
      // For example, handle unauthorized access
      console.error("Unauthorized access - perhaps redirect to login?");
    }
    return Promise.reject(error);
  }
);

export default apiClient;
