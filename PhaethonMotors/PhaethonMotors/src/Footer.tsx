import React from "react"
import { Link } from "react-router-dom"
import "./styles/footer.css";

const Footer: React.FC = () => {
    return (
        <section className="footer-page">
            <h1 className="footer-h1">One step away from reaching your dream!</h1>
            <div className="contacts">
                <div className="footer-info">
                    <h2>Newsletter</h2>
                    <p>Latest news directly in your inbox.</p>
                    <button className="fi-btn">Subscribe</button>
                </div>
                <div className="footer-info">
                    <h2>Locations & Contacts</h2>
                    <p>Do you have any questions?</p>
                    <button className="fi-btn">Get in touch</button>
                </div>
                <div className="footer-info">
                    <h2>Social Media</h2>
                    <p>Get in touch with us via social media.</p>
                    <Link to="/"><i className="fa fa-facebook"></i></Link>
                    <Link to="/"><i className="fa fa-instagram"></i></Link>
                    <Link to="/"><i className="fa fa-pinterest"></i></Link>
                    <Link to="/"><i className="fa fa-youtube"></i></Link>
                    <Link to="/"><i className="fa fa-x"></i></Link>
                    <Link to="/"><i className="fa fa-linkedin"></i></Link>
                </div>
            </div>
        </section>
    );
};

export default Footer;