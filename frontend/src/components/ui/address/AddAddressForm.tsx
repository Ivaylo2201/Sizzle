import { useForm } from 'react-hook-form';
import { toast } from 'react-toastify';

import useAddAddress from '@/lib/hooks/useAddAddress';
import useCities from '@/lib/hooks/useCities';
import {
  addAddressSchema,
  type AddAddressSchema
} from '@/lib/schemas/addAddressSchema';
import Button from '@/components/shared/Button';
import SizzleNumberInput from '@/components/shared/SizzleNumberInput';
import SizzleSelect from '@/components/shared/SizzleSelect';
import SizzleTextInput from '@/components/shared/SizzleTextInput';

export default function AddAddressForm() {
  const { handleSubmit, setValue } = useForm<AddAddressSchema>();
  const { mutate: addAddress } = useAddAddress();
  const { data: cities } = useCities();

  const onSubmit = (data: AddAddressSchema) => {
    const result = addAddressSchema.safeParse(data);

    if (!result.success) {
      toast.error(result.error?.errors[0].message);
      return;
    }

    addAddress(data);
    close();
  };

  return (
    <form className='flex flex-col justify-center items-center gap-8 bg-white rounded-xl shadow-md p-10'>
      <div className='flex flex-col gap-4'>
        <SizzleSelect
          label='City'
          data={cities?.map((city) => city.cityName) || []}
          onChange={(value) => setValue('cityName', value || '')}
        />
        <SizzleTextInput
          label='Street Name'
          onChange={(e) => setValue('streetName', e.target.value)}
        />
        <SizzleNumberInput
          label='Street Number'
          onChange={(value) => setValue('streetNumber', Number(value))}
        />
      </div>
      <Button onClick={handleSubmit(onSubmit)}>Add address</Button>
    </form>
  );
}
