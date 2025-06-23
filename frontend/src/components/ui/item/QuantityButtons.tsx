import { ChevronDown, ChevronUp } from 'lucide-react';

type QuantityButtonsProps = {
  quantity: number;
  onChange: (quantity: number) => void;
  orientation?: 'horizontal' | 'vertical';
};

export default function QuantityButtons({
  quantity,
  onChange,
  orientation = 'vertical'
}: QuantityButtonsProps) {
  const onIncrement = () => onChange(quantity + 1);
  const onDecrement = () => onChange(quantity - 1);

  return (
    <div
      className={`flex ${
        orientation === 'horizontal' ? 'flex-row-reverse' : 'flex-col'
      } justify-center items-center gap-2`}
    >
      <button
        className={`bg-theme-pink p-2 rounded-full transition-colors duration-200 hover:bg-theme-orange cursor-pointer ${
          quantity >= 15 ? 'opacity-50 pointer-events-none' : 'opacity-100'
        }
  `}
        onClick={onIncrement}
      >
        <ChevronUp color='white' />
      </button>
      <span className='min-w-5 text-center'>{quantity}</span>
      <button
        className={`bg-theme-pink p-2 rounded-full transition-colors duration-200 hover:bg-theme-orange cursor-pointer ${
          quantity === 1 ? 'opacity-50 pointer-events-none' : 'opacity-100'
        }`}
        onClick={onDecrement}
      >
        <ChevronDown color='white' />
      </button>
    </div>
  );
}
