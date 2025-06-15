import { ErrorBoundary } from 'react-error-boundary';
import NotFoundPage from '../pages/NotFoundPage';

type NotFoundErrorBoundaryProps = React.PropsWithChildren;

export default function NotFoundErrorBoundary({
  children
}: NotFoundErrorBoundaryProps) {
  return (
    <ErrorBoundary FallbackComponent={NotFoundPage}>{children}</ErrorBoundary>
  );
}
