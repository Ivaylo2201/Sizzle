import useAuthStore from '../../../stores/authStore';

import Orders from '../../../icons/Orders';
import ShoppingCart from '../../../icons/ShoppingCart';
import { useCartStore } from '../../../stores/cartStore';
import HeaderLink from './HeaderLink';

export default function AuthenticatedButtons() {
  const { signOut } = useAuthStore();
  const {
    cart: { items }
  } = useCartStore();

  return (
    <>
      <HeaderLink to='/orders'>
        <Orders variant='light' />
      </HeaderLink>
      <HeaderLink to='/cart' className='relative'>
        <span className='text-xs font-Montserrat absolute top-0 right-0 bg-theme-red text-white size-5 flex justify-center items-center rounded-full'>
          {items.length}
        </span>
        <ShoppingCart variant='light' />
      </HeaderLink>
      <HeaderLink to='/signout' onClick={signOut}>
        Sign out
      </HeaderLink>
    </>
  );
}
