import { createBrowserRouter } from "react-router-dom";
import App from "./App";
import Meals from "./Meals";
import Cookbooks from "./Cookbooks";
import Recipes from "./Recipes";
import ProtectedRoute from "./ProtectedRoute";
import Login from "./Login";
import Home from "./Home";
import DataMaintenance from "./DataMaintenance";



const router = createBrowserRouter([
    {
        path: "/", element: <App />, children: [
            { index: true, element: <Home /> },
            { path: "/Recipes", element: <ProtectedRoute element={<Recipes />} requiredrole={0} /> },
            { path: "/Meals", element: <ProtectedRoute element={<Meals />} requiredrole={0} /> },
            { path: "/Cookbooks", element: <ProtectedRoute element={<Cookbooks />} requiredrole={0} /> },
            { path: "/DataMaintenance", element: <ProtectedRoute element={<DataMaintenance />} requiredrole={0} /> },
            { path: "/Login", element: <Login frompath={location.pathname} /> }
        ]
    },
]);

export default router;