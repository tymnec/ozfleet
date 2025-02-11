import React, { useState } from "react";
import { Button, Form, FormGroup, Input, Label } from "reactstrap";

const Register = () => {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [error, setError] = useState(null);

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (password !== confirmPassword) {
      setError("Passwords do not match");
      return;
    }
    try {
      const response = await fetch("/api/auth/register", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ username, password }),
      });
      if (response.ok) {
        window.location.href = "/login";
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
      <FormGroup>
        <Label for="confirmPassword">Confirm Password</Label>
        <Input
          type="password"
          name="confirmPassword"
          id="confirmPassword"
          placeholder="Confirm Password"
          value={confirmPassword}
          onChange={(e) => setConfirmPassword(e.target.value)}
        />
      </FormGroup>
      <Button type="submit" color="primary">
        Register
      </Button>
      {error && <div className="text-danger">{error}</div>}
    </Form>
  );
};

export default Register;
