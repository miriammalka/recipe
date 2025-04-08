import { NavLink } from "react-router-dom"
import UserPanel from "./UserPanel"
export default function Navbar() {
    return (
        <>
            <nav className="navbar navbar-expand-lg navbar-light bg-light">
                <div className="container-fluid">
                    <NavLink className="navbar-brand" to="/">
                        <img src="/images/recipe-logo.jpg" alt="" width="100" className="d-inline-block pe-3" />
                        Recipes
                    </NavLink>
                    <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                        <span className="navbar-toggler-icon"></span>
                    </button>
                    <div className="collapse navbar-collapse" id="navbarNav">
                        <ul className="navbar-nav">
                            <li className="nav-item">
                                <NavLink className={"nav-link"} to="/Recipes">Recipes</NavLink>
                            </li>
                            <li className="nav-item">
                                <NavLink className={"nav-link"} to="/Meals">Meals</NavLink>
                            </li>
                            <li className="nav-item">
                                <NavLink className={"nav-link"} to="/Cookbooks">Cookbooks</NavLink>
                            </li>
                            <li className="nav-item">
                                <NavLink className={"nav-link"} to="/DataMaintenance">Data Maintenance</NavLink>
                            </li>

                            {/* <li className="nav-item dropdown">
                                <NavLink className="nav-link dropdown-toggle" to="#" id="cookbooksDropdown" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                                    Cookbooks
                                </NavLink>
                                <ul className="dropdown-menu" aria-labelledby="cookbooksDropdown">
                                    <li><NavLink className="dropdown-item" to="/CookbooksList">Cookbooks List</NavLink></li>
                                    <li><NavLink className="dropdown-item" to="/Cookbooks/MyCookbooks">My Cookbooks</NavLink></li>
                                    <li><NavLink className="dropdown-item" to="/Cookbooks/Create">Create New Cookbook</NavLink></li>
                                </ul>
                            </li> */}
                            <li className="nav-item">
                                <UserPanel />
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>

        </>
    )
}