import React from "react";
import { Container, Navbar, Nav } from "react-bootstrap";

function Layout({ children }) {
  return (
    <div>
      <Navbar bg="dark" variant="dark" expand="lg">
        <Container>
          <Navbar.Brand href="/">Fleet Management</Navbar.Brand>
          <Navbar.Toggle aria-controls="basic-navbar-nav" />
          <Navbar.Collapse id="basic-navbar-nav">
            <Nav className="me-auto">
              <Nav.Link href="#dashboard">Dashboard</Nav.Link>
              <Nav.Link href="#vehicles">Vehicles</Nav.Link>
              <Nav.Link href="#drivers">Drivers</Nav.Link>
              <Nav.Link href="#trips">Trips</Nav.Link>
            </Nav>
          </Navbar.Collapse>
        </Container>
      </Navbar>
      <Container className="mt-4">{children}</Container>
    </div>
  );
}

export default Layout;
