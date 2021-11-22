import { Container,Form, ListGroup, Row,Col,Button,Alert} from "react-bootstrap";
import { Link } from "react-router-dom";
import {useState} from 'react'
import axios, { Axios } from 'axios';
function UpdateProfile() {
    const initialUserState = {
        email:"",
        password:"",
        role: 0,
        institution:"",
        name:""
      };
  
      const [user, setUser] = useState(initialUserState);
      const [submitted,setSubmitted]  = useState(false);
      const id = localStorage.getItem('user_id');
      
      const handleInputChange = event => {
        const { name, value } = event.target;
        setUser({ ...user, [name]: value });
      };
  
      const updateUser = async () => {
        let data = JSON.stringify({
          email:user.email,
          password:user.password,
          role: user.role,
          institution:user.institution,
          name:user.name
        });
        await axios.put(`https://sleepy-reaches-77294.herokuapp.com/api/v1/User/${id}`, data,{ headers: {'Content-Type': 'application/json'}})
            .then(response => {
              setUser({
                email:response.data.email,
                password:response.data.password,
                role: response.data.role,
                institution:response.data.institution,
                name:response.data.name
              });
            window.location.reload();
            setSubmitted(true);
            console.log(response);
            console.log(response.data);
            
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
            console.log(error.config);})
          };
    
      const newUser = () => {
        setUser(initialUserState);
        setSubmitted(false);
      };
    return (
      <div>
        <Container className="mt-5">
        <Row>
            <Col xs={3}>
                <ListGroup defaultActiveKey="#update">
                <ListGroup.Item action >
                <Link style={{ textDecoration: 'none' , color:'#000'}} to="/profile">Datos</Link>
                </ListGroup.Item>
                <ListGroup.Item action href="#update" >
                <Link style={{ textDecoration: 'none' , color:'#fff'}} to="/updateProfile">Actualizar Usuario</Link>
                </ListGroup.Item>
                <ListGroup.Item action >
                <Link style={{ textDecoration: 'none' , color:'#000'}} to="/deleteProfile">Eliminar Cuenta</Link>
                </ListGroup.Item>
            </ListGroup>
            </Col>
            <Col>
                <h2 >Actualizar Cuenta</h2>
                <Form>
                {submitted ? (
                <Alert  variant="success">
                  Se han actualizado los datos correctamente
                </Alert>
                  ) : (
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
                    </div>
                    )}
            </Form>
            <Button className="mt-3" variant="primary" type="submit" onClick={updateUser}>
                Actualizar
              </Button>
            </Col>
           </Row>
          

        </Container>
      </div>
    );
  }
  
  export default UpdateProfile;
  