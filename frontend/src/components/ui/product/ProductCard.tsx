import React from 'react';
import { useNavigate } from 'react-router';
import { Rating } from '@mantine/core';

import type { ShortProduct } from '@/utils/types/models/ShortProduct';
import Button from '@/components/shared/Button';
import TagContainer from '@/components/ui/tag/TagContainer';
import Tag from '@/components/ui/tag/Tag';
import ProductPrice from '@/components/ui/product/ProductPrice';
import useAddToCart from '@/lib/hooks/useAddToCart';
import SizzleRating from '@/components/shared/SizzleRating';

type ProductCardProps = ShortProduct;

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
  const { mutate } = useAddToCart();

  const goToProduct = () => {
    navigate(`/product/${id}`);
  };

  const addToCart = (e: React.MouseEvent<HTMLButtonElement>) => {
    e.stopPropagation(); // Prevent sending the user to the product's page
    mutate({ productId: id });
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
        <SizzleRating value={rating} readOnly className='mb-1.5' />

        <div className='flex items-end font-rubik gap-1'>
          <h1 className='text-xl font-semibold uppercase'>
            {productName}
            <span className='font-normal text-theme-beige'>,</span>
          </h1>
          <h3 className='text-theme-gray'>{weight} gr.</h3>
        </div>

        <ProductPrice initialPrice={initialPrice} price={price} mode='card' />

        <Button className='self-start mt-2' onClick={addToCart}>
          Order now
        </Button>
      </div>
    </article>
  );
}

export default ProductCard;
