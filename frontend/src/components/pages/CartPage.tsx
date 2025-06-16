import Page from '@/components/layout/PageLayout';
import AuthenticatedLayout from '@/components/layout/AuthenticatedLayout';

export default function CartPage() {
  return (
    <AuthenticatedLayout>
      <Page>cart page</Page>
    </AuthenticatedLayout>
  );
}
