import {  Button, Navbar, Nav,Container } from 'react-bootstrap'
import { Link } from "react-router-dom";
function Header() {
  
    return (
        <div>
        <Navbar bg="dark" variant="dark">
          <Container>
            <Navbar.Brand> <Link style={{ textDecoration: 'none' , color:'#fff'}} to="/">Alejandría</Link> </Navbar.Brand>
            <Nav className="me-auto">
              <Nav.Link>Ranking</Nav.Link>
              <Nav.Link >Contribuir</Nav.Link>
              <Nav.Link >Asistente</Nav.Link>
              <Nav.Link >Contacto</Nav.Link>
            </Nav>
            <Nav>
              <Button variant="outline-dark"><Link style={{ textDecoration: 'none' , color:'#fff'}} to="/register">Registrar</Link></Button>
              <Button variant="primary"><Link style={{ textDecoration: 'none' , color:'#fff'}} to="/login">Iniciar Sesión</Link></Button>
            </Nav>
          </Container>
        </Navbar>
    </div>
  
    );
  }
  
  export default Header;
  