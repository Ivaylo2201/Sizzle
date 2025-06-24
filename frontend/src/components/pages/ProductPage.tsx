import { useParams } from 'react-router';

import useProduct from '@/lib/hooks/useProduct';
import useAddToCart from '@/lib/hooks/useAddToCart';
import useQuantityControl from '@/lib/hooks/useQuantityChange';
import Page from '@/components/layout/PageLayout';
import Button from '@/components/shared/Button';
import SizzleRating from '@/components/shared/SizzleRating';
import QuantityButtons from '@/components/ui/item/QuantityButtons';
import DetailsAccordion from '@/components/ui/product/DetailsAccordion';
import IngredientsAccordion from '@/components/ui/product/IngredientsAccordion';
import ProductPrice from '@/components/ui/product/ProductPrice';
import ReviewForm from '@/components/ui/review/ReviewForm';
import ReviewList from '@/components/ui/review/ReviewList';

export default function ProductPage() {
  const { guid } = useParams();
  const { data: product } = useProduct(guid);
  const { mutate: addToCart } = useAddToCart();

  const { quantity, handleQuantityChange } = useQuantityControl();

  const handleAddToCart = () => {
    addToCart({ productId: product.id, quantity });
  };

  const imageSrc = `${import.meta.env.VITE_IMAGE_BASE_URL}${product.imageUrl}`;

  return (
    <Page>
      <div className='flex flex-col gap-16 justify-center items-center'>
        <div className='bg-white min-h-[40rem] md:h-[40rem] rounded-xl flex flex-col lg:flex-row items-center shadow-md p-10 font-rubik gap-10'>
          <img
            src={imageSrc}
            alt={`Image of ${product.productName}`}
            className='md:size-[35rem]'
          />
          <section className='flex flex-col gap-2'>
            <h1 className='text-2xl font-bold'>{product.productName}</h1>
            <div className='flex items-center gap-2'>
              <SizzleRating value={product.rating} readOnly />
              <span className='font-dmsans'>({product.reviews.length})</span>
            </div>
            <ProductPrice
              price={product.price}
              initialPrice={product.initialPrice}
              mode='page'
            />
            <p className='max-w-96 mt-2'>{product.description}</p>
            <div className='my-4'>
              <IngredientsAccordion ingredients={product.ingredients} />
              <DetailsAccordion
                weight={product.weight}
                calories={product.calories}
              />
            </div>
            <div className='flex justify-center items-center gap-6 my-6'>
              <QuantityButtons
                quantity={quantity}
                onChange={handleQuantityChange}
                orientation='horizontal'
              />
              <Button onClick={handleAddToCart}>Add to cart</Button>
            </div>
          </section>
        </div>
        <ReviewList reviews={product.reviews} />
        <ReviewForm product={product} />
      </div>
    </Page>
  );
}
