import React, { useEffect, useRef, useState } from "react";
import "../../styles/build.css";
import axios from "axios";

import aether_img from "../../assets/phaethon-model-1-final.png";
import hyperion_img from "../../assets/phaethon-model-2.png";
import titanus_img from "../../assets/phaethon-model-3.png";
import helios_img from "../../assets/phaethon-model-4.png";
import imperium_img from "../../assets/phaethon-model-5.png";


const CAR_API = "https://localhost:7173/api/CarModels/dto";
const COLOR_API = "https://localhost:7173/api/Color/";
const INTERIOR_API = "https://localhost:7173/api/Interior/";
const WHEEL_API = "https://localhost:7173/api/Wheel/";
const TRIM_API = "https://localhost:7173/api/Trim/";
const FEATURE_API = "https://localhost:7173/api/Feature/";
const SUBMODEL_API = "https://localhost:7173/api/CarModels/sub";

const CustomCar_API = "https://localhost:7173/api/profile/custom";

const carUids: Record<string, string> = {
    Aether: "9f9d82e405ca4382a1c9ff442f5862c2",
    Helios: "60c39e2399e14ebbaa1f23016ee6440c",
    Hyperion: "ca2cda599f5341068c992c9f44551bf9",
    Imperium: "bbcbdc697a614c25a5b02ce2a4b2c6ca",
    Titanus: "8a5c6ca7ed6749879bb88166307e5cf7"
};


declare global {
    interface Window {
        Sketchfab: any;
    }
}

