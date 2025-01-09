import Rating from './Rating';
import DiscountLabel from './DiscountLabel';
import AddToCartButton from './AddToCartButton';
import Product from '../../../types/product';

const root: string = import .meta.env.VITE_BACKEND_URL

export default function ProductCard({
  pk,
  name,
  base_price,
  discount_percentage,
  image,
  price,
}: Product) {
  return (
    <div className='group p-2 inline-flex flex-col font-DMSans bg-white rounded-xl shadow-lg relative'>
      <div className='w-52 h-40 flex justify-center overflow-hidden'>
        <img
          className='h-full object-contain group-hover:scale-110 transition-all duration-300 hover:cursor-pointer'
          src={`${root}${image}`}
          alt={name}
        />
      </div>
      <div className='flex justify-center items-center gap-2 font-bold mb-2'>
        {discount_percentage > 0 ? (
          <>
            <DiscountLabel discountPercentage={discount_percentage} />
            <span className='text-red-500 text-2xl'>
              ${price}
            </span>
            <span className='line-through'>${base_price}</span>
          </>
        ) : (
          <span className='text-red-500 text-2xl'>${base_price}</span>
        )}
      </div>
      <h1 className='text-center uppercase font-bold'>{name}</h1>
      <Rating stars={2} />
      <AddToCartButton pk={pk} />
    </div>
  );
}
