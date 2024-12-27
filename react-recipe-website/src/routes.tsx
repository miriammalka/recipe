import { createBrowserRouter } from "react-router-dom";
import App from "./App";
import Meals from "./Meals";
import Cookbooks from "./Cookbooks";
import Recipes from "./Recipes";
import ProtectedRoute from "./ProtectedRoute";
import Login from "./Login";

const router = createBrowserRouter([
    {
        path: "/", element: <App />, children: [
            //need to figure out how to only allow admin to delete and why I cannot login here
            { path: "/Recipes", element: <ProtectedRoute element={<Recipes />} requiredrole="" /> },
            { path: "/Meals", element: <ProtectedRoute element={<Meals />} requiredrole="" /> },
            { path: "/Cookbooks", element: <ProtectedRoute element={<Cookbooks />} requiredrole="" /> },
            {path: "/Login", element: <Login/>}
        ]
    },
]);

export default router;