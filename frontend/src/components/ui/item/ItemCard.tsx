import type { Item } from '@/utils/types/models/Item';
import { useState } from 'react';
import QuantityButtons from './QuantityButtons';
import useQuantityChange from '@/lib/hooks/useQuantityChange';

type ItemCardProps = Item;

export default function ItemCard({
  id,
  productPrice,
  productName,
  imageUrl,
  price,
  quantity
}: ItemCardProps) {
  const [selectedQuantity, setSelectedQuantity] = useState<number>(quantity);
  const { mutate } = useQuantityChange();

  const imageSrc = `${import.meta.env.VITE_IMAGE_BASE_URL}${imageUrl}`;

  const handleQuantityChange = (quantity: number) => {
    if (quantity >= 1 && quantity <= 15) {
      setSelectedQuantity(quantity);
    }
    mutate({ id, quantity });
  };

  return (
    <article className='p-6 font-rubik bg-white shadow-md cursor-pointer rounded-xl flex items-center gap-5 relative overflow-hidden'>
      <img
        src={imageSrc}
        alt={`Image of ${productName}`}
        className='h-32 z-0 object-contain group-hover:scale-105 cursor-pointer duration-500 transition-transform'
      />

      <div className='min-w-[22rem] flex flex-col gap-5'>
        <div>
          <h1 className='text-xl font-semibold uppercase line-clamp-1'>
            {productName}
          </h1>
          <span className='text-sm font-normal text-theme-gray'>
            Product price: ${productPrice.toFixed(2)}
          </span>
        </div>
        <p className='text-xl font-rubik font-bold text-theme-pink'>
          ${price.toFixed(2)}
        </p>
      </div>

      <QuantityButtons
        quantity={selectedQuantity}
        onChange={handleQuantityChange}
      />
    </article>
  );
}
