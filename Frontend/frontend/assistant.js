/*
import axios, { Axios } from 'axios';
import {useState} from 'react';
import { useNavigate } from 'react-router';
*/
import { Form, Button, Row, Container, Col} from 'react-bootstrap'
import Select from 'react-select'

const opt_courses = [
    {value: 0, label: "string"},
    {value: 1, label: "Liberalismo Económico"},
];

const opt_universities = [
    {value: 0, label: "Universidad Peruana de Ciencias Aplicadas"},
];

const opt_rankings = [
    {value: 0, label: "Excelente"},
    {value: 1, label: "Bueno"},
    {value: 2, label: "Regular"},
    {value: 3, label: "Malo"},
    {value: 4, label: "Muy malo"},
]

function Assistant() {
    return (
        <div>
            <Container className="w-25 mt-5 mb-5">
                <h2 className="mb-4">Asistente virtual</h2>
                <Row className="align-items-center">
                    <Form>
                        <div>
                            <Form.Group className="mb-3">
                                <Col>
                                <Form.Label>¿De qué universidad eres?</Form.Label>
                                <Select options={opt_universities} className="mb-3"/>

                                <Form.Label>¿Qué curso vas a llevar?</Form.Label>
                                <Select options={opt_courses} className="mb-3"/>

                                <Form.Label>Quiero un profesor...</Form.Label>
                                <Select options={opt_rankings} className="mb-3"/>

                                <Form.Label>Que califique...</Form.Label>
                                <Select options={opt_rankings} className="mb-3"/>

                                <Form.Label>Que explique...</Form.Label>
                                <Select options={opt_rankings} className="mb-3"/>
                                </Col>
                            </Form.Group>
                        </div>
                    </Form>
                </Row>
            </Container>
        </div>
    );
};

export default Assistant;