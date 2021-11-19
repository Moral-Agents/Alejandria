import { Form, Button, Row,Container,Alert} from 'react-bootstrap'
import React,{ useState } from 'react'
import { useNavigate } from 'react-router';
import UserDataService from "../../Services/UserService";
import axios from 'axios';
import http from '../../http-common';
function Register (){
    
    const initialUserState = {
      email:"",
      password:"",
      role: 0,
      institution:"",
      name:""
    };
    let navigate = useNavigate();
    const [user, setUser] = useState(initialUserState);

    const handleInputChange = event => {
      const { name, value } = event.target;
      setUser({ ...user, [name]: value });
    };

    const saveUser = async () => {
      let data = JSON.stringify({
        email:user.email,
        password:user.password,
        role: user.role,
        institution:user.institution,
        name:user.name
      });
      await axios.post(`https://sleepy-reaches-77294.herokuapp.com/api/v1/User`, data,{ headers: {'Content-Type': 'application/json'}})
          .then(response => {
            setUser({
              email:response.data.email,
              password:response.data.password,
              role: response.data.role,
              institution:response.data.institution,
              name:response.data.name
            });
          alert("Tu cuenta se ha registrado exitosamente")
          navigate('/login')
        })
          .catch((error) => {
            if (error.response) {
                console.log(error.response.data);
                console.log(error.response.status);
                console.log(error.response.headers);
            } else if (error.request) {
                console.log(error.request);
            } else {
                console.log('Error', error.message);
            }
            console.log(error.response.config);
          })
        };

      return(
      <div>
        <Container className="w-50 mt-5 mb-5">
          <h2 className="mb-4">Crear una nueva cuenta</h2>
          <Row className="justify-content-md-center ">
            <Form>
                <div>
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
                <option defaultValue disabled>Elige una opción..</option>
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
              <Button  className="mt-3" variant="primary" onClick={saveUser}>
                Registrar
              </Button>
              </div>
            </Form>           
            </Row>
          </Container>
      </div>
      )
  }
  
  export default Register;
  