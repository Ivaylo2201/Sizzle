import Page from '@/components/layout/PageLayout';
import AuthenticatedLayout from '@/components/layout/AuthenticatedLayout';
import useCart from '@/lib/hooks/useCart';
import ItemList from '@/components/ui/item/ItemList';

export default function CartPage() {
  const { data: cart } = useCart();

  const hasItems = cart.items.length > 0;

  return (
    <AuthenticatedLayout>
      <Page className='items-start'>
        {hasItems ? (
          <ItemList items={cart.items} />
        ) : (
          <p className='font-rubik text-xl font-semibold text-theme-orange'>Your cart is empty.</p>
        )}
        
      </Page>
    </AuthenticatedLayout>
  );
}
