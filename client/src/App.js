import React from "react";

import { Route, Routes } from "react-router-dom";
import { Container, Navbar, Nav } from 'react-bootstrap';
import Header from "./components/layout/Header";
import Body from "./components/layout/Body";
import Footer from "./components/layout/Footer";
import Anycomponent from './components/Anycomponent';
import Home from './components/Home';
import Login from './components/Login';
import Register from './components/Register';

// function parseCookies() {
//   return document.cookie.split('; ').reduce((acc, cookie) => {
//     const []
//   })
// }

function App() {

  return (
    <>
      <Header />
      <Container>
        <Body/>
        <Anycomponent />
      </Container>
      <Footer />
    </>
  );
}

export default App;