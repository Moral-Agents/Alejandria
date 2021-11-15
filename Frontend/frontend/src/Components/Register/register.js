import { Form, Button, Row,Container} from 'react-bootstrap'
import React,{ useState } from 'react'
import UserDataService from "../../Services/UserService";
import axios from 'axios';
import http from '../../http-common';
function Register (){
    
    const initialUserState = {
      email:"",
      password:"",
      role: 2,
      institution:"",
      name:""
    };

    const [user, setUser] = useState(initialUserState);
    const [submitted,setSubmitted]  = useState(false);

    const handleInputChange = event => {
      const { name, value } = event.target;
      setUser({ ...user, [name]: value });
    };

    const saveUser = async () => {
      let data = {
        email:"sample@gmail.com",
        password:"12345",
        role: 0,
        institution:"UPC",
        name:"Hayek"
      };
      await http.post(`User/`, {data})
          .then(response => {

          setSubmitted(true);
          console.log(response);
          console.log(response.data);
          
        })
        .catch(e => console.log(e));
    };
  
    const newUser = () => {
      setUser(initialUserState);
      setSubmitted(false);
    };

      return(
      <div>
        <Container className="mt-5 mb-5">
          <h2 className="mb-4">Crear una nueva cuenta</h2>
          <Row className="justify-content-md-center ">
            <Form>
              <Form.Group className="mb-3" >
                <Form.Label>Correo Electrónico</Form.Label>
                <Form.Control type="email" name="email" placeholder="ejemplo@gmail.com" value={user.email}
              onChange={handleInputChange} />
              </Form.Group>

              <Form.Group className="mb-3" >
                <Form.Label>Contraseña</Form.Label>
                <Form.Control type="password" name="password" placeholder="**********" value={user.password}
              onChange={handleInputChange}/>
              </Form.Group>

              <Form.Group className="mb-3" >
                <Form.Label>Rol</Form.Label>
                <Form.Control
                  name="role"
                  as="select"
                  value={user.role}
                  onChange={handleInputChange}>
                <option value="2" disabled>Elige una opción..</option>
                <option value="0">Alumno</option>
                <option value="1">Docente</option>
                </Form.Control>
              </Form.Group>
              <Form.Group className="mb-3" >
                <Form.Label>Institución</Form.Label>
                <Form.Control name="institution" value={user.institution} onChange={handleInputChange} type="text" placeholder="Institución Educativa.." />
              </Form.Group>
              <Form.Group className="mb-3" >
                <Form.Label>Nombre de Usuario</Form.Label>
                <Form.Control name="name" value={user.name} onChange={handleInputChange} type="text" placeholder="Nombre de Usuario..." />
              </Form.Group>
              <Button className="mt-3" variant="primary" type="submit" onClick={saveUser}>
                Registrar
              </Button>
            </Form>
           </Row>
          </Container>
      </div>
      )
  }
  
  export default Register;
  