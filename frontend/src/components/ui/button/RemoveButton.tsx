import { X } from 'lucide-react';
import type React from 'react';

type RemoveButtonProps = {
  callback: () => void;
  size?: number;
  color?: string;
  className?: string;
};

export default function RemoveButton({
  callback,
  size = 20,
  color = 'black',
  className = ''
}: RemoveButtonProps) {
  const handleClick = (e: React.MouseEvent) => {
    e.stopPropagation();
    callback();
  }

  return (
    <button type='button' className={`cursor-pointer ${className}`} onClick={handleClick}>
      <X size={size} color={color} />
    </button>
  );
}
