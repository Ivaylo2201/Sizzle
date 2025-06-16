import { Suspense } from 'react';

import NotFoundErrorBoundary from '@/components/shared/NotFoundErrorBoundary';
import PageLayout from '@/components/layout/PageLayout';
import LoadingSpinner from '@/components/shared/LoadingSpinner';

type NotFoundErrorBoundaryLayoutProps = React.PropsWithChildren;

export default function NotFoundErrorBoundaryLayout({
  children
}: NotFoundErrorBoundaryLayoutProps) {
  return (
    <Suspense
      fallback={
        <PageLayout>
          <LoadingSpinner size={50} />
        </PageLayout>
      }
    >
      <NotFoundErrorBoundary>{children}</NotFoundErrorBoundary>
    </Suspense>
  );
}
