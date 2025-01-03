import Rating from './Rating';
import DiscountLabel from './DiscountLabel';
import Product from '../../../types/Product';
import AddToCartButton from './AddToCartButton';

type ProductCardProps = Product;

export default function ProductCard({
  pk,
  imageUrl,
  discountPercentage,
  price,
  discountedPrice,
  title,
  rating = 0
}: ProductCardProps) {
  return (
    <div className='group p-2 inline-flex flex-col font-DMSans bg-white rounded-xl shadow-lg relative'>
      <div className='w-52 h-40 flex justify-center overflow-hidden'>
        <img
          className='h-full object-cover group-hover:scale-110 transition-all duration-300 hover:cursor-pointer'
          src={imageUrl}
          alt={title}
        />
      </div>
      <div className='flex justify-center items-center gap-2 font-bold mb-2'>
        {discountPercentage > 0 ? (
          <>
            <DiscountLabel discountPercentage={discountPercentage} />
            <span className='text-red-500 text-2xl'>${discountedPrice}</span>
            <span className='line-through'>${price}</span>
          </>
        ) : (
          <span className='text-red-500 text-2xl'>${price}</span>
        )}
      </div>
      <h1 className='text-center uppercase font-bold'>{title}</h1>
      <Rating stars={rating} />
      <AddToCartButton pk={pk} />
    </div>
  );
}
