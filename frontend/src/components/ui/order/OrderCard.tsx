import formatDate from '@/utils/helpers/formatDate';
import DeliveryAccordion from '@/components/ui/order/DeliveryAccordion';
import ItemsAccordion from '@/components/ui/order/ItemsAccordion';

import type { Order } from '@/utils/types/models/Order';

type OrderCardProps = Order;

export default function OrderCard({
  id,
  items,
  cityName,
  streetName,
  streetNumber,
  createdAt,
  total,
  notes
}: OrderCardProps) {
  return (
    <article className='min-w-96 p-6 font-rubik bg-white shadow-md cursor-pointer rounded-xl'>
      <div className='flex gap-2 items-center'>
        <h1 className='text-xl font-semibold'>Order #{id}</h1>
        <span className='text-theme-gray italic text-sm'>
          {formatDate(createdAt)}
        </span>
      </div>
      <ItemsAccordion items={items} />
      <DeliveryAccordion
        cityName={cityName}
        streetName={streetName}
        streetNumber={streetNumber}
        notes={notes}
      />
      <p className='text-theme-pink font-semibold mt-4'>
        Total: ${total.toFixed(2)}
      </p>
    </article>
  );
}
