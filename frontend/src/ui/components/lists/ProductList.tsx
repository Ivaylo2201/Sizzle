import useProducts from '@/lib/hooks/useProducts'
import ProductCard from '@/ui/shared/ProductCard';
import { useParams } from 'react-router';

export default function ProductList() {
  const { category } = useParams();
  const { data: products } = useProducts(category);

  return (
    <div className='flex flex-wrap justify-center items-center gap-5 py-10'>
      {products.map((product) => (
        <ProductCard product={product} />
      ))}
    </div>
  )
}
