import { Route, Routes } from 'react-router-dom';
import Home from './Components/Home/home.js';
import Register from './Components/Register/register.js';
import Header from './Components/Header/header.js';
import HeaderUser from './Components/Header/headerUser.js';
import Footer from './Components/Footer/footer.js';
import Profile from './Components/Profile/profile';
import DeleteProfile from './Components/Profile/deleteProfile.js';
import UpdateProfile from './Components/Profile/updateProfile.js';
import Login from './Components/Login/login';
import Teacher from './Components/Teacher/teacher.js';
import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';
import Contribuir from './Components/Contribuir/contribuir.js';

function App() {
  const user_id = localStorage.getItem('user_id');
  
  return (
    <div className="App">
      {user_id ? (
        <HeaderUser/>
      ) : (
        <Header/>
      )}
      <Routes>
          <Route exact path="/" element={<Home/>}/>
          <Route path="/register" element={<Register/>}/>
          <Route path="/profile" element={<Profile/>}/>
          <Route path="/login" element={<Login/>}/>
          <Route path="/updateProfile" element={<UpdateProfile/>}/>
          <Route path="/deleteProfile" element={<DeleteProfile/>}/>
          <Route path="/contribuir" element={<Contribuir/>}/>
          <Route path="/teacher/:id" element={<Teacher/>}/>
      </Routes>
      <Footer/>
    </div>
  );
}

export default App;
