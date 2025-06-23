import type { Item } from '@/utils/types/models/Item';

type OrderSummaryProps = {
  total: number;
  items: Item[];
};

export default function OrderSummary({ items, total }: OrderSummaryProps) {
  const totalItems = items.reduce(
    (accumulator, current) => accumulator + current.quantity,
    0
  );

  return (
    <div>
      {items.map((item, i) => (
        <article
          key={i}
          className='flex justify-between text-sm font-normal text-theme-gray'
        >
          <p>
            {item.quantity}x {item.productName}
          </p>
          <p>${item.price.toFixed(2)}</p>
        </article>
      ))}

      <hr className='my-5' />

      <section className='flex justify-between text-md font-normal text-theme-gray'>
        <p>
          Total -{' '}
          <span className='text-theme-pink font-bold'>{totalItems}</span>{' '}
          {totalItems > 1 ? 'items' : 'item'}
        </p>
        <p className='text-theme-pink font-bold'>${total.toFixed(2)}</p>
      </section>
    </div>
  );
}
