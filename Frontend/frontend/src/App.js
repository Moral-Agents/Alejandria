import { Route, Routes } from 'react-router-dom';
import Home from './Components/Home/home.js';
import Register from './Components/Register/register.js';
import Header from './Components/Header/header.js';
import Footer from './Components/Footer/footer.js';
import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';
function App() {
  return (
    <div className="App">
      <Header/>
      <Routes>
          <Route exact path="/" element={<Home/>}/>
          <Route path="/register" element={<Register/>}/>
      </Routes>
      <Footer/>
    </div>
  );
}

export default App;
