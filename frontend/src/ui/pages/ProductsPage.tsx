import { useParams } from 'react-router';

import Page from '@/ui/layouts/Page';
import ProductsList from '@/ui/components/product/ProductList';
import useProducts from '@/lib/hooks/useProducts';

export default function ProductsPage() {
  const { category } = useParams();
  const { data: products } = useProducts(category);

  return (
    <Page>
      <ProductsList products={products} />
    </Page>
  );
}
