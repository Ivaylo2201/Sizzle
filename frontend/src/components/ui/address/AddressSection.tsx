import { useFormContext } from 'react-hook-form';
import { useDisclosure } from '@mantine/hooks';

import Button from '@/components/shared/Button';
import AddAddressModal from '@/components/ui/address/AddAddressModal';
import AddressList from '@/components/ui/address/AddressList';
import type { Address } from '@/utils/types/models/Address';
import type { CheckoutSchema } from '@/lib/schemas/checkoutSchema';

type AddressSectionProps = {
  addresses: Address[];
};

export default function AddressSection({ addresses }: AddressSectionProps) {
  const [opened, { open, close }] = useDisclosure(false);
  const { setValue } = useFormContext<CheckoutSchema>();

  return (
    <section className='bg-white rounded-xl shadow-md p-6 flex flex-col justify-center items-center gap-4'>
      <h2 className='font-rubik text-2xl font-bold uppercase'>Delivery address</h2>
      <AddressList
        addresses={addresses}
        onSelect={(id) => setValue('addressId', id)}
      />
      <Button type='button' onClick={open}>
        Add address
      </Button>

      <AddAddressModal opened={opened} close={close} />
    </section>
  );
}
