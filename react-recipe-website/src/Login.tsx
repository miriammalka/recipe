import { useForm } from "react-hook-form";
import { getUserStore } from "@miriammalka/reactutils";
import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";

type LoginFormInputs = { username: string; password: string; };

interface Props { frompath: string }

export default function Login({ frompath }: Props) {
    const { register, handleSubmit, formState: { errors } } = useForm<LoginFormInputs>();
    const apiurl = import.meta.env.VITE_API_URL;
    const useUserStore = getUserStore(apiurl);
    const login = useUserStore((state) => state.login);
    const isLoggedIn = useUserStore((state) => state.isLoggedIn);
    const [crashmsg, setCrashmsg] = useState("");
    const errormsg = useUserStore(state => state.errorMessage);
    const nav = useNavigate();

    useEffect(() => {
        if (isLoggedIn) {
            let pathval = !frompath || frompath == location.pathname ? "/" : frompath;
            nav(pathval);
        }
    }
        , [isLoggedIn, frompath, nav])
    const onFormSubmit = async (data: LoginFormInputs) => {
        try {
            setCrashmsg("");
            await login(data.username, data.password);
            console.log(isLoggedIn.toString());
        }
        catch (error: unknown) {
            if (error instanceof Error) {
                setCrashmsg(error.message);
            }
            else {
                setCrashmsg("error");
            }
        }
    }

    return (
        <>
            <h2 className="mb-4 text-center text-danger">{crashmsg || errormsg}</h2>
            <div className="d-flex justify-content-center">
                <div className="col-6">
                    <form onSubmit={handleSubmit(onFormSubmit)} className="needs-validation" noValidate>
                        <div className="mb-3">
                            <label className="form-label">Username</label>
                            <input type="text" className={`form-control ${errors.username ? 'is-invalid' : ''}`} {...register('username', { required: 'Username is required' })} />
                            {errors.username && <div className="invalid-feedback">{errors.username.message}</div>}
                        </div>
                        <div className="mb-3">
                            <label className="form-label">Password</label>
                            <input type="password" className={`form-control ${errors.password ? 'is-invalid' : ''}`}
                                {...register('password', { required: 'Password is required' })} />
                            {errors.password && <div className="invalid-feedback">{errors.password.message}</div>}
                        </div>
                        <button type="submit" className="btn btn-primary">Login</button>
                    </form>
                </div>
            </div>
        </>
    )
}

