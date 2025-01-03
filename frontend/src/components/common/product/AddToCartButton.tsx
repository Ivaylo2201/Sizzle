import { toast } from 'react-toastify';
import ShoppingCart from '../../../icons/ShoppingCart';

type AddToCartButtonProps = {
  pk: number;
};

export default function AddToCartButton({ pk }: AddToCartButtonProps) {
  function buy(id: number) {
    return toast.success(`Successfully product ${id} added to cart!`);
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
