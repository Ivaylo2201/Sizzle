import type { ShortProduct } from '@/utils/types/product/ShortProduct';
import { useNavigate } from 'react-router';
import DiscountLabel from './DiscountLabel';
import { Rating } from '@mantine/core';
import ProductPrice from './ProductPrice';

type ProductCardProps = ShortProduct;

export default function ProductCard({ id, productName, initialPrice, price, rating, discountPercentage, imageUrl }: ProductCardProps) {
  const navigate = useNavigate();
  const goToProduct = () => navigate(`/product/${id}`);

  return (
    <article className='w-[22rem] p-6 bg-white shadow-md rounded-xl flex flex-col justify-center gap-2 relative overflow-hidden'>
      {discountPercentage > 0 && (
        <DiscountLabel discountPercentage={discountPercentage} />
      )}

      <img
        src={`${import.meta.env.VITE_IMAGE_BASE_URL}/${imageUrl}`}
        alt={`Image of ${productName}`}
        className='h-72 object-contain hover:scale-105 cursor-pointer duration-500 transition-transform'
        onClick={goToProduct}
      />

      <div className='flex flex-col gap-1'>
        <Rating
          value={rating}
          color='#fa8173'
          readOnly
          className='mb-1.5'
        />

        <h1 className='text-xl font-rubik font-semibold uppercase'>
          {productName}
        </h1>

        <ProductPrice
          initialPrice={initialPrice}
          price={price}
        />

        <button
          className='self-start mt-2 font-dmsans font-bold bg-theme-pink text-white px-4 py-1.5 rounded-md cursor-pointer duration-150 transition-colors hover:bg-theme-lightpink'
          onClick={goToProduct}
        >
          Order now
        </button>
      </div>
    </article>
  );
}
