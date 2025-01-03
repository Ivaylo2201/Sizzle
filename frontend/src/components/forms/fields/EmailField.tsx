import { Control, Controller } from 'react-hook-form';
import Textbox from '../../generics/Textbox';

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
          label={{ text: 'Your Email', color: 'text-[#323232]' }}
          input={{
            placeholder: 'example@mail.com',
            colors: {
              text: 'text-gray-600',
              bg: 'bg-lightgray',
              placeholder: 'focus:placeholder-gray-600'
            }
          }}
          {...field}
        />
      )}
    />
  );
}
