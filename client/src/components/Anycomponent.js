import { useState, useEffect } from "react";

const Anycomponent = () => {

    const [requireAuth, setRequireAuth] = useState(false);

    useEffect(() => {
        fetch("https://localhost:44319/home")
            .then((res) => {
                if (res.status === 200) {
                    setRequireAuth(true)
                } else {
                    setRequireAuth(false)
                }
            });
    }, []);
    return (
        <div className="createArticle">
            {requireAuth && <div> Treasure is in Greece </div>}
            {!requireAuth && <div>You need to login my good sir</div>}
        </div>
    );
}

export default Anycomponent;