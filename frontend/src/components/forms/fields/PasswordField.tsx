import { Control, Controller } from 'react-hook-form';
import Password from '../../generics/Password';

type PassowordFieldProps = {
  control: Control<any>;
  confirming?: boolean;
};

export default function PasswordField({
  control,
  confirming
}: PassowordFieldProps) {
  return (
    <Controller
      name={confirming ? 'passwordConfirmation' : 'password'}
      control={control}
      render={({ field }) => (
        <Password
          input={{
            colors: {
              text: 'bg-lightgray',
              bg: 'text-gray-600'
            }
          }}
          label={{
            text: confirming ? 'Password Confirmation' : 'Password',
            color: 'text-[#323232]'
          }}
          {...field}
        />
      )}
    />
  );
}