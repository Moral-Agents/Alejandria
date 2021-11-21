import { Route, Routes } from 'react-router-dom';
import Home from './Components/Home/home.js';
import Register from './Components/Register/register.js';
import Header from './Components/Header/header.js';
import HeaderUser from './Components/Header/headerUser.js';
import Footer from './Components/Footer/footer.js';
import Profile from './Components/Profile/profile';
import DeleteProfile from './Components/Profile/deleteProfile.js';
import UpdateProfile from './Components/Profile/updateProfile.js';
import Assistant from './Components/Assistant/assistant.js';
import Login from './Components/Login/login';
import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';

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
          <Route path="/assistant" element={<Assistant/>}/>
      </Routes>
      <Footer/>
    </div>
  );
}

export default App;
