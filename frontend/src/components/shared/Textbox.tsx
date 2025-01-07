import React from 'react';

type TextboxProps = {
  value: string;
  onChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
  className?: string;
  label: {
    text: string;
    color: string;
  };
  input: {
    placeholder: string;
    colors: {
      placeholder: string;
      text: string;
      bg: string;
    };
  };
};

function Textbox(
  { label, input, value, onChange, className }: TextboxProps,
  ref: React.Ref<HTMLInputElement>
) {
  return (
    <div className={`font-DMSans inline-flex flex-col gap-1 ${className}`}>
      <label className={`text-xl ${label.color} font-semibold`}>
        {label.text}
      </label>
      <input
        type='text'
        value={value || ''}
        placeholder={input.placeholder}
        onChange={onChange}
        ref={ref}
        className={`px-3 py-2 ${input.colors.bg} text-lg ${input.colors.text} rounded-md outline-none placeholder-transparent ${input.colors.placeholder}`}
      />
    </div>
  );
}

export default React.forwardRef(Textbox);
