import React, { useState, useEffect, useRef } from "react";
import { FaPlay, FaPause } from "react-icons/fa";
import "../../styles/modelsdiffs.css";
import sound from "../../assets/sports-car-sound.mp3";
import track_sound from "../../assets/track.jpg";

interface ModelsDiffsProps {
    selectedModels: any[];
}

const colorStyles: Record<string, string> = {
    Default: "transparent",
    Grey: "rgba(128, 128, 128, 0.6)",
    // Black: "rgba(0, 0, 0, 0.8)",
    Red: "rgba(255, 0, 0, 0.6)",
    Yellow: "rgba(255, 255, 0, 0.6)",
    Purple: "rgba(128, 0, 128, 0.6)",
};

const ModelsDiffs: React.FC<ModelsDiffsProps> = ({ selectedModels }) => {
    if (selectedModels.filter(model => model).length !== 2) return null;
    const [selectedColors, setSelectedColors] = useState<string[]>(Array(selectedModels.length).fill("Default"));
    const [openSection, setOpenSection] = useState<string | null>(null);
    const [isPlaying, setIsPlaying] = useState<boolean[]>(selectedModels.map(() => false));
    const audioRefs = useRef<HTMLAudioElement[]>([]);


    const handleColorChange = (index: number, color: string) => {
        const updatedColors = [...selectedColors];
        updatedColors[index] = color;
        setSelectedColors(updatedColors);
    };


    const [model1, model2] = selectedModels;
    const getComparisonArrow = (value1: any, value2: any): JSX.Element | null => {

        if (value1 == null || value2 == null) return null;

        if (value1 > value2) return <span style={{ color: "green", fontSize: "12px" }}>▲</span>;
        if (value1 < value2) return <span style={{ color: "red", fontSize: "12px" }}>▼</span>;
        return null;
    };

    const sections = [
        { title: "Motor", keys: ["horsepower", "torque", "transmission"] },
        { title: "Performance", keys: ["acceleration", "topSpeed"] },
        { title: "Body", keys: ["driveType", "cargoSpace"] },
        { title: "Terrain Features", keys: ["seatingCapacity"] },
        { title: "Capacities", keys: ["basePrice"] },
        { title: "Service & Warranty", keys: [] },
    ];

    const toggleSection = (section: string) => {
        setOpenSection(openSection === section ? null : section);
    };

    const togglePlay = (index: number) => {
        if (!audioRefs.current[index]) return;

        if (isPlaying[index]) {
            audioRefs.current[index].pause();
        } else {
            audioRefs.current[index].play();
        }

        setIsPlaying((prev) =>
            prev.map((playing, i) => (i === index ? !playing : playing))
        );
    };

    return (
        <div className="models-comparison">
            <div className="mid-header">
                <ul>
                    <li id="overview">Overview</li>
                    <li id="design">Design</li>
                    <li id="details">Details</li>
                    <li id="sound">Sound</li>
                    <li id="moreTools">More Tools</li>
                </ul>
            </div>
            <div className="compare-overview">
                <h1>Overview</h1>
                <div className="compare-stats">
                    {selectedModels.map((model, index) => model && (
                        <div key={index}>
                            <div className="compare-stat-line">
                                <div className="stats-model">
                                    <p>{model.name} {model.subModel?.name}</p>
                                    <ul>
                                        {[
                                            { label: "Price", key: "basePrice", unit: " USD" },
                                            { label: "Drive", key: "driveType", unit: "" },
                                            { label: "Transmission", key: "transmission", unit: "" },
                                            { label: "Max. engine power", key: "horsepower", unit: " hp" },
                                            { label: "Acceleration", key: "acceleration", unit: " s" },
                                            { label: "Top track speed", key: "topSpeed", unit: " km/h" },
                                            { label: "Torque", key: "torque", unit: " N/m" },
                                            { label: "Cargo Space", key: "cargoSpace", unit: " m³" },
                                            { label: "Seating Capacity", key: "seatingCapacity", unit: " seats" },
                                        ].map((item, i) => (
                                            <li key={i}>
                                                <i></i>
                                                {item.label} <br />
                                                <strong>{model[item.key]}{item.unit}</strong>
                                                {index === 0
                                                    ? getComparisonArrow(model1[item.key], model2[item.key])
                                                    : getComparisonArrow(model2[item.key], model1[item.key])
                                                }
                                            </li>
                                        ))}
                                    </ul>
                                </div>
                            </div>
                        </div>
                    ))}
                </div>
                <h1>Design</h1>
                <div className="compare-design">
                    {selectedModels.map((model, index) => model && (
                        <div key={index} className="design-container">
                            <div className="design-model">
                                <img
                                    src={`https://localhost:7173/assets/${model.carImage}`}
                                    alt={model.name}
                                    className="car-image"
                                />
                                <div
                                    className="color-overlay"
                                    style={{
                                        backgroundColor: colorStyles[selectedColors[index]],
                                        mixBlendMode: selectedColors[index] === "Black" ? "multiply" : "color",
                                    }}
                                ></div>
                            </div>
                            <div className="color-buttons">
                                {Object.keys(colorStyles).map((color) => (
                                    <button
                                        key={color}
                                        onClick={() => {
                                            const updatedColors = [...selectedColors];
                                            updatedColors[index] = color;
                                            setSelectedColors(updatedColors);
                                        }}
                                        style={{
                                            backgroundColor: color.toLowerCase(),
                                            color: color === "Black" ? "white" : "black",
                                            padding: "20px 50px",
                                            margin: "5px",
                                            border: "none",
                                            cursor: "pointer",
                                            borderRadius: "5px",
                                        }}
                                    >
                                    </button>
                                ))}
                            </div>
                        </div>
                    ))}
                </div>
                <h1>Details</h1>
                <div className="compare-details">
                    {sections.map((section) => (
                        <div key={section.title} className="accordion-section">
                            <button

                                className="accordion-btn"
                                onClick={() => toggleSection(section.title)}
                            ><i></i>
                                {section.title}
                            </button>
                            <div className={`accordion-info ${openSection === section.title ? "open" : ""}`}>
                                {selectedModels.map((model, index) => (
                                    <div key={index} className="stats-model">
                                        <p>{model.name} {model.subModel?.name}</p>
                                        <ul>
                                            <i></i>
                                            {section.keys.map((key, i) => (
                                                <li key={i}>
                                                    {key} <br />
                                                    <strong>{model[key]}</strong>
                                                    {index === 0
                                                        ? getComparisonArrow(model[key], selectedModels[1]?.[key])
                                                        : getComparisonArrow(selectedModels[0]?.[key], model[key])
                                                    }
                                                </li>
                                            ))}
                                        </ul>
                                    </div>
                                ))}
                            </div>
                        </div>
                    ))}
                </div>
                <h1>Sound</h1>
                <div className="compare-sounds">
                    {selectedModels.map((model, index) => (
                        <div key={index} className="compare-sounds-line">
                            <div className="sounds-model">
                                <p>{model.name} {model.subModel?.name}</p>
                                <div className="img-model">
                                    <audio ref={(el) => (audioRefs.current[index] = el!)} src={sound} />
                                    <button className="sound-button" onClick={() => togglePlay(index)}>
                                        {isPlaying[index] ? <FaPause /> : <FaPlay />}
                                    </button>
                                </div>
                            </div>
                        </div>
                    ))}
                </div>
                <h1>More Tools</h1>
                <div className="more-tools">
                    <ul>
                        <button>⚙️ Build Your Own</button>
                        <button>🏢 New & Used Inventory</button>
                        <button>📄 Vehicle Information</button>
                    </ul>
                </div>
            </div>
        </div>
    );
};
export default ModelsDiffs;