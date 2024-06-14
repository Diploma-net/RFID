import { useLocation, Navigate, Outlet } from 'react-router-dom';
import useAuth from '../hook/useAuth'


export default function RequireAuth() {
    const location = useLocation();
    const {userInfo} = useAuth();

    if (localStorage.getItem("user") !== userInfo.userName || localStorage.getItem("user") == null) {
        return <Navigate to='/login' state={{from: location}} />
    } 

    return (
        <>
         <Outlet />
        </>
        
    )
}