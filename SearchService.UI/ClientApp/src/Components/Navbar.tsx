import React, { useState } from 'react';
import { Modal, Form, Button, Container, FormCheck, FormControl, FormGroup, FormLabel, FormText, Nav, Navbar } from 'react-bootstrap';
import ModalHeader from 'react-bootstrap/ModalHeader';
import ModalTitle from 'react-bootstrap/ModalTitle';
import ModalBody from 'react-bootstrap/ModalBody';
import { Link } from "react-router-dom";
import styled from 'styled-components';

const Styles = styled.div`
    a, .navbar-brand, .navbar-nav .nav-link {
        color: #adb1b8;
        &:hover {
            color: white
        }
    }
`
export default function NaviBar() {

    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    return (
        <>
            <Styles>
                <Navbar collapseOnSelect expand="lg" bg="dark" variant="dark">
                    <Container>
                        <Navbar.Brand><img width="30" src="logo512.png" />{' '}React+TS Application</Navbar.Brand>
                        <Navbar.Toggle aria-controls="responsive-navbar-nav" />
                        <Navbar.Collapse id="responsive-navbar-nav">
                            <Nav className="mr-auto">
                                <Nav.Link><Link to="/">Home</Link></Nav.Link>
                                <Nav.Link><Link to="/users">Users</Link></Nav.Link>
                                <Nav.Link><Link to="/about">About</Link></Nav.Link>
                            </Nav>
                            <Nav>
                                <Button variant="primary" className="mr-2" onClick={handleShow}>Log in</Button>
                                <Button variant="primary" onClick={handleShow}>Sing Out</Button>
                            </Nav>
                        </Navbar.Collapse>
                    </Container>
                </Navbar>
            </Styles>

            <Modal show={show} onHide={handleClose}>
                <ModalHeader closeButton>
                    <ModalTitle>Log in</ModalTitle>
                </ModalHeader>
                <ModalBody>
                    <Form>
                        <FormGroup controlId="fromBasicEmail">
                            <FormLabel>Email address</FormLabel>
                            <FormControl type="email" placeholder="Enter your email" />
                            <FormText className="text-muted">We'll never share your email with third parties</FormText>
                        </FormGroup>
                        <FormGroup controlId="fromBasicPassword">
                            <FormLabel>Password</FormLabel>
                            <FormControl type="password" placeholder="Enter your password" />
                        </FormGroup>
                        <FormGroup controlId="fromBasicCheckedBox">
                            <FormCheck type="checkbox" label="Remember me" />
                        </FormGroup>
                    </Form>
                </ModalBody>
            </Modal>
        </>
    )
}
