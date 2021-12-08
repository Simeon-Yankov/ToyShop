// eslint-disable-next-line import/no-anonymous-default-export
export default {
    defaultState: {
        username: '',
        password: ''
    },
    validate: obj => {
        const {username, password} = obj;

        if (!username) {
            return "Username is required";
        }

        if (!password) {
            return "Password is required.";
        }
    }
};