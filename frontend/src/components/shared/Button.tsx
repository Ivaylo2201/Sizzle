import type { ButtonHTMLAttributes } from 'react';

type ButtonProps = ButtonHTMLAttributes<HTMLButtonElement>;

export default function Button({
  children,
  onClick,
  type = 'submit',
  className = ''
}: ButtonProps) {
  return (
    <button
      className={`bg-theme-pink text-white px-4 py-1.5 rounded-md cursor-pointer duration-500 transition-colors hover:bg-theme-orange ${className}`}
      onClick={onClick}
      type={type}
    >
      {children}
    </button>
  );
}
