import { Link } from 'react-router-dom';
import CartButton from './CartButton';
import OrdersButton from './OrdersButton';
import useAuthStore from '../../../stores/authStore';

export default function AuthenticatedButtons() {
  const { logout } = useAuthStore();

  return (
    <section className='h-full flex items-center px-2 gap-7'>
      <div className='flex gap-2'>
        <OrdersButton />
        <CartButton />
      </div>
      <Link
        onClick={logout}
        to='/signin'
        className='bg-theme-red hover:bg-theme-lightred transition-colors duration-300 px-6 py-2 font-Montserrat text-white rounded-full uppercase'
      >
        Sign out
      </Link>
    </section>
  );
}
