/*
import axios, { Axios } from 'axios';
import {useState} from 'react';
import { useNavigate } from 'react-router';
*/
import { Form, Button, Row, Container} from 'react-bootstrap'
import Select from 'react-select'

const options = [
    {value: "course", label: "Curso"},
    {value: "features", label: "Características"},
    {value: "university", label: "Universidad"},
];

function Assistant() {
    return (
        <div>
            <Container classname="w-25 mt-5 mb-5">
                <h2 className="">Asistente virtual</h2>
                <Row className="justify-content-md-center ">
                    <Form>
                        <div>
                            <Form.Group className="mb-3">
                                <Form.Label>Filtrar por 1</Form.Label>
                                <Select options={options}/>

                                <Form.Label>Filtrar por 2</Form.Label>
                                <Select options={options}/>

                                <Form.Label>Filtrar por 3</Form.Label>
                                <Select options={options}/>
                            </Form.Group>
                        </div>
                    </Form>
                </Row>
            </Container>
        </div>
    );
};

export default Assistant;