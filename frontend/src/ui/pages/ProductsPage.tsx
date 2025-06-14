import { useNavigate, useParams } from 'react-router';
import { useEffect } from 'react';

import Page from '@/ui/layouts/Page';
import ProductsList from '@/ui/components/product/ProductList';
import useProducts from '@/lib/hooks/useProducts';
import LoadingSpinner from '@/ui/shared/LoadingSpinner';

export default function ProductPage() {
  const { category } = useParams();
  const navigate = useNavigate();
  const { data: products, isError } = useProducts(category);

  useEffect(() => {
    if (isError) {
      navigate('/404');
      return;
    }
  }, [isError, navigate]);

  if (products === undefined) {
    return <LoadingSpinner />;
  }

  return (
    <Page>
      <ProductsList products={products} />
    </Page>
  );
}
