import { Container, Form, Button,Row,Col,Card } from "react-bootstrap";
import { Link } from "react-router-dom";
import React,{useState,useEffect} from 'react'
import axios from 'axios';
function Home() {
  const [teachers, setTeachers] = useState([]);
	const [load,setLoading] = useState(true);

  const fetchData = React.useCallback(async (e) => {
    const request = await axios.get(`https://sleepy-reaches-77294.herokuapp.com/api/v1/Teacher`);
		setTeachers(request.data);
    setLoading(false);
	}, []);

  if(load){
    fetchData();
  }

	const handleSearch = React.useCallback(async (e) => {
    setLoading(false)
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
                    <div className="pl-2 pr-2 col-sm-3">
                      <Card className="pb-2 align-items-center" style={{ height: '400px'}} key={teacher.id}>
                      <Card.Title className="mt-4 text-center text-uppercase h6">{teacher.course}</Card.Title>
                        <Card.Img variant="top" className="mt-4 rounded-circle w-50" src={teacher.img} />
                        <Card.Body>
                        <Card.Text className="text-center h5">
                          {teacher.name}
                        </Card.Text>
                        <Card.Text className="small text-center font-weight-light">
                          {teacher.institution}
                        </Card.Text>
                        <div className="text-center">
                          <Button variant="primary"><Link style={{ textDecoration: 'none' , color:'#fff'}} to={`/teacher/${teacher.id}`}>Ver Profesor</Link></Button>
                        </div>
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
  