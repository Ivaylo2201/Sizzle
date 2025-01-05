import CategoryList from '../components/common/categories/CategoryList';
import NavbarLayout from '../layouts/NavbarLayout';
import ProtectedLayout from '../layouts/ProtectedLayout';

export default function MenuPage() {
  return (
    <ProtectedLayout>
      <NavbarLayout idented>
        <CategoryList />
      </NavbarLayout>
    </ProtectedLayout>
  );
}
