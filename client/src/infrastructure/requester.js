import $ from 'jquery';

const BaseUrl = "https://localhost:44319/";

// Creates the authentication header value
function makeAuth(type) {
    return type === 'basic'
        ?  'Bearer' + sessionStorage.getItem('authtoken')
        : null;
}

// Creates request object
function makeRequest(method, module, endpoint, auth, query) {
    let url = BaseUrl + module + '/' + endpoint;
    
    if (query) {
        url += '?query=' + JSON.stringify(query);
    }

    return {
        method,
        url: url,
        headers: {
            'Authorization': makeAuth(auth),
        }
    };
}

// Function to return GET promise
function get (module, endpoint, auth, query) {
    return $.ajax(makeRequest('GET', module, endpoint, auth, query));
}

// Function to return POST promise
function post (module, endpoint, auth, data) {
    let req = makeRequest('POST', module, endpoint, auth);
    req.data = data;
    
    return $.ajax(req);
}

// Function to return PUT promise
function update (module, endpoint, auth, data) {
    let req = makeRequest('PUT', module, endpoint, auth);
    req.data = data;
    
    return $.ajax(req);
}

// Function to return DELETE promise
function remove (module, endpoint, auth) {
    return $.ajax(makeRequest('DELETE', module, endpoint, auth));
}

// eslint-disable-next-line import/no-anonymous-default-export
export default {
    get,
    post,
    update,
    remove
}