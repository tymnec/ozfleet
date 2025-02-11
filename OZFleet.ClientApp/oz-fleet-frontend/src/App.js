import React from "react";
import { Container, Navbar, Nav, Button } from "react-bootstrap";

function App() {
  return (
    <div>
      <header>
        <Navbar bg="dark" variant="dark" expand="lg">
          <Container>
            <Navbar.Brand href="#home">Oz Fleet</Navbar.Brand>
            <Navbar.Toggle aria-controls="basic-navbar-nav" />
            <Navbar.Collapse id="basic-navbar-nav">
              <Nav className="me-auto">
                <Nav.Link href="#home">Home</Nav.Link>
                <Nav.Link href="#features">Features</Nav.Link>
                <Nav.Link href="#pricing">Pricing</Nav.Link>
              </Nav>
              <Button
                variant="outline-light"
                href="authentication"
                className="me-2"
              >
                Login
              </Button>
              <Button variant="light" href="authentication">
                Register
              </Button>
            </Navbar.Collapse>
          </Container>
        </Navbar>
      </header>
      <Container className="mt-4">
        <h1 className="display-3">Oz Fleet</h1>
        <p className="lead">
          A simple application to manage your fleet of vehicles.
        </p>
      </Container>
      <footer className="bg-dark text-white mt-4">
        <Container className="py-3">
          <p className="mb-0">© 2023 Oz Fleet. All rights reserved.</p>
        </Container>
      </footer>
    </div>
  );
}

export default App;
