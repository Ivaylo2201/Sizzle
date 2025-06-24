import { Select, type SelectProps } from '@mantine/core';

type SizzleSelectProps = SelectProps;

export default function SizzleSelect({
  label,
  onChange,
  data,
  ...rest
}: SizzleSelectProps) {
  return (
    <Select
      label={label}
      data={data || []}
      styles={{
        input: {
          color: '#737374',
          backgroundColor: 'var(--color-gray-200)',
          fontFamily: 'Rubik, sans-serif',
          border: 'none',
          height: '42px'
        },
        label: {
          fontSize: '16px'
        }
      }}
      onChange={onChange}
      {...rest}
    />
  );
}
