import type { ShortProduct } from '@/utils/types/models/ShortProduct';
import ProductCard from '@/components/ui/product/ProductCard';

type ProductsListProps = {
  products: ShortProduct[];
};

export default function ProductsList({ products }: ProductsListProps) {
  return (
    <div className='grid grid-cols-1 md:grid-cols-2 xl:grid-cols-3 place-items-center gap-x-12 gap-y-8'>
      {products.map((product) => (
        <ProductCard key={product.id} {...product} />
      ))}
    </div>
  );
}
