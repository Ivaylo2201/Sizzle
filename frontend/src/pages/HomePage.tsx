import CategoryList from '../components/common/categories/CategoryList';
import ProtectedLayout from '../layouts/ProtectedLayout';

export default function HomePage() {
  return (
    <ProtectedLayout>
      <CategoryList />
    </ProtectedLayout>
  );
}
