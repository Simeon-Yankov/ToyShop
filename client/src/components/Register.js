import React, { useState } from 'react';

import { useNavigate } from 'react-router-dom';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import userService from '../services/userService'

const Register = () => {
    const [state, setState] = useState(null);
    const navigate = useNavigate();

    function submitHandler(e) {
        e.preventDefault();
        console.log(e.target);

        const enteredEmail = e.target?.email?.value;
        const enteredUsername = e.target?.username?.value;
        const enteredPassword = e.target?.password?.value;

        const registerData = {
            email: enteredEmail,
            username: enteredUsername,
            password: enteredPassword
        }

        console.log(registerData);

        userService
            .register(registerData)
            .then(x => {
                navigate('/login');
            })
            .catch(message => {
                setState(message);
                console.log(message);
            })
    }

    return (
        <Form onSubmit={submitHandler}>
            <div className="text-danger p-2">{state && state }</div>
            <Form.Group className="mb-3" controlId="formBasicEmail">
                <Form.Label>Email address</Form.Label>
                <Form.Control type="email" name="email" placeholder="Enter email" />
            </Form.Group>
            <Form.Group className="mb-3" controlId="formBasicUserName">
                <Form.Label>Username</Form.Label>
                <Form.Control type="text" name="username" placeholder="Enter Username" />
            </Form.Group>
            <Form.Group className="mb-3" controlId="formBasicPassword">
                <Form.Label>Password</Form.Label>
                <Form.Control type="password" name="password" placeholder="Enter Password" />
            </Form.Group>
            <Button variant="primary" type="submit">
                Submit
            </Button>
        </Form>
    )
}

export default Register;