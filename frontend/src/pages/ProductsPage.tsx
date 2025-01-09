import { useParams } from 'react-router-dom';
import useProducts from '../hooks/useProducts';
import HeaderWrapper from '../wrappers/HeaderWrapper';
import ProductCard from '../components/common/ProductCard/ProductCard';

type ProductsPageProps = {};

export default function ProductsPage({}: ProductsPageProps) {
  const { category } = useParams<{ category: string }>();
  const { data: products } = useProducts(category);

  return (
    <HeaderWrapper className='flex flex-wrap justify-center items-center gap-4'>
      <div className='h-full grid place-content-center gap-8 grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-5'>
        {products?.map((product) => (
          <ProductCard key={product.pk} {...product} />
        ))}
      </div>
    </HeaderWrapper>
  );
}
