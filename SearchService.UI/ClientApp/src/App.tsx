import React from 'react';
import {
    BrowserRouter as Router,
    Switch,
    Route
} from "react-router-dom";
import axios from 'axios';
import NaviBar from './Components/Navbar';
import { Alert, Container, Row, Col, Button, InputGroup, FormControl, Table } from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';

class App extends React.Component<any, any> {
    constructor(props: any) {
        super(props);
        this.state = {
            query: '',
            results: {},
            message: '',
            loading: false
        };
    }

    fetchSearchResults = (query: string) => {
        const searchUrl = `http://localhost:5000/api/search/${query}`;

        axios.get(searchUrl)
            .then(res => {
                const resultNotFoundMsg = !res.data.length
                    ? 'There are no more search results. Please try a new search'
                    : '';
                this.setState({
                    results: res.data,
                    message: resultNotFoundMsg
                })
            })
            .catch(error => {
                if (axios.isCancel(error) || error) {
                    this.setState({
                        message: 'Failed to fetch the data. Please check network'
                    })
                }
            })
    };

    handleOnInputChange = (event: any) => {
        const query: string = event.target.value;
        if (!query) {
            this.setState({ query, results: {}, message: '' });
        } else {
            this.setState({ query, message: '', loading: true }, () => {
                this.fetchSearchResults(query);
            });
        }
    };

    renderHeadTableSearch = () => {
        const { results } = this.state;

        if (results.length) {
            return (
                <Table striped bordered hover>
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Name</th>
                            <th>Description</th>
                            <th>Address</th>
                            <th>Image</th>
                        </tr>
                    </thead>
                    {this.renderSearchResults()}
                </Table>
            )
        }
    };

    renderSearchResults = () => {
        const { results } = this.state;

        if (results.length) {
            return (
                <tbody>
                    {results.map(
                        (result:
                            {
                                id: string;
                                name: React.ReactNode;
                                description: string;
                                address: string;
                                mainPhoto: string;
                            }
                        ) => (
                            <tr key={result.id}>
                                <td>{result.id}</td>
                                <td>{result.name}</td>
                                <td>{result.description}</td>
                                <td>{result.address}</td>
                                <td><img width="100" src={result.mainPhoto} /></td>
                            </tr>
                        )
                    )}
                </tbody>
            )
        }
    };

    render() {
        const { query, message } = this.state;
        //const { results } = this.state;

        //alert(results);

        return (
            <>
                <Router>
                    <NaviBar />
                    <Container style={{ paddingTop: '2rem', paddingBottom: '2rem' }}>
                        <h1 className="heading">Search Service:</h1>
                    </Container>
                </Router>
                <Container>
                    <InputGroup className="mb-3">
                        <FormControl
                            name="query"
                            value={query}
                            id="search-input"
                            placeholder="Search..."
                            onChange={this.handleOnInputChange}
                        />
                        <InputGroup.Append>
                            <InputGroup.Text><img width="20" src="/images/search.png" /></InputGroup.Text>
                        </InputGroup.Append>
                    </InputGroup>

                    {/*<Alert variant="warning">}
                        
                    /*</Alert>*/}
                    {message && <p className="message">{message}</p>}

                    {this.renderHeadTableSearch()}
      

                </Container>
            </>
        )
    }
}

export default App;