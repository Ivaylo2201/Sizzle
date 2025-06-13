import useProduct from '@/lib/hooks/useProduct';
import { useParams } from 'react-router'

export default function ProductPage() {
  const { productId } = useParams();
  const { data: product } = useProduct(productId);

  const imageUrl = `http://localhost:5199/${product?.imageUrl}`

  return (
    <></>
  )
}
