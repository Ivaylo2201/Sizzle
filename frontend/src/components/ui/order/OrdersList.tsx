import type { Order } from '@/utils/types/models/Order';
import OrderCard from './OrderCard';

type OrdersListProps = {
  orders: Order[];
};

export default function OrdersList({ orders }: OrdersListProps) {
  return (
    <ul className='grid grid-cols-1 md:grid-cols-2 justify-center items-center gap-4'>
      {orders.map((order) => (
        <li key={order.id}>
          <OrderCard {...order} />
        </li>
      ))}
    </ul>
  );
}
