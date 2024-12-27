import { useForm } from "react-hook-form";
import { useUserStore } from "./user/userstore";

type LoginFormInputs = { username: string; password: string; };

export default function Login() {
    const { register, handleSubmit, formState: { errors } } = useForm<LoginFormInputs>();
    const login = useUserStore((state) => state.login);
    const onFormSubmit = async (data: LoginFormInputs) => {
        await login(data.username, data.password);
        console.log(isLoggedIn.toString());
    }
    const isLoggedIn = useUserStore((state) => state.isLoggedIn);
    return (
        <>
            <div  style={{margin:4}}>Logged In = {isLoggedIn.toString()}</div>
            <form onSubmit={handleSubmit(onFormSubmit)}>
                <label style={{margin:4}}>Username</label>
                <input  style={{margin:4}} type="text" {...register("username", { required: "Username is required" })} />
                {errors.username && <span>{errors.username.message}</span>}
                <br />
                <label  style={{margin:4}}>Password</label>
                <input  style={{margin:4}} type="password" {...register("password", { required: "Password is required" })} />
                {errors.password && <span>{errors.password.message}</span>}
                <br />
                <button  style={{margin:4}} className="btn btn-outline-primary" type="submit">Login</button>
            </form>
        </>
    )
}
