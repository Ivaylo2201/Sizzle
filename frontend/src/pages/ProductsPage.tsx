import { useParams } from 'react-router-dom';
import NavbarLayout from '../layouts/NavbarLayout';
import ProductsList from '../components/common/product/ProductsList';

type ProductsPageProps = {};

export default function ProductsPage({}: ProductsPageProps) {
  const { category } = useParams() as { category: string };
  console.log("rendered with category", category);

  return (
    <NavbarLayout idented>
      <ProductsList category={category} />
    </NavbarLayout>
  );
}
