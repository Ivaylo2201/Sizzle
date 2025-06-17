import type { Cart } from '@/utils/types/models/Cart';

type TotalProps = {
  cart: Cart;
};

export default function Total({ cart }: TotalProps) {
  return (
    <div className='font-rubik bg-white shadow-md rounded-full px-6 py-2 flex items-center gap-2'>
      <span>Total:</span>
      <p className='flex items-baseline gap-1'>
        <span className='text-theme-pink font-semibold'>
          ${cart.total.toFixed(2)}
        </span>
        <span className='text-theme-gray text-md'>
          ({cart.items.reduce((total, item) => total + item.quantity, 0)} Items)
        </span>
      </p>
    </div>
  );
}
