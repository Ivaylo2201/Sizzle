import { useState } from 'react';

import QuantityButtons from '@/components/ui/item/QuantityButtons';
import useQuantityChange from '@/lib/hooks/useQuantityChange';
import type { Item } from '@/utils/types/models/Item';
import useItemRemove from '@/lib/hooks/useItemRemove';
import RemoveItemButton from './RemoveItemButton';

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
  const { mutate: changeQuantity } = useQuantityChange();
  const { mutate: removeItem } = useItemRemove();

  const imageSrc = `${import.meta.env.VITE_IMAGE_BASE_URL}${imageUrl}`;

  const handleQuantityChange = (quantity: number) => {
    if (quantity >= 1 && quantity <= 15) {
      setSelectedQuantity(quantity);
      changeQuantity({ id, quantity });
    }
  };

  const handleItemRemove = (id: number) => removeItem({ id });

  return (
    <article className='p-6 font-rubik bg-white shadow-md cursor-pointer rounded-xl flex items-center gap-5'>
      <img
        src={imageSrc}
        alt={`Image of ${productName}`}
        className='h-32 z-0 object-contain'
      />

      <div className='min-w-[6rem] sm:min-w-[16rem] md:min-w-[18rem] lg:min-w-[27rem] flex flex-col gap-5'>
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

      <RemoveItemButton callback={() => handleItemRemove(id)} />
    </article>
  );
}
