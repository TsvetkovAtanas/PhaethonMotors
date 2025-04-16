import React, { useState, useEffect } from "react";
import axios from "axios";
import "../../styles/compare.css";
import ModelsDiffs from "./ModelsDiffs";
import _ from "lodash";


import aether_img from "../../assets/phaethon-model-1-final.png";
import hyperion_img from "../../assets/phaethon-model-2.png";
import titanus_img from "../../assets/phaethon-model-3.png";
import helios_img from "../../assets/phaethon-model-4.png";
import imperium_img from "../../assets/phaethon-model-5.png";

const API_URL = "https://localhost:7173/api/CarModels/dto";

const Compare: React.FC = () => {
    const [isMenuRightOpen, setIsMenuRightOpen] = useState(false);
    const [selectedCategory, setSelectedCategory] = useState<string>("All"); // Track selected filter
    const [carModels, setCarModels] = useState<any[]>([]);
    const [filteredModels, setFilteredModels] = useState<any[]>([]);
    const [selectedModels, setSelectedModels] = useState<any[]>([]);

    const toggleMenuRight = () => {
        setIsMenuRightOpen(!isMenuRightOpen);
    };

    // Fetch all car models on component mount
    useEffect(() => {
        const fetchCarModels = async () => {
            try {
                const response = await axios.get(API_URL);
                console.log("API Response:", response.data);

                if (response.data?.$values) {
                    const deepClonedData = _.cloneDeep(response.data.$values); // Clone to remove refs
                    setCarModels(deepClonedData);
                    setFilteredModels(deepClonedData);
                } else {
                    console.error("Unexpected API response structure", response.data);
                }
            } catch (error) {
                console.error("Error fetching car models:", error);
            }
        };

        fetchCarModels();
    }, []);



    // Update filtered models when selected category changes
    useEffect(() => {
        if (!Array.isArray(carModels) || carModels.length === 0) return;

        let filtered = [];
        if (selectedCategory === "All") {
            filtered = carModels;
        } else {
            filtered = carModels.filter(model => {
                if (!model?.name) return false; // Prevent errors
                const firstWord = model.name.split(" ")[0];
                return firstWord === selectedCategory;
            });
        }

        console.log("Filtered Models before setting state:", filtered);
        setFilteredModels(Array.isArray(filtered) ? filtered : []);
    }, [selectedCategory, carModels]);


    const CompareToggle = (model: any) => {
        if (selectedModels.some((m) => m.id === model.id)) {
            setSelectedModels(selectedModels.filter((m) => m.id !== model.id));
        } else {
            if (selectedModels.length < 2) {
                setSelectedModels([...selectedModels, model]);
            }
        }
    };

    return (
        <main className="body-comp">
            <section className="compare-section">
                <div className="heading">
                    <h1>Compare Models</h1>
                    <p>Need help deciding on the perfect Phaethon for you? Compare your favorite models side-by-side.</p>
                </div>
            </section>
            <section className="select-models-section">
                <div className="s-btn">
                    {Array(2).fill(null).map((_, index) => (
                        <div key={index}>
                            <div className="s1">
                                {selectedModels[index] && (
                                    <div className="s1-image">
                                        <button className="remove-btn" onClick={() => CompareToggle(selectedModels[index])}>✖</button>
                                        <img
                                            src={`https://localhost:7173/assets/${selectedModels[index].carImage}`}
                                            alt={selectedModels[index].name}
                                        />
                                        <p>{selectedModels[index].name} {selectedModels[index].subModel?.name}</p>
                                    </div>
                                )}
                            </div>

                            <div className="s2">
                                {selectedModels[index] ? (
                                    <p className={selectedModels[index] ? "hidden" : ""}>{selectedModels[index]?.name}</p>
                                ) : (
                                    <button className="select-model-btn" onClick={toggleMenuRight}>
                                        <i className="fa fa-plus"></i> Select model
                                    </button>
                                )}
                            </div>
                        </div>
                    ))}
                </div>

                <ModelsDiffs selectedModels={selectedModels} />

                <div className={`menu-right ${isMenuRightOpen ? 'open' : ''}`}>
                    <h3>Select 2 models</h3>
                    <p className="mr-p">{carModels.length} Models available</p>
                    <button className="close-btn" onClick={toggleMenuRight}>&times;</button>

                    <div className="sm-p">
                        <p>Models</p><p>{selectedCategory} Models</p>
                    </div>
                    <div className="display-models">
                        <div className="filters">
                            <ul>
                                {["All", "Aether", "Helios", "Hyperion", "Imperium", "Titanus"].map((category) => (
                                    <li key={category}>
                                        <input
                                            type="radio"
                                            name="category"
                                            value={category}
                                            checked={selectedCategory === category}
                                            onChange={() => setSelectedCategory(category)}
                                        />
                                        <label>
                                            {category === "Aether" && <img src={aether_img} alt="Aether" />}
                                            {category === "Helios" && <img src={helios_img} alt="Helios" />}
                                            {category === "Hyperion" && <img src={hyperion_img} alt="Hyperion" />}
                                            {category === "Imperium" && <img src={imperium_img} alt="Imperium" />}
                                            {category === "Titanus" && <img src={titanus_img} alt="Titanus" />}
                                            {category}
                                        </label>
                                    </li>
                                ))}
                            </ul>
                        </div>
                        <div className="options">
                            {filteredModels.map((model) => (
                                <div className="model-option" key={model.id}>
                                    <p className="f-type">{model.fuelType1}</p>
                                    <img src={`https://localhost:7173/assets/${model.carImage}`} alt={model.name} />
                                    <h2>{model.name} {model.subModel?.name}</h2>
                                    <p className="m-type">From ${model.basePrice}</p>
                                    <div className="power">
                                        <div className="engine">
                                            <p><strong>{model.horsepower}</strong> hp</p>
                                            <i>Max. engine power</i>
                                        </div>
                                        <div className="speed">
                                            <p><strong>{model.topSpeed}</strong> km/h</p>
                                            <i>Top speed</i>
                                        </div>
                                    </div>
                                    <button onClick={() => CompareToggle(model)}>
                                        {selectedModels.some((m) => m.id === model.id) ? "Remove from compare" : "Add to compare"}
                                    </button>
                                </div>
                            ))}
                        </div>
                    </div>
                </div>
            </section>
        </main>
    );
};

export default Compare;
