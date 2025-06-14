import React from 'react';
import { useNavigate } from 'react-router';
import { Rating } from '@mantine/core';

import type { ProductShortDto } from '@/utils/types/product/ProductShortDto';
import ProductPrice from '@/ui/components/product/ProductPrice';
import TagContainer from '@/ui/shared//TagContainer';
import Tag from '@/ui/shared/Tag';
import Button from '@/ui/shared/Button';

type ProductCardProps = ProductShortDto;

function ProductCard({
  id,
  productName,
  weight,
  initialPrice,
  price,
  rating,
  discountPercentage,
  imageUrl
}: ProductCardProps) {
  const navigate = useNavigate();

  const goToProduct = () => navigate(`/product/${id}`);

  const addToCart = (e: React.MouseEvent<HTMLButtonElement>) => {
    e.stopPropagation();
    // TODO: add to cart
  };

  const imageSrc = `${import.meta.env.VITE_IMAGE_BASE_URL}${imageUrl}`;
  const isDiscounted = discountPercentage > 0;
  const isFavourite = rating >= 4;

  return (
    <article
      onClick={goToProduct}
      className='group w-[22rem] p-6 bg-white shadow-md cursor-pointer rounded-xl flex flex-col justify-center gap-2 relative overflow-hidden'
    >
      <TagContainer>
        {isFavourite && <Tag className='bg-theme-orange' content='Favourite' />}
        {isDiscounted && (
          <Tag className='bg-theme-pink' content={`-${discountPercentage}%`} />
        )}
      </TagContainer>

      <img
        src={imageSrc}
        alt={`Image of ${productName}`}
        className='h-72 z-0 object-contain group-hover:scale-105 cursor-pointer duration-500 transition-transform'
      />

      <div className='flex flex-col gap-1'>
        <Rating
          value={rating}
          readOnly
          className='mb-1.5'
          style={{ '--rating-color': 'var(--color-theme-orange)' }}
        />

        <div className='flex items-end font-rubik gap-1'>
          <h1 className='text-xl font-semibold uppercase'>
            {productName}
            <span className='font-normal text-theme-beige'>,</span>
          </h1>
          <h3 className='text-theme-gray'>{weight} gr.</h3>
        </div>

        <ProductPrice initialPrice={initialPrice} price={price} />

        <Button className='self-start mt-2' onClick={addToCart}>
          Order now
        </Button>
      </div>
    </article>
  );
}

export default ProductCard;
