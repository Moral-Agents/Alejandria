import { Container,Form,Row,Col,Button,ProgressBar,Modal } from "react-bootstrap";
import { useParams } from 'react-router-dom';
import React,{useState,useEffect} from 'react';

import axios from 'axios'

function Teacher() {
    const { id } = useParams();
    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const rating_before = localStorage.getItem('ratings'+id);
    const user_id = localStorage.getItem('user_id');
    const handleShow = () => {
        
        if(rating_before != 1){
            setShow(true);
        }
    };
    const [teacherData,setTeacherData] = useState([]);
    
    const initialRatingState = {
        attribute1:0,
        attribute2: 0,
        attribute3: 0,
        attribute4: 0
    };

    const initialCommentState = {
        teacherId:id,
        userId: user_id,
        description: "",
    };

    const [rating, setRating] = useState(initialRatingState);
    const [comment, setComment] = useState(initialCommentState);
    const [comments, setComments] = useState([]);


    const handleCommentChange = event => {
        const { name, value } = event.target;
        setComment({ ...comment, [name]: value });
    };

    const handleInputChange = event => {
        const { name, value } = event.target;
        setRating({ ...rating, [name]: value });
    };



    const fetchComments = React.useCallback(async (e) => {
        const request = await axios.get(`https://sleepy-reaches-77294.herokuapp.com/api/v1/Comment`);
        setComments(request.data);
    }, []);

    useEffect(() => {
        fetchComments();
    }, []);

    const saveComment = async () => {
        let data = JSON.stringify({
            teacherId:comment.teacherId,
            userId:comment.userId,
            description:comment.description
        });
        await axios.post(`https://sleepy-reaches-77294.herokuapp.com/api/v1/Comment`, data,{ headers: {'Content-Type': 'application/json'}})
            .then(response => {
              setComment({
                teacherId:response.data.teacherId,
                userId:response.data.userId,
                description:response.data.description
              });
              window.location.reload()
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

    const updateRating = async () => {
        let data = JSON.stringify({
            name:teacherData.name,
            img:teacherData.img,
            institution: teacherData.institution,
            description:teacherData.description,
            course:teacherData.course,
            rating: 0,
            attribute1: rating.attribute1,
            attribute2: rating.attribute2,
            attribute3: rating.attribute3,
            attribute4: rating.attribute4
        });
        console.log("DATA: " + data)
        await axios.put(`https://sleepy-reaches-77294.herokuapp.com/api/v1/Teacher/${id}`, data,{ headers: {'Content-Type': 'application/json'}})
            .then(response => {
              setTeacherData({
                name:data.name,
                img:data.img,
                institution: data.institution,
                description:data.description,
                course:data.course,
                rating: data.rating,
                attribute1: data.attribute1,
                attribute2: data.attribute2,
                attribute3: data.attribute3,
                attribute4: data.attribute4
              });

            alert("Calificado exitosamente");
            localStorage.setItem("ratings" + id, 1);
            window.location.reload();
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

    const fetchData = async () => {
        await axios.get(`https://sleepy-reaches-77294.herokuapp.com/api/v1/Teacher/${id}`)
        .then(response => {
            setTeacherData(response.data.result)
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
                  <Col className="col-sm-9"><h4>{teacherData.name} / {teacherData.course}</h4></Col>
                  <Col className="d-flex col-sm-3 justify-content-end"><Button variant="danger" onClick={handleShow} disabled={rating_before}>Calificar</Button></Col>
              </Row>
              <Row className="mt-4">
                  <Col className="col-sm-3">
                      <img className="w-75" src={teacherData.img}/>
                  </Col>
                  <Col className="col-sm-1"></Col>
                  <Col >
                      <div>
                        <Row>
                            <Col >
                                <h6>Poco responsable</h6>
                            </Col>
                            <Col  className="d-flex justify-content-end">
                                <h6 >Muy responsable</h6>
                            </Col>
                        </Row>
                        <Row>
                            <Col>
                                <ProgressBar variant="info" label={`${teacherData.attribute1* 10}%`} now={teacherData.attribute1 * 10} />
                            </Col>
                        </Row>
                      </div>
                      <div>
                        <Row className="mt-3">
                            <Col>
                                <h6>Califica Bajo</h6>
                            </Col>
                            <Col  className="d-flex justify-content-end">
                                <h6 >Califica Alto</h6>
                            </Col>
                        </Row>
                        <Row>
                            <Col>
                                <ProgressBar variant="info" label={`${teacherData.attribute2* 10}%`} now={teacherData.attribute2 * 10} />
                            </Col>
                        </Row>
                      </div>
                      <div>
                        <Row className="mt-3">
                            <Col>
                                <h6>Aburrido</h6>
                            </Col>
                            <Col  className="d-flex justify-content-end">
                                <h6 >Entretenido</h6>
                            </Col>
                        </Row>
                        <Row>
                            <Col>
                                <ProgressBar variant="info" label={`${teacherData.attribute3* 10}%`} now={teacherData.attribute3 * 10} />
                            </Col>
                        </Row>
                      </div>
                      <div>
                        <Row className="mt-3">
                            <Col>
                                <h6>Explica mal</h6>
                            </Col>
                            <Col  className="d-flex justify-content-end">
                                <h6 >Explica bien</h6>
                            </Col>
                        </Row>
                        <Row>
                            <Col>
                                <ProgressBar variant="info" label={`${teacherData.attribute4 * 10}%`} now={teacherData.attribute4 * 10} />
                            </Col>
                        </Row>
                      </div>
                  </Col>
              </Row>
              <Row className="mt-4">
                  <Col>
                     {teacherData.description}
                  </Col>
              </Row>
              <Modal show={show} onHide={handleClose}>
                    <Modal.Header closeButton>
                        <Modal.Title>Calificar Profesor</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <Form>
                        <div>
                            <Form.Group className="mb-3" >
                                <Form.Label>Responsabilidad(1-10)</Form.Label>
                                <Form.Control name="attribute1" type="number" min="0" max="10" onKeyDown={(event) => {event.preventDefault(); }}  onChange={handleInputChange}/>
                            </Form.Group>
                            
                            <Form.Group className="mb-3" >
                                <Form.Label>??Qu?? tan alto califica?(1-10)</Form.Label>
                                <Form.Control name="attribute2" type="number" min="0" max="10" onKeyDown={(event) => {event.preventDefault(); }}  onChange={handleInputChange}/>
                            </Form.Group>

                            <Form.Group className="mb-3" >
                                <Form.Label>??Qu?? tan entretenida es su clase?(1-10)</Form.Label>
                                <Form.Control name="attribute3" type="number" min="0" max="10" onKeyDown={(event) => {event.preventDefault(); }}  onChange={handleInputChange}/>
                            </Form.Group>

                            <Form.Group className="mb-3" >
                                <Form.Label>??Qu?? tan bien explica?(1-10)</Form.Label>
                                <Form.Control name="attribute4" type="number" min="0" max="10" onKeyDown={(event) => {event.preventDefault(); }}  onChange={handleInputChange}/>
                            </Form.Group>
                        </div>
                        </Form>   
                    </Modal.Body>
                    <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>
                        Cerrar
                    </Button>
                    <Button variant="primary" onClick={updateRating}>
                        Guardar
                    </Button>
                    </Modal.Footer>
              </Modal>
              <Row className="mt-4">
                <h4>Comentarios</h4>
                <Form>
                    <Form.Group className="mt-3" >
                        <Form.Control name="description" as="textarea" style={{resize: "none" }} rows={3} onChange={handleCommentChange}/>
                        <Button  className="mt-3" variant="primary" onClick={saveComment}>
                            Comentar
                        </Button>
                    </Form.Group>
                </Form>

                <div className="mb-5">
                    { comments.map(comment_ => (
                        <div className="mt-5 mb-5">
                            <Row>
                                <Col className="col-sm-11">
                                    <h6>{comment_.name} / <span>{comment_.dateTime}</span></h6>
                                </Col>

                            </Row>
                            <Row>
                                <p>{comment_.description}</p>
                            </Row>
                            
                        </div>
                    ))}
                </div>
              </Row>
          </Container>

          
      </div>
    );
  }
  
  export default Teacher;
  