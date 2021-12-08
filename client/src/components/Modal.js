import Button from 'react-bootstrap/Button';
import ModalBootstrap from 'react-bootstrap/Modal';

function Modal() {
    console.log('Hello from model')

    return (
        <ModalBootstrap.Dialog>
            <ModalBootstrap.Header closeButton>
                <ModalBootstrap.Title>Are you sure?</ModalBootstrap.Title>
            </ModalBootstrap.Header>
            <ModalBootstrap.Footer>
                <Button variant="secondary">Cancel</Button>
                <Button variant="danger">Confirm</Button>
            </ModalBootstrap.Footer>
        </ModalBootstrap.Dialog>
    );
}

export default Modal;