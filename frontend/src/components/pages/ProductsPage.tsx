import { useParams } from 'react-router';

import useProducts from '@/lib/hooks/useProducts';
import Page from '@/components/layout/PageLayout';
import ProductsList from '@/components/ui/product/ProductList';

export default function ProductsPage() {
  const { category } = useParams();
  const { data: products } = useProducts(category);

  return (
    <Page>
      <ProductsList products={products} />
    </Page>
  );
}
