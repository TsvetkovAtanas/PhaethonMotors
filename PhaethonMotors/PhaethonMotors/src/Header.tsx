import React, { useState } from 'react';
import { Link, useLocation } from 'react-router-dom';
import './styles/header.css';

import aether_img from "./assets/phaethon-model-1-final.png";
import hyperion_img from "./assets/phaethon-model-2.png";
import titanus_img from "./assets/phaethon-model-3.png";
import helios_img from "./assets/phaethon-model-4.png";
import imperium_img from "./assets/phaethon-model-5.png";

import aether_gt_img from "./assets/aether_gt.jpg";
import aether_rsx_img from "./assets/aether_rsx.jpg";


type SubModel = {
    name: string;
    fuel: string;
    img: string;
};

type CarModel = {
    name: string;
    fuel: string;
    fuel2: string;
    img: string;
    subModels?: SubModel[];
};

const models: CarModel[] = [
    {
        name: "Aether", fuel: "Gasoline", fuel2: "", img: aether_img, subModels: [
            { name: "Aether GT", fuel: "Gasoline", img: aether_gt_img },
            { name: "Aether RSX", fuel: "Gasoline", img: aether_rsx_img },
            { name: "Aether Spyder", fuel: "Gasoline", img: aether_img }
        ]
    },
    {
        name: "Hyperion", fuel: "Gasoline", fuel2: "", img: hyperion_img, subModels: [
            { name: "Hyperion S", fuel: "Gasoline", img: hyperion_img },
            { name: "Hyperion L", fuel: "Gasoline", img: hyperion_img },
            { name: "Hyperion VT", fuel: "Gasoline", img: hyperion_img }
        ]
    },
    {
        name: "Helios", fuel: "Hybrid", fuel2: "Gasoline", img: helios_img, subModels: [
            { name: "Helios R", fuel: "Hybrid", img: helios_img },
            { name: "Helios GTS", fuel: "Gasoline", img: helios_img },
            { name: "Helios VX12", fuel: "Gasoline", img: helios_img }
        ]
    },
    {
        name: "Imperium", fuel: "Hybrid", fuel2: "Gasoline", img: imperium_img, subModels: [
            { name: "Imperium Royale", fuel: "Hybrid", img: imperium_img },
            { name: "Imperium Veloce", fuel: "Gasoline", img: imperium_img },
            { name: "Imperium Opus Luxe", fuel: "Gasoline", img: imperium_img },
            { name: "Imperium Phantom", fuel: "Hybrid", img: imperium_img }
        ]
    },
    {
        name: "Titanus", fuel: "Electric", fuel2: "Gasoline", img: titanus_img, subModels: [
            { name: "Titanus X-Trail", fuel: "Gasoline", img: titanus_img },
            { name: "Titanus Aero", fuel: "Electric", img: titanus_img },
            { name: "Titanus LX", fuel: "Electric", img: titanus_img },
            { name: "Titanus Apex", fuel: "Gasoline", img: titanus_img }
        ]
    }
];

