import './App.css'
import Header from "./Header";
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';

import Footer from './Footer';
import Home from './pages/home/Home';
import Compare from './pages/compare/Compare';
import Build from './pages/build/Build';
import Login from "./pages/login/Login";
import Profile from './pages/profile/Profile';


function App() {

  return (
    <Router>
      <Header />

      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/login" element={<Login />} />
        <Route path="/profile" element={<Profile />} />
        <Route path="/compare" element={<Compare />} />
        <Route path="/build" element={<Build />} />
      </Routes>

      <Footer />
    </Router>
  )
}

export default App
