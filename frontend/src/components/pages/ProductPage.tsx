import { useParams } from 'react-router';

import useProduct from '@/lib/hooks/useProduct';
import Page from '@/components/layout/PageLayout';
import { Rating } from '@mantine/core';
import Button from '../ui/button/Button';
import useAddToCart from '@/lib/hooks/useAddToCart';
import React from 'react';
import DetailsTable from '../ui/product/DetailsTable';
import IngredientsList from '../ui/product/IngredientsList';

export default function ProductPage() {
  const { guid } = useParams();
  const { data: product } = useProduct(guid);

  const { mutate } = useAddToCart();

  const addToCart = (e: React.MouseEvent<HTMLButtonElement>) => {
    e.stopPropagation();
    mutate({ productId: product.id });
  };

  const imageSrc = `${import.meta.env.VITE_IMAGE_BASE_URL}${product.imageUrl}`;

  return (
    <Page>
      <div className='flex flex-col gap-10 md:gap-30 md:flex-row justify-center'>
        <img src={imageSrc} className='md:size-[35rem] object-contain' />
        <section className='flex flex-col gap-10 font-rubik'>
          <div className='flex flex-col items-start gap-2'>
            <h1 className='font-bold text-2xl uppercase'>
              {product.productName},{' '}
              <span className='text-theme-gray text-sm font-normal'>
                {product.categoryName}
              </span>
            </h1>
            <Rating
              size='lg'
              value={product.rating}
              readOnly
              style={{ '--rating-color': 'var(--color-theme-orange)' }}
            />
          </div>
          <p className='max-w-[30rem] text-theme-gray italic'>
            {product.description}
          </p>
          <IngredientsList ingredients={product.ingredients} />
          <DetailsTable weight={product.weight} calories={product.calories} />
          <Button className='self-start mt-2' onClick={addToCart}>
            Order now
          </Button>
        </section>
      </div>
    </Page>
  );
}
