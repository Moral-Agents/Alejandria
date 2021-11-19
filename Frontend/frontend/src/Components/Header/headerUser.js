import {  Button, Navbar, Nav,Container } from 'react-bootstrap'
import { Link } from "react-router-dom";
function HeaderUser() {
    const logout = () =>{
      localStorage.removeItem("user_id");
      window.location.reload();
    }
    return (
        <div>
        <Navbar bg="dark" variant="dark">
          <Container>
            <Navbar.Brand> <Link style={{ textDecoration: 'none' , color:'#fff'}} to="/">Alejandría</Link> </Navbar.Brand>
            <Nav className="me-auto">
              <Nav.Link>Ranking</Nav.Link>
              <Nav.Link href="#features">Contribuir</Nav.Link>
              <Nav.Link href="#pricing">Asistente</Nav.Link>
              <Nav.Link href="#pricing">Contacto</Nav.Link>
            </Nav>
            <Nav>
              <Button variant="primary"><Link style={{ textDecoration: 'none' , color:'#fff'}} to="/profile">Perfil</Link></Button>
              <Nav.Link onClick={logout}>Logout</Nav.Link>
            </Nav>
          </Container>
        </Navbar>
    </div>
  
    );
  }
  
  export default HeaderUser;
  