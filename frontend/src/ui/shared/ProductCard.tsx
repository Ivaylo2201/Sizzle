import { useNavigate } from 'react-router';
import { Rating } from '@mantine/core';

import type { ShortProduct } from '@/utils/types/product/ShortProduct';
import DiscountLabel from '@/ui/shared/Tag';
import ProductPrice from '@/ui/shared/ProductPrice';
import TagContainer from './TagContainer';
import Tag from '@/ui/shared/Tag';

type ProductCardProps = ShortProduct;

export default function ProductCard({
  id,
  productName,
  initialPrice,
  price,
  rating,
  discountPercentage,
  imageUrl
}: ProductCardProps) {
  const navigate = useNavigate();
  const goToProduct = () => navigate(`/product/${id}`);

  const imageSrc = `${import.meta.env.VITE_IMAGE_BASE_URL}${imageUrl}`;
  const isDiscounted = discountPercentage > 0;
  const isFavourite = rating >= 4;

  return (
    <article className='w-[22rem] p-6 bg-white shadow-md rounded-xl flex flex-col justify-center gap-2 relative overflow-hidden'>
      <TagContainer className='z-50'>
        {isFavourite && (
          <Tag className='bg-theme-orange font-bold' content='Favourite' />
        )}
        {isDiscounted && (
          <Tag className='bg-theme-pink' content={`-${discountPercentage}%`} />
        )}
      </TagContainer>

      <img
        src={imageSrc}
        alt={`Image of ${productName}`}
        className='h-72 z-0 object-contain hover:scale-105 cursor-pointer duration-500 transition-transform'
        onClick={goToProduct}
      />

      <div className='flex flex-col gap-1'>
        <Rating
          value={rating}
          readOnly
          className='mb-1.5'
          style={{ '--rating-color': 'var(--color-theme-orange)' }}
        />

        <h1 className='text-xl font-rubik font-semibold uppercase'>
          {productName}
        </h1>

        <ProductPrice initialPrice={initialPrice} price={price} />

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
