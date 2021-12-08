import { useState } from 'react';

import Modal from './Modal';
import Backdrop from './Backdrop';

function Card(param) {
  const [modalIsOpen, setModalIsOpen] = useState(false);

  function deleteHandler() {
    setModalIsOpen(true);
  }

  function closeModalHandler() {
    setModalIsOpen(false);
  }

  return (
    <div className="card" style={{ width: '18rem' }}>
      <div className="card-body">
        <h2 className="card-title">{param.title}</h2>
        <div>
          <button type="button" className="btn btn-danger" onClick={deleteHandler} >Delete</button>
        </div>
      </div>
      {modalIsOpen ? <Backdrop modal={<Modal />} isShow={true} /> : null}
    </div>
  )
}

export default Card;