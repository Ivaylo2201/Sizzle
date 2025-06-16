import { Loader } from '@mantine/core';
import Page from '@/components/layout/PageLayout';

export default function LoadingSpinner() {
  return (
    <Page>
      <Loader style={{ '--loader-color': 'var(--color-theme-orange)' }} />
    </Page>
  );
}
