import { Link, NavLink } from 'react-router-dom';
import { Container } from 'react-bootstrap';

function Header() {

    return (
        <nav className="navbar navbar-expand-lg navbar-light" style={{ background: "#e3f2fd" }}>
            <Container>
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse"
                    data-bs-target="#navbarLinks" aria-controls="navbarLinks"
                    aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <Link to="/" className="navbar-brand">ToyShop</Link>

                <div className="collapse navbar-collapse" id="navbarLinks">
                    <ul className="navbar-nav mr-auto mt-2 mt-lg-0">
                        <li className="nav-item active">
                            <NavLink to="/" className="nav-link">Home</NavLink>
                        </li>
                        <li className="nav-item">
                            <NavLink to="/toys" className="nav-link">Toys</NavLink>
                        </li>
                        <li className="nav-item">
                            <NavLink to="/login" className="nav-link">Login</NavLink>
                        </li>
                        <li>
                            <NavLink to="/register" className="nav-link">Register</NavLink>
                        </li>
                    </ul>
                    {/* <form className="form-inline my-2 my-lg-0">
                        <input className="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search" />
                        <button className="btn btn-outline-success my-2 my-sm-0" type="submit">Search</button>
                    </form> */}
                </div>
            </Container>
        </nav>
    )
}

export default Header;