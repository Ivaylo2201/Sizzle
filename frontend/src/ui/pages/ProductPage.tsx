import { useParams } from 'react-router';

import useProduct from '@/lib/hooks/useProduct';
import Page from '@/ui/layouts/Page';

export default function ProductPage() {
  const { guid } = useParams();
  const { data: product } = useProduct(guid);

  return (
    <Page>
      <div>{product.productName}</div>
    </Page>
  );
}
