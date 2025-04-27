import { useState } from 'react'


//pass in the selcted table into sidebar
interface Props {
    onOptionSelected: (selectedOption: string) => void;
}

export default function DataMaintenaceSidebar({ onOptionSelected }: Props) {
    //state variable to capture selected option
    const [selectedOption, setSelectedOption] = useState("users");
    
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
