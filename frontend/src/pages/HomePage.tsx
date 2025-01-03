import CategoryList from '../components/common/categories/CategoryList';
import ProductCard from '../components/common/product/ProductCard';
import NavbarLayout from '../layouts/NavbarLayout';
import ProtectedLayout from '../layouts/ProtectedLayout';

import Product from '../types/Product';

const products: Product[] = [
  // {
  //   pk: 1,
  //   imageUrl: doner,
  //   discountPercentage: 15,
  //   price: 20,
  //   discountedPrice: 16,
  //   title: 'Doner'
  // },

  // {
  //   pk: 3,
  //   imageUrl: salad,
  //   discountPercentage: 15,
  //   price: 20,
  //   discountedPrice: 16,
  //   title: 'Salad',
  //   rating: 3
  // }
];

export default function HomePage() {
  return (
    <ProtectedLayout>
      <NavbarLayout>
        <CategoryList />
        <div className='flex gap-3'>
          {products.map((product) => (
            <ProductCard {...product}
            />
          ))}
        </div>
      </NavbarLayout>
    </ProtectedLayout>
  );
}
