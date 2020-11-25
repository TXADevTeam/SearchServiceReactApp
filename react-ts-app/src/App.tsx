import React from 'react'
import {
  BrowserRouter as Router,
  Switch,
  Route
} from "react-router-dom";
import { Jumbotron, Container, Row, Col, Button, InputGroup, FormControl, Table } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import NaviBar from './Components/Navbar';
import Ccomponent from './Ccomponent';

import { Home } from './Home';
// import {Users} from './Users';
// import {About} from './About';

function App() {

  const handleSearch = () => (
    alert('you clicked me')

  );

  return (
    <>
      <Router>
        <NaviBar />
        <Container style={{ paddingTop: '2rem', paddingBottom: '2rem' }}>
          <Row>
            <h1>Search Service</h1>
          </Row>
        </Container>
        <Switch>
          {/* <Route exact path="/" component={Home} /> */}
          {/* <Route path="/users" component={Users} />
          <Route path="/about" component={About} /> */}
        </Switch>
      </Router>
      <Container>
        <Jumbotron>
          <p>
            <InputGroup>
              <FormControl
                placeholder="Введите строку поиска"
                aria-label="Recipient's username"
                aria-describedby="basic-addon2"
              />
            </InputGroup>
          </p>
          <p>
            <Button variant="primary" onClick={handleSearch}>Поиск</Button>
          </p>
        </Jumbotron>
      </Container>
      <Container>
        <Ccomponent />
        {/* <Table bordered hover>
          <thead className="thead-light">
            <tr>
              <th>#</th>
              <th>Title</th>
              <th>Description</th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <td>1</td>
              <td>Mark</td>
              <td>Otto</td>
            </tr>
            <tr>
              <td>2</td>
              <td>Jacob</td>
              <td>@fat</td>
            </tr>
            <tr>
              <td>3</td>
              <td>Larry the Bird</td>
              <td>@twitter</td>
            </tr>
          </tbody>
        </Table> */}
      </Container>
    </>
  );
}

export default App;
