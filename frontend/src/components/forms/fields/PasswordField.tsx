import { Control, Controller } from 'react-hook-form';
import Password from '../../shared/Password';

type PasswordFieldProps = {
  control: Control<any>;
  isConfirming?: boolean;
};

export default function PasswordField({
  control,
  isConfirming
}: PasswordFieldProps) {
  return (
    <Controller
      name={isConfirming ? 'passwordConfirmation' : 'password'}
      control={control}
      render={({ field }) => (
        <Password
          input={{
            colors: {
              text: 'bg-theme-lightgray',
              bg: 'text-theme-gray'
            }
          }}
          label={{
            text: isConfirming ? 'Password Confirmation' : 'Password',
            color: 'text-theme-darkgray'
          }}
          {...field}
        />
      )}
    />
  );
}
