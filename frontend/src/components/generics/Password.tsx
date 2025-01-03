import React from 'react';
import { useState } from 'react';
import EyeHidden from '../../icons/EyeHidden';
import EyeShown from '../../icons/EyeShown';

type PasswordProps = {
  value: string | undefined;
  onChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
  label: {
    text: string;
    color: string;
  };
  input: {
    colors: {
      text: string;
      bg: string;
    };
  };
};

function Password(
  { label, input, value, onChange }: PasswordProps,
  _: React.Ref<HTMLInputElement>
) {
  const [isVisible, setIsVisible] = useState<boolean>(false);

  return (
    <div className='font-DMSans inline-flex flex-col gap-1'>
      <label className={`text-xl ${label.color} font-semibold`}>
        {label.text}
      </label>
      <div className='flex justify-center items-center gap-2.5'>
        <input
          type={isVisible ? 'text' : 'password'}
          value={value || ''}
          onChange={onChange}
          className={`px-2 py-2 ${input.colors.bg} text-lg ${input.colors.text} rounded-md outline-none`}
        />
        <span
          className='cursor-pointer'
          onClick={() => setIsVisible(!isVisible)}
        >
          {isVisible ? <EyeHidden /> : <EyeShown />}
        </span>
      </div>
    </div>
  );
}

export default React.forwardRef(Password);
