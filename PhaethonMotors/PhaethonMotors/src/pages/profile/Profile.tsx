import React, { useEffect, useState } from "react"
import "../../styles/profile.css";
import axios from "axios";

const Profile_API = "https://localhost:7173/api/profile";

interface CustomizedCar {
    id: number;
    modelId: string;
    colorId: string;
    interiorId: string;
    wheelsId: string;
    trimId: string;
    featuresId: string[];
    sketchModelUID: string;
    totalPrice: number;
    savedAt: Date;
}

interface User {
    firstName: string;
    lastName: string;
    email: string;
    savedCars: CustomizedCar[];
}

const Profile: React.FC = () => {
    const [user, setUser] = useState<User | null>(null);
    const [error, setError] = useState("");

    useEffect(() => {
        const fetchProfile = async () => {
            try {
                const token = localStorage.getItem("token");
                const response = await axios.get(Profile_API, {
                    headers: { Authorization: `Bearer ${token}` },
                    withCredentials: true
                });

                setUser(response.data);
            } catch (error: any) {
                setError("Failed to load the profile!");
            }
        };
        fetchProfile();
    }, []);

    if (error) return <p className="error">{error}</p>;
    if (!user) return <p>Loading...</p>;

    return (
        <section className="profile">
            <div className="profile-container">
                <h1>Welcome, {user.firstName}</h1>
                <p>Email: {user.email}</p>

                <h2>Your Saved Cars</h2>
                <div className="cars-container">
                    {user.savedCars != null ? (
                        user.savedCars.length > 0 ? (
                            user.savedCars.map((car) => {
                                return car ? (
                                    <div key={car.id} className="car-card">
                                        <h3>{car.modelId}</h3>
                                        <p>Color: {car.colorId}</p>
                                        <p>Interior: {car.interiorId}</p>
                                        <p>Wheels: {car.wheelsId}</p>
                                        <p>Trim: {car.trimId}</p>
                                        <p>Features: {car.featuresId.join(", ")}</p>
                                        <p>Price: ${car.totalPrice}</p>
                                    </div>
                                ) : (
                                    <p>No Saved Car Configurations...</p>
                                );
                            })
                        ) : (
                            <p>No Saved Car Configurations...</p>
                        )
                    ) : (
                        <p>No Saved Car Configurations...</p>
                    )
                    }

                </div>
            </div>
        </section >
    );
};

export default Profile;