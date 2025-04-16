import React, { useState } from "react";
import "../../styles/login.css";
import login_img from "../../assets/lg.jpg";
import axios from "axios";
import { useNavigate } from "react-router-dom";

const Login_API = "https://localhost:7173/api/auth/login";
const Register_API = "https://localhost:7173/api/auth/register";

const Login: React.FC = () => {
    const navigate = useNavigate();
    const [isLogin, setIsLogin] = useState(true);
    const [formData, setFormData] = useState({
        firstName: "",
        lastName: "",
        email: "",
        password: ""
    });
    const [error, setError] = useState("");
    const [success, setSuccess] = useState("");

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setFormData({ ...formData, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();

        try {
            if (isLogin) {
                const payload = { email: formData.email, password: formData.password };
                const response = await axios.post(Login_API, payload, {
                    withCredentials: true,
                });
                setSuccess(response.data);
                setError("");
                localStorage.setItem("token", response.data.token);
                navigate("/profile");
            }
            else {
                const response = await axios.post(Register_API, formData);
                setSuccess(response.data);
                setError("");
                setIsLogin(true);
            }
        } catch (error: any) {
            if (error.response && error.response.data) {
                const responseData = error.response.data;

                if (responseData.errors) {
                    const messages = Object.values(responseData.errors).flat();
                    setError(messages.join(", "));
                } else {
                    setError(responseData.title || "An error occurred");
                }
            } else {
                setError("An unexpected error occurred");
            }
            setSuccess("");
        }
    };

    return (
        <section className="login-section">
            <div className="login-background">
                <div className="log-left">
                    <img src={login_img} alt="" />
                </div>
                {isLogin ? (
                    <div className="log-right">
                        <h1>Log in</h1>
                        <p>Don't have an account? <span onClick={() => setIsLogin(false)}>Register</span></p>
                        <form onSubmit={handleSubmit}>
                            <input type="email" name="email" onChange={handleChange} value={formData.email} placeholder="Email*" />
                            <input type="password" name="password" onChange={handleChange} value={formData.password} placeholder="Enter your password*" />

                            <button type="submit">Log in</button>
                        </form>
                        {error && <p className="error">{error}</p>}
                        {success && <p className="success">{success}</p>}
                        <p className="log-pp">Or log in with</p>
                        <button>Phaethon ID</button>
                    </div>
                ) : (
                    <div className="log-right">
                        <h1>Create an account</h1>
                        <p>Already have an account? <span onClick={() => setIsLogin(true)}>Log in</span></p>
                        <form onSubmit={handleSubmit}>
                            <div className="names">
                                <input type="text" name="firstName" onChange={handleChange} value={formData.firstName} placeholder="First Name*" />
                                <input type="text" name="lastName" onChange={handleChange} value={formData.lastName} placeholder="Last Name*" />
                            </div>
                            <input type="email" name="email" onChange={handleChange} value={formData.email} placeholder="Email*" />
                            <input type="password" name="password" onChange={handleChange} value={formData.password} placeholder="Enter your password*" />

                            <button type="submit">Create account</button>
                        </form>
                        {error && <p className="error">{error}</p>}
                        {success && <p className="success">{success}</p>}
                        <p className="log-pp">Or register with</p>
                        <button>Phaethon ID</button>
                    </div>
                )}
            </div>
        </section>
    );
};
export default Login;