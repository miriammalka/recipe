import React from "react";
import { getUserStore } from "@miriammalka/reactutils";
import Login from "./Login";

interface Props {
    element: React.ReactNode,
    requiredrole: number
}

export default function ProtectedRoute({ element, requiredrole }: Props) {
    const apiurl = import.meta.env.VITE_API_URL;
    const useUserStore = getUserStore(apiurl);
    const isLoggedIn = useUserStore((state) => state.isLoggedIn);
    const rolerank = useUserStore((state) => state.roleRank);
    const haspriviledge = rolerank >= requiredrole;
    if (!isLoggedIn) {
        return <Login frompath={location.pathname} />;
    }
    else if (!haspriviledge) {
        return <><div>You are not authorized to view this page.</div></>
    }
    else {
        return <>{element}</>;
    }
}