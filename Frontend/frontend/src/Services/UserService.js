import http from '../http-common';
import axios from '../http-common';

  const create = data => {
    return axios.post("/User", data);
  };
  
  
  export default {
    create
  };