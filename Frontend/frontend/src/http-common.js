import axios from "axios";

export default axios.create({
  baseURL: "https://sleepy-reaches-77294.herokuapp.com/api/v1/",
  headers: {
    "Content-type": "application/json"
  }
});