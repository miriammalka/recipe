import { Link } from "react-router-dom";
import { getUserStore, useSessionTimeout } from "@miriammalka/reactutils";

export default function UserPanel() {
    const apiurl = import.meta.env.VITE_API_URL;
    const useUserStore = getUserStore(apiurl);
    const username = useUserStore((state) => state.userName);
    const rolename = useUserStore((state) => state.roleName);
    const isLoggedIn = useUserStore((state) => state.isLoggedIn);
    const logout = useUserStore((state) => state.logout);

    useSessionTimeout({
        apiUrl: apiurl,
        timeout: 1000 * 60 * 5,
        pathtologin: "/Login"
    })


    return (
        <> 
            {isLoggedIn ? (
                <div className="d-flex align-items-center nav-link">
                    <span className="me-2">{username}, {rolename}</span>
                    <button className="btn btn-outline-primary btn-sm" onClick={() => logout(username)}>
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



