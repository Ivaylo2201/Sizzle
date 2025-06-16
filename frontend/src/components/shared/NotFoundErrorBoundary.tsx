import { ErrorBoundary } from 'react-error-boundary';
import { useLocation } from 'react-router';

import NotFoundPage from '@/components/pages/NotFoundPage';

type NotFoundErrorBoundaryProps = React.PropsWithChildren;

export default function NotFoundErrorBoundary({
  children
}: NotFoundErrorBoundaryProps) {
  const location = useLocation();

  return (
    <ErrorBoundary
      FallbackComponent={NotFoundPage}
      resetKeys={[location.pathname]}
    >
      {children}
    </ErrorBoundary>
  );
}
