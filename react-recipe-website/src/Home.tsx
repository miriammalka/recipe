import { useEffect, useState } from "react";
import { fetchDashboard } from "./DataUtility";
import { IDashboard } from "./DataInterfaces";

export default function Home() {
    const [dashboardData, setDashboardData] = useState<IDashboard[]>([]);

    useEffect(() => {
        const fetchData = async () => {
            const response = await fetchDashboard();
            setDashboardData(response);
        };
        fetchData;
    }, []);

    return (
        <>
            <div className="container">
                <h1 className="my-4">Recipe Website</h1>
                <div className="row">
                    <div className="col-3 mb-4">
                        <img className="img img-fluid" src="/images/recipe-logo.jpg" alt="Recipe Website" />
                    </div>
                    {dashboardData.map((item) => (
                        <div key={item.type} className="col-md-3 col-sm-6 mb-4">
                            <div className="card">
                                <img src={`/images/dashboard-images/${item.type}.jpg`} className="card-img-top" alt={item.type} />
                                <div className="card-body">
                                    <h5 className="card-title">{item.type}</h5>
                                    <p className="card-text">{item.number}</p>
                                </div>
                            </div>
                        </div>
                    ))}
                </div>
            </div>
        </>
    );
}