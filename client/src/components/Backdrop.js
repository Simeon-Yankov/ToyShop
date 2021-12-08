import { React, useState } from 'react';

import { Button, Offcanvas } from 'react-bootstrap';
import { unmountComponentAtNode } from 'react-dom';

function Backdrop(props) {
    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    return (
        <>
            <Offcanvas show={show} onHide={handleClose}>
                <div>{props.modal}</div>
            </Offcanvas>
        </>
    );
}

export default Backdrop;