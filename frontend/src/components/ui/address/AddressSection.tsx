import { useFormContext } from 'react-hook-form';

import AddressList from '@/components/ui/address/AddressList';  
import AddAddressForm from '@/components/ui/address/AddAddressForm';
import type { Address } from '@/utils/types/models/Address';
import type { CheckoutSchema } from '@/lib/schemas/checkoutSchema';

type AddressSectionProps = {
  addresses: Address[];
};

export default function AddressSection({ addresses }: AddressSectionProps) {
  const { setValue } = useFormContext<CheckoutSchema>();

  return (
    <section className='flex flex-col md:flex-row gap-6 justify-center'>
      <div className='bg-white rounded-xl shadow-md p-6 flex flex-col justify-center items-center gap-4'>
        <h2 className='font-rubik text-2xl font-bold uppercase'>
          Delivery address
        </h2>
        <div className='flex justify-center items-center gap-4'>
          <AddressList
            addresses={addresses}
            onSelect={(id) => setValue('addressId', id)}
          />
        </div>
      </div>
      <AddAddressForm />
    </section>
  );
}
