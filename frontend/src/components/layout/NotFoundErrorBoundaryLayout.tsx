import { Suspense } from 'react';

import NotFoundErrorBoundary from '@/components/shared/NotFoundErrorBoundary';
import PageLayout from '@/components/layout/PageLayout';
import { Loader } from '@mantine/core';

type NotFoundErrorBoundaryLayoutProps = React.PropsWithChildren;

export default function NotFoundErrorBoundaryLayout({
  children
}: NotFoundErrorBoundaryLayoutProps) {
  return (
    <Suspense
      fallback={
        <PageLayout>
          <Loader size={50} style={{ '--loader-color': 'var(--color-theme-orange)' }} />
        </PageLayout>
      }
    >
      <NotFoundErrorBoundary>{children}</NotFoundErrorBoundary>
    </Suspense>
  );
}
