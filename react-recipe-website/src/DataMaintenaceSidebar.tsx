import { useEffect, useState } from 'react'
import { fetchCuisines, fetchIngredients, fetchUsers } from './DataUtility';

//pass in the selcted table into sidebar
interface Props {
    onOptionSelected: (selectedOption: string) => void;
}

export default function DataMaintenaceSidebar({ onOptionSelected }: Props) {
    //state variable to capture selected option
    const [selectedOption, setSelectedOption] = useState("users");
    //state variable to capture data for option selected
    // const [data, setData] = useState(null);

    // const fetchFunctions: Record<string, () => Promise<any>> = {
    //     users: fetchUsers,
    //     cuisines: fetchCuisines,
    //     ingredients: fetchIngredients,
    // };

    // //function to fetch data based on option selected - not sure if I need this function
    // useEffect(() => {
    //     const fetchData = async () => {
    //         try {
    //             if (fetchFunctions[selectedOption]) {
    //                 const responseData = await fetchFunctions[selectedOption]();
    //                 setData(responseData);
    //                 console.log(responseData);
    //             }
    //         }
    //         catch (error) {
    //             console.error("Error fetching data:", error);
    //             setData(null);
    //         }
    //     };
    //     fetchData();
    // },
    //     [selectedOption]);


    // const handleChange = (event: { target: { value: any; }; }) => {
    //     const selectedValue = event.target.value;
    //     setSelectedOption(selectedValue);
    // }

    return (<>
        <div>
            <div className="form-check">
                <input
                    className="form-check-input"
                    type="radio"
                    name="dataOptions"
                    value="users"
                    checked={selectedOption === "users"}
                    onChange={(e) => {
                        setSelectedOption(e.target.value);
                        console.log("seleced option:", e.target.value);
                        onOptionSelected(e.target.value);
                    }}
                />
                <label className="form-check-label">Users</label>
            </div>
            <div className="form-check">
                <input
                    className="form-check-input"
                    type="radio"
                    name="dataOptions"
                    value="cuisine"

                    checked={selectedOption === "cuisine"}
                    onChange={(e) => {
                        setSelectedOption(e.target.value);
                        console.log("seleced option:", e.target.value);
                        onOptionSelected(e.target.value);
                    }}
                />
                <label className="form-check-label">Cuisines</label>
            </div>
            <div className="form-check">
                <input
                    className="form-check-input"
                    type="radio"
                    name="dataOptions"
                    value="ingredient"
                    checked={selectedOption === "ingredient"}
                    onChange={(e) => {
                        setSelectedOption(e.target.value);
                        console.log("seleced option:", e.target.value);
                        onOptionSelected(e.target.value);
                    }}
                />
                <label className="form-check-label">Ingredients</label>
            </div>
            <div className="form-check">
                <input
                    className="form-check-input"
                    type="radio"
                    name="dataOptions"
                    value="course"

                    checked={selectedOption === "course"}
                    onChange={(e) => {
                        setSelectedOption(e.target.value);
                        console.log("seleced option:", e.target.value);
                        onOptionSelected(e.target.value);
                    }}
                />
                <label className="form-check-label">Courses</label>
            </div>
            <div className="form-check">
                <input
                    className="form-check-input"
                    type="radio"
                    name="dataOptions"
                    value="measurementType"

                    checked={selectedOption === "measurementType"}
                    onChange={(e) => {
                        setSelectedOption(e.target.value);
                        console.log("seleced option:", e.target.value);
                        onOptionSelected(e.target.value);
                    }}
                />
                <label className="form-check-label">Measurements</label>
            </div>


        </div>
    </>
    )
}
