const api = 'https://localhost:44319/';

const registerUrl = api + 'Identity/Register';
const loginUrl = api + 'Identity/Login';

function postRequest(url, data) {
    var response = fetch(url, {
        method: 'Post',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(data),
    })
        .then(response => response.json())
        .then(data => {
            console.log('Success:', data);
        })
        .catch((error) => {
            console.error('Error:', error);
        });

    return response;
}

function register(data) {
    return postRequest(registerUrl, data)
}

function login(data) {
    return postRequest(loginUrl, data)
}

export default register;