import { Link } from 'react-router';
import { ArrowRight } from 'lucide-react';

import Page from '@/components/layout/PageLayout';
import ItemList from '@/components/ui/cart/ItemList';
import Total from '@/components/ui/cart/Total';
import useCart from '@/lib/hooks/useCart';

export default function CartPage() {
  const { data: cart } = useCart();

  const hasItems = cart.items.length > 0;

  if (!hasItems) {
    return (
      <Page className=' flex-col'>
        <p className='font-rubik text-xl font-semibold text-theme-orange'>
          Your cart is empty.
        </p>
      </Page>
    );
  }

  return (
    <Page className='flex-col gap-8'>
      <ItemList items={cart.items} />
      <Total cart={cart} />
      <Link
        className='bg-theme-pink flex justify-center items-center gap-1.5 text-white text-md px-6 py-2 rounded-full font-dmsans shadow-lg transition-colors duration-200 hover:bg-theme-orange'
        to='/cart/checkout'
      >
        Checkout <ArrowRight size={19} />
      </Link>
    </Page>
  );
}
