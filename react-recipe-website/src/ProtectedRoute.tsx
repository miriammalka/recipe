import React from "react";
import { getUserStore } from "@miriammalka/reactutils";
import Login from "./Login";

interface Props {
    element: React.ReactNode,
    requiredrole: string
}

export default function ProtectedRoute({ element, requiredrole }: Props) {
    const apiurl = import.meta.env.VITE_API_URL;
    const useUserStore = getUserStore(apiurl);
    const isLoggedIn = useUserStore((state) => state.isLoggedIn);
    const rolerank = useUserStore((state) => state.roleName);
    const haspriviledge = requiredrole == "" || requiredrole == rolerank;
    if (!isLoggedIn) {
        return <Login />;
    }
    else if (!haspriviledge) {
        return <><div>You are not autorized to view this page.</div></>
    }
    else {
        return <>{element}</>;
    }
}