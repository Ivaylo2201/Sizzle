import { Link } from 'react-router';
import { ArrowRight } from 'lucide-react';

import useCart from '@/lib/hooks/useCart';
import Page from '@/components/layout/PageLayout';
import ItemList from '@/components/ui/cart/ItemList';
import OrderSummary from '@/components/ui/cart/OrderSummary';

export default function CartPage() {
  const { data: cart } = useCart();

  if (cart.items.length === 0) {
    return (
      <Page className='flex-col'>
        <p className='font-rubik font-extrabold text-theme-orange text-center text-4xl'>
          Your cart is empty.
        </p>
        <Link
          className='bg-theme-pink text-white text-xl my-14 px-8 py-3 rounded-full font-dmsans shadow-lg transition-colors duration-200 hover:bg-theme-orange'
          to='/products/burgers'
        >
          How about a burger?
        </Link>
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
