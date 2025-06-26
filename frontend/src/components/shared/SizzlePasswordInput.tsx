import { PasswordInput, type PasswordInputProps } from '@mantine/core';
import { KeyRound } from 'lucide-react';

type SizzlePasswordInputProps = PasswordInputProps;

export default function SizzlePasswordInput({
  label,
  ...rest
}: SizzlePasswordInputProps) {
  return (
    <PasswordInput
      size='md'
      variant='filled'
      label={label}
      leftSectionPointerEvents='none'
      leftSection={<KeyRound size={18} />}
      styles={{
        input: {
          color: '#737374',
          backgroundColor: 'var(--color-gray-200)',
          fontFamily: 'Rubik, sans-serif'
        }
      }}
      {...rest}
    />
  );
}
