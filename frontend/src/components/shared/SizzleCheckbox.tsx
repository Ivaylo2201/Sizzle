import { Checkbox, type CheckboxProps } from '@mantine/core';

type SizzleCheckboxProps = CheckboxProps;

export default function SizzleCheckbox(props: SizzleCheckboxProps) {
  return (
    <Checkbox
      color='var(--color-theme-pink)'
      className='font-rubik'
      {...props}
    />
  );
}
