import { Container, Form, Button,Row,Col,Card } from "react-bootstrap";
import React,{useState,useEffect} from 'react'
import axios from 'axios';
function Home() {
  const [teachers, setTeachers] = useState([]);
	const [searchVal,setSearchVal] = useState([]);

 	

	
	const handleSearch = React.useCallback(async (e) => {
    const request = await axios.get(`https://sleepy-reaches-77294.herokuapp.com/api/v1/Teacher?filter=${e.target.value}`);
		setTeachers(request.data);
	}, []);
    return (
      <div>
        <Container className="mt-5">
          <Form>
              <Row className="align-items-center">
              <Col>
                  <Form.Control onChange={handleSearch}   type="search" name="search" placeholder="Buscar profesor..." />
              </Col>
              </Row>
            </Form> 
            <div>
            <Container className="mt-5" >
              <Row>
               {teachers.map(teacher => (
                    <div className="pl-2 pr-2 col-sm-4">
                      <Card key={teacher.id}>
                        <Card.Img variant="top" src={teacher.img} />
                        <Card.Body>
                        <Card.Title>{teacher.course}</Card.Title>
                        <Card.Text>
                          {teacher.name}
                        </Card.Text>
                        <Card.Text>
                          {teacher.institution}
                        </Card.Text>
                        <Button variant="primary">Ver profesor</Button>
                        </Card.Body>
                      </Card>
                    </div>
               ))}
               </Row>
               </Container>
            </div>     
        </Container>
      </div>
    );
  }
  
  export default Home;
  