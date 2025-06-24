import useItemRemove from '@/lib/hooks/useItemRemove';
import useQuantityChange from '@/lib/hooks/useQuantityChange';
import useQuantityUpdate from '@/lib/hooks/useQuantityUpdate';
import QuantityButtons from '@/components/ui/item/QuantityButtons';
import RemoveButton from '@/components/ui/button/RemoveButton';
import type { Item } from '@/utils/types/models/Item';

type ItemCardProps = Item;

export default function ItemCard({
  id,
  productPrice,
  productName,
  imageUrl,
  price,
  quantity
}: ItemCardProps) {
  const { mutate: updateQuantity } = useQuantityUpdate();
  const { mutate: removeItem } = useItemRemove();
  const { quantity: itemQuantity, handleQuantityChange } =
    useQuantityChange(quantity);

  const imageSrc = `${import.meta.env.VITE_IMAGE_BASE_URL}${imageUrl}`;

  const handleItemRemove = (id: number) => removeItem({ id });

  const handleQuantityUpdate = (quantity: number) => {
    handleQuantityChange(quantity);
    updateQuantity({ id, quantity });
  };

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
        quantity={itemQuantity}
        onChange={handleQuantityUpdate}
      />

      <RemoveButton callback={() => handleItemRemove(id)} />
    </article>
  );
}
