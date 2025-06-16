import { Loader } from '@mantine/core';

type LoadingSpinnerProps = {
  size?: number;
};

export default function LoadingSpinner({ size = 20 }: LoadingSpinnerProps) {
  return (
    <Loader
      size={size}
      style={{ '--loader-color': 'var(--color-theme-orange)' }}
    />
  );
}
