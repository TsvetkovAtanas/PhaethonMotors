import React from "react"
import { Link } from "react-router-dom"
import "../../styles/models.css";

import aether_img from "../../assets/aether_card.jpg";
import helios_img from '../../assets/helios_card.jpg';
import hyperion_img from "../../assets/hyperion_card.jpg"
import imperium_img from "../../assets/imperium_card.jpg";
import titanus_img from "../../assets/titanus_card.jpg";

const cars = [
    { name: "Aether", fuel: "Gasoline", fuel2: "", price: "$120,000", img: aether_img, heading: "The iconc, rear-engine sports car with exceptional performance." },
    { name: "Helios", fuel: "Gasoline", fuel2: "", price: "$140,000", img: helios_img, heading: "The mid-engine, sports car for two made for pure driving pleasure." },
    { name: "Hyperion", fuel: "Hybrid", fuel2: "Gasoline", price: "$150,000", img: hyperion_img, heading: "The sports car sedan for an active lifestyle with highest comfort." },
    { name: "Imperium", fuel: "Hybrid", fuel2: "Gasoline", price: "$220,000", img: imperium_img, heading: "The luxurius performance car with max pleasure for every passenger princess." },
    { name: "Titanus", fuel: "Electric", fuel2: "Gasoline", price: "$120,000", img: titanus_img, heading: "The versetile SUV with sports car performance and up to five seats." }
];

const Models: React.FC = () => {
    return (
        <section className="cars">
            <h1 className="h1">Models</h1>
            <div className="models">
                {cars.map((car, index) => (
                    <Link to="/">
                        <div key={car.name || index} className="card" style={{ backgroundImage: `url(${car.img})` }}>
                            <div className="header">
                                <h1>{car.name}</h1>
                                <div className="fueltype">
                                    <p>{car.fuel}</p>
                                    <p style={{ display: car.fuel2 === "" ? "none" : "block" }}>{car.fuel2}</p>
                                </div>
                                <h2>{car.heading}</h2>
                                <p>From {car.price}</p>
                            </div>
                            <div className="footer">
                                <button>Build your own {car.name}</button>
                                <button>All {car.name} models</button>
                            </div>
                        </div>
                    </Link>
                ))}
            </div>
        </section>
    );
};

export default Models;