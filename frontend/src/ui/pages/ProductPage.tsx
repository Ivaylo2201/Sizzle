import { useEffect } from 'react';
import { useNavigate, useParams } from 'react-router';

import useProduct from '@/lib/hooks/useProduct';
import LoadingSpinner from '@/ui/shared/LoadingSpinner';
import Page from '@/ui/layouts/Page';

export default function ProductPage() {
  const { guid } = useParams();
  const navigate = useNavigate();
  const { data: product, isError } = useProduct(guid);

  useEffect(() => {
    if (isError) {
      navigate('/404');
      return;
    }
  }, [isError, navigate]);

  if (product === undefined) {
    return <LoadingSpinner />;
  }

  return (
    <Page>
      <div>{product.productName}</div>
    </Page>
  );
}
