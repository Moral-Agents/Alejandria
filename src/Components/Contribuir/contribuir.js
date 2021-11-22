import { Form, Button, Row,Container,Alert} from 'react-bootstrap'
import React,{ useState } from 'react'
import { useNavigate } from 'react-router';
import axios from 'axios';

function Contribuir() {

    const initialTeacherState = {
        name:"",
        img:"",
        institution: "",
        description:"",
        course:"",
        rating:0,
        attribute1:0,
        attribute2: 0,
        attribute3: 0,
        attribute4: 0
      };
      let navigate = useNavigate();
      const [teacher, setTeacher] = useState(initialTeacherState);
  
      const handleInputChange = event => {
        const { name, value } = event.target;
        setTeacher({ ...teacher, [name]: value });
      };
  
      const saveTeacher = async () => {
        let data = JSON.stringify({
            name:teacher.name,
            img:"https://picsum.photos/200",
            institution: teacher.institution,
            description:teacher.description,
            course:teacher.course,
            rating:0,
            attribute1:0,
            attribute2: 0,
            attribute3: 0,
            attribute4: 0
        });
        await axios.post(`https://sleepy-reaches-77294.herokuapp.com/api/v1/Teacher`, data,{ headers: {'Content-Type': 'application/json'}})
            .then(response => {
              setTeacher({
                name:response.data.name,
                img:"https://picsum.photos/200",
                institution: response.data.institution,
                description:response.data.description,
                course:response.data.course,
                rating:0,
                attribute1:0,
                attribute2: 0,
                attribute3: 0,
                attribute4: 0
              });
            alert("El docente se ha registrado exitosamente")
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

    return (
      <Container className="mt-5">
          <h3>Registrar profesor</h3>
          <Row className="justify-content-md-center ">
            <Form className="mt-4">
                <div>
              <Form.Group className="mb-3" >
                <Form.Label>Nombre Completo</Form.Label>
                <Form.Control type="name" name="name" placeholder="Nombre completo..." value={teacher.name}
              onChange={handleInputChange} />
              </Form.Group>

              <Form.Group className="mb-3" >
                <Form.Label>Institución</Form.Label>
                <Form.Control type="institution" name="institution" placeholder="Institución Educativa.." value={teacher.institution}
              onChange={handleInputChange}/>
              </Form.Group>

              <Form.Group className="mb-3" >
                <Form.Label>Descripción</Form.Label>
                <Form.Control name="description" value={teacher.description} onChange={handleInputChange} type="text" placeholder="Descripción del docente..." />
              </Form.Group>
              <Form.Group className="mb-3" >
                <Form.Label>Curso</Form.Label>
                <Form.Control name="course" value={teacher.course} onChange={handleInputChange} type="text" placeholder="Curso del docente..." />
              </Form.Group>
              <Button  className="mt-3" variant="primary" onClick={saveTeacher}>
                Registrar
              </Button>
              </div>
            </Form>           
            </Row>
      </Container>
    );
  }
  
  export default Contribuir;
  