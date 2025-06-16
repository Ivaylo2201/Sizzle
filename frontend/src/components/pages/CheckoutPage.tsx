import Page from '@/components/layout/PageLayout';
import AuthenticatedLayout from '@/components/layout/AuthenticatedLayout';

export default function CheckoutPage() {
  return (
    <AuthenticatedLayout>
      <Page>checkout page</Page>
    </AuthenticatedLayout>
  );
}
