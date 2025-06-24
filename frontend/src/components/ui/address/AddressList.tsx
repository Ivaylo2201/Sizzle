import type { Address } from '@/utils/types/models/Address';
import AddressCard from './AddressCard';
import { useState } from 'react';

type AddressListProps = {
  addresses: Address[];
  onSelect: (id: number) => void;
};

export default function AddressList({ addresses, onSelect }: AddressListProps) {
  const [addressId, setAddressId] = useState<number | null>(null);

  const getSelectedStyles = (id: number) => {
    return addressId === id ? 'border-theme-pink' : 'border-transparent';
  };

  const handleAddressSelection = (id: number) => {
    setAddressId(id);
    onSelect(id);
  };

  return (
    <ul className='grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4 p-4'>
      {addresses.map((address, index) => (
        <li key={index} onClick={() => handleAddressSelection(address.id)}>
          <AddressCard {...address} className={getSelectedStyles(address.id)} />
        </li>
      ))}
    </ul>
  );
}
