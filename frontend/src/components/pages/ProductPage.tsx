import { useState } from 'react';
import { useParams } from 'react-router';
import { Rating } from '@mantine/core';

import useProduct from '@/lib/hooks/useProduct';
import useAddToCart from '@/lib/hooks/useAddToCart';
import Page from '@/components/layout/PageLayout';
import Button from '@/components/shared/Button';
import IngredientsList from '@/components/ui/product/IngredientsAccordion';
import DetailsAccordion from '@/components/ui/product/DetailsAccordion';
import ProductPrice from '@/components/ui/product/ProductPrice';
import QuantityButtons from '@/components/ui/item/QuantityButtons';
import ReviewList from '@/components/ui/review/ReviewList';
import ReviewForm from '@/components/ui/review/ReviewForm';

export default function ProductPage() {
  const { guid } = useParams();
  const { data: product } = useProduct(guid);
  const { mutate } = useAddToCart();

  const [selectedQuantity, setSelectedQuantity] = useState<number>(1);

  const handleQuantityChange = (quantity: number) => {
    if (quantity >= 1 && quantity <= 15) {
      setSelectedQuantity(quantity);
    }
  };

  const addToCart = () =>
    mutate({ productId: product.id, quantity: selectedQuantity });
  
  const imageSrc = `${import.meta.env.VITE_IMAGE_BASE_URL}${product.imageUrl}`;

  return (
    <Page>
      <div className='flex flex-col gap-9 justify-center items-center'>
        <div className='bg-white min-h-[32rem] rounded-xl flex flex-col lg:flex-row items-center shadow-md p-10 font-rubik gap-10'>
          <img src={imageSrc} alt={`Image of ${product.productName}`} />
          <section className='flex flex-col gap-2'>
            <h1 className='text-2xl font-bold'>{product.productName}</h1>
            <div className='flex items-center gap-2'>
              <Rating
                value={product.rating}
                readOnly
                style={{ '--rating-color': 'var(--color-theme-orange)' }}
              />
              <span className='font-dmsans'>({product.reviews.length})</span>
            </div>
            <ProductPrice
              price={product.price}
              initialPrice={product.initialPrice}
              mode='page'
            />
            <p className='max-w-96'>{product.description}</p>
            <IngredientsList ingredients={product.ingredients} />
            <DetailsAccordion
              weight={product.weight}
              calories={product.calories}
            />
            <div className='flex justify-center items-center gap-6 my-6'>
              <QuantityButtons
                quantity={selectedQuantity}
                onChange={handleQuantityChange}
                orientation='horizontal'
              />
              <Button onClick={addToCart}>Add to cart</Button>
            </div>
          </section>
        </div>
        <ReviewList reviews={product.reviews} />
        <ReviewForm productId={product.id} />
      </div>
    </Page>
  );
}
