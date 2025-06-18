import { X } from 'lucide-react';

type RemoveItemButtonProps = {
  callback: () => void;
};

export default function RemoveItemButton({ callback }: RemoveItemButtonProps) {
  return (
    <button className='cursor-pointer' onClick={callback}>
      <X />
    </button>
  );
}
