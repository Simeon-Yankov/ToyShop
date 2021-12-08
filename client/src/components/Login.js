import { useNavigate } from 'react-router-dom';
import { Form, Button } from 'react-bootstrap';
import userService from '../services/userService';

const Login = () => {
    const navigate = useNavigate();

    function submitHandler(e) {
        e.preventDefault();

        const enteredUsername = e.target.username.value;
        const enteredPassword = e.target.password.value;

        const loginData = {
            username: enteredUsername,
            password: enteredPassword
        }

        userService
            .login(loginData)
            .then(data => {
                console.log(data.split(':')[1]);
                navigate('/', { replace: true })
            })

    }

    return (
        <Form onSubmit={submitHandler}>
            <Form.Group className="mb-3" controlId="formBasicUsername">
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

export default Login;