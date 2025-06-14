import ProductCard from '@/ui/shared/ProductCard';
import type { ShortProduct } from '@/utils/types/product/ShortProduct';

type ProductsListProps = {
  products: ShortProduct[]
}

export default function ProductsList({ products }: ProductsListProps) {
  return (
    <div className='w-4/5 px-10 flex flex-wrap justify-center items-center gap-y-8 gap-x-12'>
      {products.map((product) => (
        <ProductCard
          key={product.id}
          id={product.id}
          productName={product.productName}
          weight={product.weight}
          initialPrice={product.initialPrice}
          price={product.price}
          rating={product.rating}
          discountPercentage={product.discountPercentage}
          imageUrl={product.imageUrl}
        />
      ))}
    </div>
  );
}
