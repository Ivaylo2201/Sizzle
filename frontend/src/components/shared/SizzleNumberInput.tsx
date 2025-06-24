import { NumberInput, type NumberInputProps } from '@mantine/core';

type SizzleNumberInputProps = NumberInputProps;

export default function SizzleNumberInput({
  label,
  onChange,
  ...rest
}: SizzleNumberInputProps) {
  return (
    <NumberInput
      size='md'
      variant='filled'
      label={label}
      styles={{
        input: {
          color: '#737374',
          backgroundColor: 'var(--color-gray-200)',
          fontFamily: 'Rubik, sans-serif'
        }
      }}
      onChange={onChange}
      {...rest}
    />
  );
}
