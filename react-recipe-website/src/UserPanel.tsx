import { Link } from "react-router-dom";
import { useUserStore } from "./user/userstore"

export default function UserPanel() {
    const username = useUserStore((state) => state.username);
    const userrole = useUserStore((state) => state.role);
    const isLoggedIn = useUserStore((state) => state.isLoggedIn);
    const logout = useUserStore((state) => state.logout);

    return (
        <>
            {isLoggedIn ? (
                <div className="d-flex align-items-center nav-link">
                    <span className="me-2">{username}, {userrole}</span>
                    <button className="btn btn-outline-primary btn-sm" onClick={logout}>
                        Logout
                    </button>
                </div>
            ) : (
                <Link className="nav-link" to="/login">
                    Login
                </Link>
            )}
        </>
    );
}



