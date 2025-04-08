import { ICuisine } from "./DataInterfaces";

interface Props {
    cuisine: ICuisine,
    isSelected: boolean,
    onSelected: (cuisineId: number) => void
}

const imgpath = "/images/cuisine-images/";

export default function CuisineButton({ cuisine, isSelected, onSelected }: Props) {
    return (
        <div onClick={()=>onSelected(cuisine.cuisineId)} className={`btn d-block mb-2 ${isSelected ? "bg-secondary" : ""}`}>
            <figure className="figure">
                <img src={`${imgpath}${cuisine.cuisineName}.jpg`} className="figure-img img-fluid rounded" 
                style={{ width: 150, height: 150, objectFit: "cover" }} alt="..." 
                onError={(event) => (event.currentTarget.src = `${imgpath}Default.jpg`)}/>
                <figcaption className="figure-caption" style={{fontSize:20}}>{cuisine.cuisineName}</figcaption>
            </figure>
        </div>
    )
}