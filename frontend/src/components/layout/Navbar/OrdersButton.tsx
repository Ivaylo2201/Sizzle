import { Link } from "react-router-dom";
import Orders from "../../../icons/Orders";

type OrdersButtonProps = {

}

export default function OrdersButton({}: OrdersButtonProps) {
  return (
    <Link
      to='/orders'
      className='hover:bg-theme-darkgray p-3 rounded-full relative'
    >
      <Orders variant='light' />
    </Link>
  );
};
