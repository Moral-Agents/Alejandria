import { Container,Form, ListGroup, Row,Col} from "react-bootstrap";
import {useState,useEffect} from 'react'
import axios from 'axios'
import { Link } from "react-router-dom";
function Profile() {
    const [userData,setUserData] = useState([]);
    const id = localStorage.getItem('user_id');
  
    const fetchData = async () => {
        await axios.get(`https://sleepy-reaches-77294.herokuapp.com/api/v1/User/${id}`)
        .then(response => {
            setUserData(response.data.result)
            console.log(response.data.result)
        });
    }
    useEffect(() => {
        fetchData();
    }, []);
    return (
      <div>
          <Container className="mt-5">
          <Row>
            <Col xs={3}>
                <ListGroup defaultActiveKey="#datos">
                <ListGroup.Item action href="#datos" >
                <Link style={{ textDecoration: 'none' , color:'#fff'}} to="/profile">Datos</Link>
                </ListGroup.Item>
                <ListGroup.Item action href="#update" >
                <Link style={{ textDecoration: 'none' , color:'#000'}} to="/updateProfile">Actualizar Usuario</Link>
                </ListGroup.Item>
                <ListGroup.Item action href="#delete" >
                <Link style={{ textDecoration: 'none' , color:'#000'}} to="/deleteProfile">Eliminar Cuenta</Link>
                </ListGroup.Item>
            </ListGroup>
            </Col>
            <Col>
                <ul className="list-inline">
                    <li className="mb-3 ">Correo:</li>
                    <Form.Control size="md" type="text" placeholder={userData.email} disabled/>
                    <li className="mb-3 mt-3">Institución Educativa:</li>
                    <Form.Control size="md" type="text" placeholder={userData.institution} disabled/>
                    <li className="mb-3 mt-3">Nombre de usuario: </li>
                    <Form.Control size="md" type="text" placeholder={userData.name} disabled/>
                </ul>
            </Col>
           </Row>
          </Container>
      </div>
    );
  }
  
  export default Profile;
  