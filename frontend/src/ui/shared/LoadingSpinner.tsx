import { Loader } from '@mantine/core';
import Page from '@/ui/layouts/Page';

export default function LoadingSpinner() {
  return (
    <Page>
      <Loader style={{ '--loader-color': 'var(--color-theme-orange)' }} />
    </Page>
  );
}
