import Page from '@/components/layout/PageLayout';
import useOrders from '@/lib/hooks/useOrders';
import OrdersList from '../ui/order/OrdersList';

export default function OrdersPage() {
  const { data: orders } = useOrders();

  return (
    <Page>
      <OrdersList orders={orders} />
    </Page>
  );
}
