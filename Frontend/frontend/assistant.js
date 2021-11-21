/*
import axios, { Axios } from 'axios';
import {useState} from 'react';
import { useNavigate } from 'react-router';
*/
import { Form, Button, Row, Container, Col} from 'react-bootstrap'
import Select from 'react-select'

const opt_courses = [
    {value: 0, label: "Computación Gráfica"},
    {value: 1, label: "Liberalismo Económico"},
    {value: 2, label: "Matemática Básica"},
    {value: 3, label: "Contabilidad"},
    {value: 4, label: "Programación Orientada a Objetos"},
];

const opt_universities = [
    {value: 0, label: "Universidad Peruana de Ciencias Aplicadas"},
    {value: 1, label: "Universidad Nacional Mayor de San Marcos"},
    {value: 2, label: "Pontificia Universidad Católica del Perú"},
    {value: 3, label: "Universidad de Ingeniería y Tecnología"},
    {value: 4, label: "Universidad Ricardo Palma"}
];

const opt_strict_level = [
    {value: 0, label: "Muy estricto"},
    {value: 1, label: "Un poco estricto"},
    {value: 2, label: "Moderado"},
    {value: 3, label: "Un poco relajado"},
    {value: 4, label: "Muy relajado"},
];

const opt_qualifies = [
    {value: 0, label: "Alto"},
    {value: 1, label: "Medio"},
    {value: 2, label: "Bajo"},
];

const opt_explains = [
    {value: 0, label: "Todo claro"},
    {value: 1, label: "Más o menos claro"},
    {value: 2, label: "Regular"},
    {value: 3, label: "Un poco confuso"},
    {value: 4, label: "Muy Confuso"},
];

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
                                <Select options={opt_strict_level} className="mb-3"/>

                                <Form.Label>Que califique...</Form.Label>
                                <Select options={opt_qualifies} className="mb-3"/>

                                <Form.Label>Que explique...</Form.Label>
                                <Select options={opt_explains} className="mb-3"/>
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