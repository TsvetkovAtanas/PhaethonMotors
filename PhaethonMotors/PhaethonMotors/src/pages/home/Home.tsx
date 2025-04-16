import React from "react"
import Models from "./Models";
import PhaethonCenters from "./PhaethonCenters";
import { Link } from 'react-router-dom';
import hero_vid from "../../assets/hero-vid-final.mp4";
import "../../styles/home.css";


const Home: React.FC = () => {
    return (
        <>
            <div className="home-header">
                <Link to="/">
                    <video autoPlay loop muted src={hero_vid}></video>
                </Link>
                <div className="hero-text">
                    <h1>With great power comes great fun.</h1>
                </div>
            </div>

            <Models />
            <PhaethonCenters />
        </>
    );
};

export default Home;