import { create } from "zustand"

interface User {
    username: string,
    role: string,
    isLoggedIn: boolean,
    login: (username: string, password: string) => Promise<void>,
    logout: () => void,
}

const keyname = "userstore";
//need to figure out what the mistake was that I made in this file
export const useUserStore = create<User>(
    (set) => {
        const storedvalue = sessionStorage.getItem(keyname);
        const initialvalues = storedvalue ?
            JSON.parse(storedvalue) :
            { username: "", role: "", isLoggedIn: false }
        return {
            ...initialvalues,
            logout: () => {
                const newstate = { username: "", role: "", isLoggedIn: false };
                sessionStorage.setItem(keyname, JSON.stringify(newstate));
                set(newstate);
            },
            login: async (username: string, password: string) => {
                const roleval = username.toLowerCase().startsWith("a") && password != "" ? "admin" : "user";
                const newstate = { username: username, role: roleval, isLoggedIn: true };
                sessionStorage.setItem(keyname, JSON.stringify(newstate));
                set(newstate);
            }
        }
    }
)