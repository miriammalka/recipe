import { NavLink } from "react-router-dom"
export default function Navbar() {
    return (
        <>
            <nav className="navbar navbar-expand-lg navbar-light bg-light">
                <div className="container-fluid">
                    <a className="navbar-brand" href="#">
                        <img src="/images/recipe-logo.jpg" alt="" width="100" className="d-inline-block pe-3" />
                        Recipes
                    </a>
                    <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                        <span className="navbar-toggler-icon"></span>
                    </button>
                    <div className="collapse navbar-collapse" id="navbarNav">
                        <ul className="navbar-nav">
                            <li className="nav-item">
                                <a className="nav-link active" aria-current="page" href="#">Recipes</a>
                            </li>
                            <li className="nav-item">
                                <NavLink className={"nav-link"} to="/Meals">Meals</NavLink>
                            </li>
                            <li className="nav-item">
                                <NavLink className={"nav-link"} to="/Cookbooks">Cookbooks</NavLink>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>

        </>
    )
}