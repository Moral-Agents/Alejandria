import { Form, Button, Row,Container} from 'react-bootstrap'
import axios, { Axios } from 'axios';
import {useState} from 'react';
import { useNavigate } from 'react-router';
function Login() {
      let navigate = useNavigate();
      const initialUserState = {
        email:"",
        password:"",
      };
      const [user, setUser] = useState(initialUserState);
      const handleInputChange = event => {
        const { name, value } = event.target;
        setUser({ ...user, [name]: value });
      };
      
      const loginUser = async () => {
        await axios.get(`https://sleepy-reaches-77294.herokuapp.com/api/v1/User/${user.email}/${user.password}`)
            .then(response => {
            localStorage.setItem("user_id", response.data[0].id)
            console.log(response)
            navigate('/')
            window.location.reload()
          })
        }

    return (
        <div>
        <Container className="w-25 mt-5 mb-5">
          <h2 className="mb-4">Login</h2>
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
              <Button  className="mt-3" variant="primary" onClick={loginUser}>
                Iniciar Sesión
              </Button>
              </div>
            </Form>           
            </Row>
          </Container>
      </div>
    );
  }
  
  export default Login;
  