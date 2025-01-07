import React from "react";
import { useUserStore } from "@miriammalka/reactutils";
import Login from "./Login";

interface Props {
    element: React.ReactNode,
    requiredrole: string
}

export default function ProtectedRoute({ element, requiredrole }: Props) {
    const isLoggedIn = useUserStore((state) => state.isLoggedIn);
    const role = useUserStore((state) => state.role);
    const haspriviledge = requiredrole == "" || requiredrole == role;
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