const Header: React.FC = () => {
    const [isMenuOpen, setIsMenuOpen] = useState(false);
    const [isSubMenuOpen, setIsSubMenuOpen] = useState(false);
    const [selectedModel, setSelectedModel] = useState<CarModel | null>(null);;
    const [selectedCategory, setSelectedCategory] = useState<string>("Models");

    const toggleMenu = () => {
        setIsMenuOpen(!isMenuOpen);
        setIsSubMenuOpen(!isSubMenuOpen);
    };

    const handleModelClick = (model: CarModel) => {
        setSelectedModel(model);
    };

    const resetMenu = () => {
        setSelectedModel(null);
        setSelectedCategory("Models");
    };

    const location = useLocation();
    const getPageClass = () => {
        switch (location.pathname) {
            case "/":
                return "header-white";
            case "/compare":
                return "header-black";
            default:
                return "header-black";
        }
    };

    return (
        <header>
            <div className={`header-elemets ${getPageClass()}`}>
                <button className="menu-btn" onClick={toggleMenu}><i className="fa fa-bars"></i> Menu</button>

                {/* MAIN SIDEBAR */}
                <div className={`sidebar main ${isMenuOpen ? 'open' : ''}`}>
                    {selectedModel && (
                        <button className="back-btn" onClick={resetMenu}>
                            ← Back
                        </button>
                    )}
                    <button className="close-btn-main" onClick={toggleMenu}>&times;</button>
                    <nav>
                        <ul>
                            {selectedModel ? (
                                models.filter((model) => model.name !== selectedModel.name).map((model, index) => (
                                    <li key={index} onClick={() => handleModelClick(model)}>
                                        {model.name} <i className="fa fa-angle-right"></i>
                                    </li>
                                ))
                            ) : (
                                <>
                                    <li onClick={() => setSelectedCategory("Models")}>Models <i className='fa fa-angle-right'></i></li>
                                    <li onClick={() => setSelectedCategory("Shopping Tools")}>Shopping Tools <i className='fa fa-angle-right'></i></li>
                                    <li onClick={() => setSelectedCategory("Services")}>Services <i className='fa fa-angle-right'></i></li>
                                    <li onClick={() => setSelectedCategory("My Phaethon")}>My Phaethon <i className='fa fa-angle-right'></i></li>
                                    <li><Link to="/" className="ul-link">Phaethon Shop</Link></li>
                                    <li><Link to="/" className="ul-link">Phaethon Centers</Link></li>
                                </>
                            )}
                        </ul>
                    </nav>
                </div>

                {/* SUB SIDEBAR */}
                <div className={`sidebar sub ${isSubMenuOpen ? 'open' : ''}`}>
                    <button className="close-btn-sub" onClick={toggleMenu}>&times;</button>
                    <nav>
                        <ul>
                            {selectedModel ? (
                                <>
                                    <h2>{selectedModel.name}</h2>
                                    <div className="models-info-buttons">
                                        <button><i className="fa fa-gear"></i> Build your Phaethon</button>
                                        <button><i className="fa fa-arrow-right-arrow-left"></i> Comapre Phaethons</button>
                                        <button><i className="fa fa-search"></i> Search Inventory</button>
                                    </div>
                                    {models.map((model, index) => (
                                        <li key={index}>
                                            {model.name === selectedModel.name && model.subModels?.map((subModel, index) => (
                                                <div className="car-model" key={index}>
                                                    <h2>{subModel.name}</h2>
                                                    <img src={subModel.img} alt={subModel.name} />
                                                    <div className="fuel">
                                                        <h4>{subModel.fuel}</h4>
                                                    </div>
                                                </div>
                                            ))}
                                        </li>
                                    ))}
                                </>
                            ) : selectedCategory === "Models" ? (
                                models.map((model, index) => (
                                    <li key={index} onClick={() => handleModelClick(model)}>
                                        <div className="car-model">
                                            <h2>{model.name}</h2>
                                            <img src={model.img} alt={model.name} />
                                            <div className="fuel">
                                                <h4>{model.fuel}</h4>
                                                {model.fuel2 && <h4>{model.fuel2}</h4>}
                                            </div>
                                        </div>
                                    </li>
                                ))
                            ) : (
                                <>
                                    {selectedCategory === "Shopping Tools" && (
                                        <ul className='ul-nested'>
                                            <li><Link to="/">Build Your Own</Link></li>
                                            <li><Link to="/">Compare Models</Link></li>
                                            <li><Link to="/">New & Used Inventory</Link></li>
                                            <li><Link to="/">Current Vehicle Offers</Link></li>
                                            <li><Link to="/">Phaethon Financial Services</Link></li>
                                        </ul>
                                    )}
                                    {selectedCategory === "Services" && (
                                        <ul className='ul-nested'>
                                            <li><Link to="/">Online Bill Payment</Link></li>
                                            <li><Link to="/">Delivery Programs</Link></li>
                                            <li><Link to="/">Services & Maintenance</Link></li>
                                            <li><Link to="/">Phaethon Protection Plan</Link></li>
                                        </ul>
                                    )}
                                    {selectedCategory === "My Phaethon" && (
                                        <ul className='ul-nested'>
                                            <div className="btn-place"><button>Log in</button><button>Register</button></div>
                                            <li><Link to="/">Saved Cars</Link></li>
                                            <li><Link to="/">Track Services</Link></li>
                                            <li><Link to="/">Bookings & Orders</Link></li>
                                            <li><Link to="/">Profile Settings</Link></li>
                                            <li><Link to="/">Privacy</Link></li>
                                            <li><Link to="/">Contact & Support</Link></li>
                                        </ul>
                                    )}
                                </>
                            )}
                        </ul>
                    </nav>
                </div>

                <div className="name-logo">
                    <Link to="/"><h1>Phaethon</h1></Link>
                </div>
                <div className="login-btn">
                    <Link to=""><i className="fa fa-user-o"></i></Link>
                </div>
            </div>
        </header>
    );
};

export default Header;
