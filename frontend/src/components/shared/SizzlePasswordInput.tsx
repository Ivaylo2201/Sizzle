import { PasswordInput, type PasswordInputProps } from '@mantine/core';

type SizzlePasswordInputProps = PasswordInputProps;

export default function SizzlePasswordInput({
  label,
  leftSectionPointerEvents,
  leftSection,
  ...rest
}: SizzlePasswordInputProps) {
  return (
    <PasswordInput
      size='md'
      variant='filled'
      label={label}
      leftSectionPointerEvents={leftSectionPointerEvents}
      leftSection={leftSection}
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
