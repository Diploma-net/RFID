import { Link } from 'react-router-dom'

export default function Notfoundpage(){
    return(
        <div>
            Такой страницы не существует. Перейдите <Link to="/">на главную</Link>
        </div>
    )
}