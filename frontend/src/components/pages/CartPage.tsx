import { Link } from 'react-router';
import { ArrowRight } from 'lucide-react';

import Page from '@/components/layout/PageLayout';
import ItemList from '@/components/ui/cart/ItemList';
import useCart from '@/lib/hooks/useCart';
import OrderSummary from '../ui/cart/OrderSummary';

export default function CartPage() {
  const { data: cart } = useCart();

  if (cart.items.length === 0) {
    return (
      <Page className=' flex-col'>
        <p className='font-rubik text-xl font-semibold text-theme-pink'>
          Your cart is empty.
        </p>
      </Page>
    );
  }

  return (
    <Page className='flex-col lg:flex-row lg:items-start gap-5'>
      <ItemList items={cart.items} />

      <div className='w-[20rem] bg-white font-rubik shadow-md rounded-lg px-10 pt-9 pb-6.5 flex flex-col gap-4'>
        <p className='text-xl font-bold uppercase'>Order summary</p>

        <OrderSummary total={cart.total} items={cart.items} />

        <Link
          className='bg-theme-pink flex justify-center items-center gap-1.5 text-white text-md px-6 py-2 my-4 rounded-full font-dmsans shadow-lg transition-colors duration-200 hover:bg-theme-orange'
          to='/cart/checkout'
        >
          Checkout <ArrowRight size={19} />
        </Link>
      </div>
    </Page>
  );
}
