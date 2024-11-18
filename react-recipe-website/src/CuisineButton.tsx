import { ICuisine } from "./DataInterfaces";

interface Props {
    cuisine: ICuisine,
    isSelected: boolean,
    onSelected: (cuisineId: number) => void
}

export default function CuisineButton({ cuisine, isSelected, onSelected }: Props) {
    return (
        <div onClick={()=>onSelected(cuisine.cuisineId)} className={`btn d-block mb-2 ${isSelected ? "bg-secondary" : ""}`}>
            <figure className="figure">
                <img src={`/images/cuisine-images/${cuisine.cuisineName}.jpg`} className="figure-img img-fluid rounded" style={{ width: 150, height: 150, objectFit: "cover" }} alt="..." />
                <figcaption className="figure-caption" style={{fontSize:20}}>{cuisine.cuisineName}</figcaption>
            </figure>
        </div>
    )
}