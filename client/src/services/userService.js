const userService = {
    register: function (data) {
        return fetch('https://localhost:44319/Identity/Register', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        })
            // .then(res => res
            //     .text()
            //     .then(text => res.status === 200 
            //         ? text 
            //         :  Promise.reject(text
            //             .split('description"')[1]
            //             .match('\\"(.*?)\\"')[1]
            //             .replace('"', ''))))
            .then(res => res
                .text()
                .then(text => res.status === 200 ? text : Promise.reject(text)))
    },
    login: function (data) {
        return fetch('https://localhost:44319/Identity/Login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        })
            .then(res => res
                .text()
                .then(text => res.status === 200 ? text : Promise.reject(text)))
    }

}

export default userService;