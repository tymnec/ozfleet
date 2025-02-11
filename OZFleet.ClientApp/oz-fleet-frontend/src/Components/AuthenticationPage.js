import React from "react";
import { Container, Row, Col, Tabs, Tab } from "react-bootstrap";
import Layout from "./Layout";
import Login from "./Authentication/Login";
import Register from "./Authentication/Register";

const AuthenticationPage = () => {
  return (
    <Layout>
      <Container>
        <Row className="justify-content-md-center">
          <Col md={8}>
            <h2>Login/Register</h2>
            <Tabs defaultActiveKey="login" id="uncontrolled-tab-example">
              <Tab eventKey="login" title="Login">
                <Login />
              </Tab>
              <Tab eventKey="register" title="Register">
                <Register />
              </Tab>
            </Tabs>
          </Col>
        </Row>
      </Container>
    </Layout>
  );
};

export default AuthenticationPage;
