import { useState } from 'react';

import AddressCard from '@/components/ui/address/AddressCard';
import type { Address } from '@/utils/types/models/Address';

type AddressListProps = {
  addresses: Address[];
  onSelect: (id: number) => void;
};

export default function AddressList({ addresses, onSelect }: AddressListProps) {
  const [addressId, setAddressId] = useState<number | null>(null);

  const handleSelect = (id: number) => {
    setAddressId(id);
    onSelect(id);
  };

  return (
    <ul className='grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4 p-4'>
      {addresses.map((address, index) => (
        <li key={index} onClick={() => handleSelect(address.id)}>
          <AddressCard
            {...address}
            className={
              addressId === address.id
                ? 'border-theme-pink'
                : 'border-transparent'
            }
          />
        </li>
      ))}
    </ul>
  );
}
