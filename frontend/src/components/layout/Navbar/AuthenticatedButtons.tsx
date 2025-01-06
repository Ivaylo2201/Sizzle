import useAuthStore from '../../../stores/authStore';
import Navlink from './Navlink';
import Orders from '../../../icons/Orders';
import ShoppingCart from '../../../icons/ShoppingCart';
import { useCartStore } from '../../../stores/cartStore';

export default function AuthenticatedButtons() {
  const { signOut } = useAuthStore();
  const {
    cart: { items }
  } = useCartStore();

  return (
    <>
      <Navlink to='/orders'>
        <Orders variant='light' />
      </Navlink>
      <Navlink to='/cart' className='relative'>
        <span className='text-xs font-Montserrat absolute top-0 right-0 bg-theme-red text-white size-5 flex justify-center items-center rounded-full'>
          {items.length}
        </span>
        <ShoppingCart variant='light' />
      </Navlink>
      <Navlink to='/signout' onClick={signOut}>
        Sign out
      </Navlink>
    </>
  );
}
