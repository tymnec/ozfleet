import React, { useState } from "react";
import { Button, Form, FormGroup, Input, Label } from "reactstrap";

const Login = () => {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState(null);

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await fetch("/api/auth/login", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ username, password }),
      });
      if (response.ok) {
        window.location.href = "/";
      } else {
        const data = await response.json();
        setError(data.message);
      }
    } catch (error) {
      setError(error.message);
    }
  };

  return (
    <Form onSubmit={handleSubmit}>
      <FormGroup>
        <Label for="username">Username</Label>
        <Input
          type="text"
          name="username"
          id="username"
          placeholder="Username"
          value={username}
          onChange={(e) => setUsername(e.target.value)}
        />
      </FormGroup>
      <FormGroup>
        <Label for="password">Password</Label>
        <Input
          type="password"
          name="password"
          id="password"
          placeholder="Password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />
      </FormGroup>
      {error && <div style={{ color: "red" }}>{error}</div>}
      <Button type="submit" color="primary">
        Login
      </Button>
    </Form>
  );
};

export default Login;