const Build = () => {
    const iframeRef = useRef<HTMLIFrameElement>(null);
    const [api, setApi] = useState<any>(null);
    const [materials, setMaterials] = useState<any[]>([]);
    const [viewMode, setViewMode] = useState<"selector" | "configurator">("selector");

    const [carModels, setCarModels] = useState<any[]>([]);
    const [filteredModels, setFilteredModels] = useState<any[]>([]);
    const [selectedCategory, setSelectedCategory] = useState<string>("All");

    const [subModels, setSubModels] = useState<any[]>([]);
    const [carColors, setCarColors] = useState<any[]>([]);
    const [carInteriors, setCarInteriors] = useState<any[]>([]);
    const [carWheels, setCarWheels] = useState<any[]>([]);
    const [carTrimss, setCarTrims] = useState<any[]>([]);
    const [carFeatures, setCarFeatures] = useState<any[]>([]);
    const [selectedCar, setSelectedCar] = useState<any>(null);
    const [currentUid, setCurrentUid] = useState<string>("");
    const [selectedFeatures, setSelectedFeatures] = useState<string[]>([]);
    let [totalPrice, setTotalPrice] = useState<number>(0);


    useEffect(() => {
        const fetchData = async () => {
            try {
                const [
                    carResponse,
                    colorResponse,
                    interiorResponse,
                    wheelResponse,
                    trimResponse,
                    featureResponse,
                    subModels,
                ] = await Promise.all([
                    axios.get(CAR_API),
                    axios.get(COLOR_API),
                    axios.get(INTERIOR_API),
                    axios.get(WHEEL_API),
                    axios.get(TRIM_API),
                    axios.get(FEATURE_API),
                    axios.get(SUBMODEL_API),
                ]);

                setCarModels(carResponse.data?.$values || carResponse.data);
                setFilteredModels(carResponse.data?.$values || carResponse.data);
                setCarColors(colorResponse.data?.$values || colorResponse.data);
                setCarInteriors(interiorResponse.data?.$values || interiorResponse.data);
                setCarWheels(wheelResponse.data?.$values || wheelResponse.data);
                setCarTrims(trimResponse.data?.$values || trimResponse.data);
                setCarFeatures(featureResponse.data?.$values || featureResponse.data);
                setSubModels(subModels.data?.$values || subModels.data);

            } catch (error) {
                console.error("Error fetching data: ", error);
            }
        };

        fetchData();
    }, []);



    useEffect(() => {
        const script = document.createElement("script");
        script.src = "https://static.sketchfab.com/api/sketchfab-viewer-1.12.1.js";
        script.async = true;
        script.onload = () => {
            if (!iframeRef.current || !window.Sketchfab) return;

            const client = new window.Sketchfab(iframeRef.current);

            client.init(currentUid, {
                preload: 1,
                ui_controls: 0,
                ui_infos: 0,
                ui_stop: 0,
                ui_watermark: 0,
                success: function (apiInstance: any) {
                    apiInstance.start();
                    apiInstance.addEventListener("viewerready", function () {
                        setApi(apiInstance);

                        // Fetch materials
                        apiInstance.getMaterialList((err: any, materials: any[]) => {
                            if (!err) {
                                setMaterials(materials);
                            }
                        });
                    });
                },
                error: function () {
                    console.error("Sketchfab Viewer failed to load.");
                },
            });
        };

        document.body.appendChild(script);
    }, [currentUid]);

    // Define material groups
    const targetExteriorMaterials = [
        "MAT_BYD_YangWang_U9_Carpaint",
        "Carpaint_black",
        "Paint1Mtl",
        "mat_0.001",
        "080-0-80",
    ];

    const targetInteriorMaterials = [
        "MAT_Details_INT",
        "Interior",
        "Interior_seat_",
        "Mesh13Mtl",
        "Mesh30Mtl",
        "mat_0.002_4",
        "mat_0.002_9",
        "064-0-64",
    ];

    // Function to update material colors
    const updateMaterialColor = (material: any, newColor: number[]) => {

        ["AlbedoPBR", "DiffuseColor", "SpecularColor"].forEach((channel) => {
            if (material.channels[channel]) {
                material.channels[channel].color = newColor;

                // Remove texture if it exists
                if (material.channels[channel].texture) {
                    material.channels[channel].texture = null;
                }
            }
        });

        // Apply material change
        api.setMaterial(material, () => {
            console.log(`Color changed to ${newColor} for ${material.name}`);
        });
    };

    // Function to change color for either exterior or interior
    const changeColor = (hexColor: string, isInterior: boolean) => {
        if (!api) return;

        api.getMaterialList((err: any, materials: any[]) => {
            if (err) {
                console.error("Error getting materials:", err);
                return;
            }

            // Convert hex color to RGB format (0 to 1 range)
            const newColor = [
                parseInt(hexColor.substring(1, 3), 16) / 255,
                parseInt(hexColor.substring(3, 5), 16) / 255,
                parseInt(hexColor.substring(5, 7), 16) / 255,
            ];

            // Select target materials based on isInterior flag
            const targetMaterials = isInterior ? targetInteriorMaterials : targetExteriorMaterials;

            materials
                .filter((material) => targetMaterials.includes(material.name))
                .forEach((material) => updateMaterialColor(material, newColor));
        });
    };

    const handleConfigure = (carModels: any) => {
        setSelectedCar(carModels);
        setCurrentUid(carUids[carModels.name]);
        setViewMode("configurator");
    };


    const handleFeatureChange = (featureId: string, isChecked: boolean) => {
        let updatedFeatures = [...selectedFeatures];

        if (isChecked) {
            if (!updatedFeatures.includes(featureId)) {
                updatedFeatures.push(featureId);
            }
        } else {
            updatedFeatures = updatedFeatures.filter((id) => id !== featureId);
        }

        setSelectedFeatures(updatedFeatures);
        clacTotalPrice(null, null, null, null, updatedFeatures);
    };

    //Not working properly!
    const clacTotalPrice = (extId: string | null, intId: string | null, wheelId: string | null, trimId: string | null, featuresIds: string[] | null) => {


        if (totalPrice == 0) {
            const baseCar = carModels.find((car) => car.name === selectedCar.name && car.subModel.name === selectedCar.subModel.name);
            if (baseCar && baseCar.basePrice) {
                totalPrice += baseCar.basePrice;
            }
        }


        if (extId) {
            const selectedColor = carColors.find(
                (color) => color.id.toString() === extId
            );
            if (selectedColor && selectedColor.price) {
                totalPrice += selectedColor.price;
            }
        }

        if (intId) {
            const selectedInterior = carInteriors.find(
                (interior) => interior.id.toString() === intId
            );
            if (selectedInterior && selectedInterior.price) {
                totalPrice += selectedInterior.price;
            }
        }

        if (wheelId) {
            const selectedWheel = carWheels.find(
                (wheel) => wheel.id.toString() === wheelId
            );
            if (selectedWheel && selectedWheel.price) {
                totalPrice += selectedWheel.price;
            }
        }

        if (trimId) {
            const selectedTrim = carTrimss.find(
                (trim) => trim.id.toString() === trimId
            );
            if (selectedTrim && selectedTrim.priceIncrease) {
                totalPrice += selectedTrim.priceIncrease;
            }
        }

        if (featuresIds) {
            featuresIds.forEach((featureId) => {
                const selectedFeature = carFeatures.find(
                    (feature) => feature.id.toString() === featureId
                );
                if (selectedFeature && selectedFeature.price) {
                    totalPrice += selectedFeature.price;
                }
            });
        }

        setTotalPrice(totalPrice);
    };

    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();

        const formData = new FormData(e.currentTarget);

        const exteriorColorId = formData.get("color") as string | null;
        const interiroId = formData.get("interior") as string | null;
        const wheelId = formData.get("wheel") as string | null;
        const trimId = formData.get("trim") as string | null;
        const featuresIds = formData.getAll("features").map((id) => id.toString()) as string[] | null;
        const userId = localStorage.getItem("userId") as string | null;
        const carId = selectedCar?.id as string | null;
        clacTotalPrice(exteriorColorId, interiroId, wheelId, trimId, featuresIds);
        const configuration = {
            carId,
            exteriorColorId,
            interiroId,
            wheelId,
            trimId,
            featuresIds,
            currentUid,
            totalPrice,
            subModels,
            userId
        };
        try {
            const response = await axios.post(CustomCar_API, configuration);
            console.log("Configuration saved:", response.data);
        } catch (error) {
            console.error("Error saving configuration:", error);
        }
    }

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

        setFilteredModels(Array.isArray(filtered) ? filtered : []);
    }, [selectedCategory, carModels]);


    return (
        <section className="car-configurator">
            {/* Only show selector if in selector mode */}
            {viewMode === "selector" && (
                <div className="selector">
                    <h2 className="ttl">Select a model line you want to configure. <br />
                        Build your dream!
                    </h2>
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
                                    <button onClick={() => handleConfigure(model)}>⚙️ Configure</button>
                                </div>
                            ))}
                        </div>
                    </div>

                    {/* <div className="display-models">
                        <div className="options-select">
                            {cars.map((car, index) => (
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
                                        <button onClick={() => handleConfigure(car.name)}>⚙️ Configure</button>
                                    </div>
                                </div>
                            ))}
                        </div>
                    </div> */}
                </div>
            )}

            {/* Only show configurator if in configurator mode */}
            {viewMode === "configurator" && (
                <div className="conf-sec">
                    <div className="hb"><h2>Configuring: {selectedCar?.name} {selectedCar?.subModel.name}</h2><button onClick={() => setViewMode("selector")}>← Back to Models</button></div>
                    <div className="configurator">
                        <div className="frame">
                            <iframe
                                ref={iframeRef}
                                src=""
                                id="api-frame"
                                allow="autoplay; fullscreen; xr-spatial-tracking"
                                allowFullScreen
                            ></iframe>
                            <h4>Total Price: ${totalPrice}</h4>
                        </div>

                        <form onSubmit={handleSubmit} style={{ width: "50%" }}>
                            <div className="mods">
                                <div className="conf-mods">
                                    <div className="conf-colors">
                                        <h3>Exterior Colors</h3>
                                        <div className="color-buttons">
                                            {carColors.map((color, index) => (
                                                <div className="c-btn">
                                                    <input type="radio" name="color" value={color.id} style={{
                                                        "--color-btn": color.hexCode,
                                                        color: color.hexCode === "#000000" ? "#FFFFFF" : "#000000"
                                                    } as React.CSSProperties} onClick={() => { changeColor(color.hexCode, false); clacTotalPrice(color.id, null, null, null, null); }} />
                                                    <p style={{ textAlign: "center", marginRight: "2em" }}>$ {color.price}</p>
                                                </div>
                                            ))}
                                        </div>
                                    </div>
                                </div>
                                <div className="conf-mods">
                                    <div className="conf-colors">
                                        <h3>Interior Design</h3>
                                        {carInteriors.map((interior, index) => (
                                            <div key={index} className="interior-info">
                                                <label>
                                                    <input
                                                        type="radio"
                                                        name="interior"
                                                        value={interior.id}
                                                        onClick={() => {
                                                            if (interior.name === "Obsidian Lounge") {
                                                                changeColor("#000000", true);
                                                            } else if (interior.name === "Solaris Elegance") {
                                                                changeColor("#84240c", true);
                                                            } else if (interior.name === "Aetherium Cabin") {
                                                                changeColor("#808000", true);
                                                            } else {
                                                                changeColor("#FFFFFF", true);
                                                            }
                                                            clacTotalPrice(null, interior.id, null, null, null);
                                                        }}
                                                    />
                                                    {interior.name}
                                                </label>
                                                <div className="int-info-p">
                                                    <p>{interior.material}</p>
                                                    <p>$ {interior.price}</p>
                                                </div>
                                            </div>
                                        ))}
                                    </div>
                                </div>
                                <div className="conf-mods">
                                    <h3>Wheels</h3>
                                    <div className="conf-wheels">
                                        {carWheels.map((wheel, index) => (
                                            <div key={index} className="wheels-info">
                                                <label>
                                                    <input type="radio" name="wheels" value={wheel.id} onClick={() => { clacTotalPrice(null, null, wheel.id, null, null); }} />
                                                    {wheel.name}
                                                </label>
                                                <div className="wh-info-p">
                                                    <p>$ {wheel.price}</p>
                                                </div>
                                            </div>
                                        ))}
                                    </div>
                                </div>
                                <div className="conf-mods">
                                    <div className="conf-colors">
                                        <h3>Trim</h3>
                                        {carTrimss.map((trim, index) => (
                                            <div key={index} className="interior-info">
                                                <label>
                                                    <input type="radio" name="trim" value={trim.id} onClick={() => { clacTotalPrice(null, null, null, trim.id, null); }} />
                                                    {trim.name}
                                                </label>
                                                <div className="int-info-p">
                                                    <p>{trim.suspension}</p>
                                                    <p>{trim.horsepoerIncrease}</p>
                                                    <p>$ {trim.priceIncrease}</p>
                                                </div>
                                            </div>
                                        ))}
                                    </div>
                                </div>
                                <div className="conf-mods">
                                    <h3>Features</h3>
                                    <div className="conf-wheels">
                                        {carFeatures.map((feature, index) => (
                                            <div key={index} className="wheels-info">
                                                <label>
                                                    <input
                                                        type="checkbox"
                                                        name="features"
                                                        value={feature.id}
                                                        checked={selectedFeatures.includes(feature.id)}
                                                        onChange={(e) =>
                                                            handleFeatureChange(feature.id, e.target.checked)
                                                        }
                                                        onClick={() => { clacTotalPrice(null, null, null, null, feature.id); }}
                                                    />
                                                    {feature.name}
                                                </label>
                                                <div className="wh-info-p">
                                                    <p>$ {feature.price}</p>
                                                </div>
                                            </div>
                                        ))}
                                    </div>
                                </div>
                                <div className="conf-mods">
                                    <button className="save-conf" type="submit">Save Configuration</button>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            )}
        </section>
    );
};

export default Build;
