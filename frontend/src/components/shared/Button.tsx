type ButtonProps = {
  onClick: () => void;
  colors: {
    bg: string;
    text: string;
  };
  className?: string;
} & React.PropsWithChildren;

function Button({ colors, onClick, className, children }: ButtonProps) {
  return (
    <button
      type='submit'
      className={`w-40 h-10 flex justify-center items-center transition-colors duration-200 hover:bg-opacity-85 ${colors.bg} ${className} rounded-full font-DMSans ${colors.text}`}
      onClick={onClick}
    >
      {children}
    </button>
  );
}

export default Button;
