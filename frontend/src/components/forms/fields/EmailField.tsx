import { Control, Controller } from 'react-hook-form';
import Textbox from '../../shared/Textbox';

type EmailFieldProps = {
  control: Control<any>;
};

export default function EmailField({ control }: EmailFieldProps) {
  return (
    <Controller
      name='email'
      control={control}
      render={({ field }) => (
        <Textbox
          label={{ text: 'Your Email', color: 'text-theme-darkgray' }}
          input={{
            placeholder: 'example@mail.com',
            colors: {
              text: 'text-theme-gray',
              bg: 'bg-theme-lightgray',
              placeholder: 'focus:placeholder-theme-gray'
            }
          }}
          {...field}
        />
      )}
    />
  );
}
