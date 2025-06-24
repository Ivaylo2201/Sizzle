import { TextInput, type TextInputProps } from '@mantine/core';

type SizzleTextInputProps = TextInputProps;

export default function SizzleTextInput({
  label,
  onChange,
  ...rest
}: SizzleTextInputProps) {
  return (
    <TextInput
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
