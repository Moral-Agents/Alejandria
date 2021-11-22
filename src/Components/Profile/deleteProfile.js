import { Container,Form, ListGroup, Row,Col,Button} from "react-bootstrap";
import { Link } from "react-router-dom";
import {useState} from 'react'
import axios, { Axios } from 'axios';
import { useNavigate } from 'react-router';
function DeleteProfile() {
   let navigate = useNavigate();
   const deleteUser = () => {
    const id = localStorage.getItem('user_id');
    axios.delete(`https://sleepy-reaches-77294.herokuapp.com/api/v1/User/${id}`)
    .then( ()  => {
      localStorage.removeItem('user_id');
      navigate('/');
      alert("Tu cuenta ha sido eliminada correctamente")
      window.location.reload();
    });
   }
    
    return (
      <div>
        <Container className="mt-5">
        <Row>
            <Col xs={3}>
                <ListGroup defaultActiveKey="#delete">
                <ListGroup.Item action >
                <Link style={{ textDecoration: 'none' , color:'#000'}} to="/profile">Datos</Link>
                </ListGroup.Item>
                <ListGroup.Item action  >
                <Link style={{ textDecoration: 'none' , color:'#000'}} to="/updateProfile">Actualizar Usuario</Link>
                </ListGroup.Item>
                <ListGroup.Item action href="#delete">
                <Link style={{ textDecoration: 'none' , color:'#fff'}} to="/deleteProfile">Eliminar Cuenta</Link>
                </ListGroup.Item>
            </ListGroup>
            </Col>
            <Col>
                <h2>¿Deseas eliminar tu cuenta?</h2>
                <p>Una vez eliminada tu cuenta no podrás recuperarla nunca más. </p>
                <Button variant="danger"  className="mt-3" onClick={deleteUser}>Eliminar</Button>
            </Col>
           </Row>
          
        </Container>
      </div>
    );
  }
  
  export default DeleteProfile;
  