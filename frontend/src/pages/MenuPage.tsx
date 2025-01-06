import CategoryList from '../components/common/categories/CategoryList';
import NavbarLayout from '../layouts/NavbarLayout';

export default function MenuPage() {
  return (
    <NavbarLayout idented>
      <CategoryList />
    </NavbarLayout>
  );
}
