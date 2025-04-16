import React from "react"
import "../../styles/phaethonCenters.css";

import pm_dealership_img from "../../assets/phaethon-dealership.jpg";

const PhaethonCenters: React.FC = () => {
    return (
        <section className="centers">
            <div className="text-container">
                <h1>Find Your Phaethon Center</h1>
                <p>
                    A Phaethon Center, and your dream Phaethon vehicle, may be closer than you think.
                    Search our Phaethon Center network for the location closest to you.
                </p>
                <button>Search Now</button>
            </div>
            <div className="img-container">
                <img src={pm_dealership_img} alt="Phaethon Motors Dealership" />
            </div>
        </section>
    );
};

export default PhaethonCenters;