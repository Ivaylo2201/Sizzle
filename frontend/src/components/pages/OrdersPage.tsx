import Page from '@/components/layout/PageLayout';
import AuthenticatedLayout from '@/components/layout/AuthenticatedLayout';

export default function OrdersPage() {
  return (
    <AuthenticatedLayout>
      <Page>orders page</Page>
    </AuthenticatedLayout>
  );
}
