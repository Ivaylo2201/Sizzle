import ShoppingCart from '../../../icons/ShoppingCart';
import { useCartStore } from '../../../stores/cartStore';
import useAuthStore from '../../../stores/authStore';
import {  useNavigate } from 'react-router-dom';

type AddToCartButtonProps = {
  pk: number;
};

export default function AddToCartButton({ pk }: AddToCartButtonProps) {
  const { add } = useCartStore();
  const navigate = useNavigate();
  const { isAuthenticated } = useAuthStore();

  function buy(pk: number) {
    if (!isAuthenticated) {
      navigate('/auth/signin');
      return;
    }

    add(pk, 1);
  }

  return (
    <div className='flex justify-center my-5'>
      <button
        onClick={() => buy(pk)}
        className='flex justify-center items-center gap-2 bg-theme-darkgray hover:bg-opacity-85 transition-all duration-300 px-6 py-2 rounded-full font-DMSans text-white text-xs uppercase font-bold'
      >
        <ShoppingCart variant='light' />
        Add to cart
      </button>
    </div>
  );
}
