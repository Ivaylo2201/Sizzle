import { Link } from 'react-router-dom';
import ShoppingCart from '../../../icons/ShoppingCart';

type CartButtonProps = {};

export default function CartButton({}: CartButtonProps) {
  return (
    <Link
      to='/cart'
      className='hover:bg-theme-darkgray p-3 rounded-full relative'
    >
      <span className='text-xs font-Montserrat absolute top-0 right-0 bg-theme-red text-white size-5 flex justify-center items-center rounded-full'>
        5
      </span>
      <ShoppingCart variant='light' />
    </Link>
  );
}
