import { createBrowserRouter } from "react-router-dom";
import App from "./App";
import Meals from "./Meals";
import Cookbooks from "./Cookbooks";
import Recipes from "./Recipes";

const router = createBrowserRouter([
    {
        path: "/", element: <App />, children: [
            { path: "/Recipes", element: <Recipes /> },
            { path: "/Meals", element: <Meals /> },
            { path: "/Cookbooks", element: <Cookbooks /> },
        ]
    },
]);

export default router;