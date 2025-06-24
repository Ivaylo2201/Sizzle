import { useState } from 'react';
import { DateTimePicker } from '@mantine/dates';
import { FormProvider, useForm } from 'react-hook-form';
import { toast } from 'react-toastify';

import {
  checkoutSchema,
  type CheckoutSchema
} from '@/lib/schemas/checkoutSchema';
import useAddresses from '@/lib/hooks/useAddresses';
import usePlaceOrder from '@/lib/hooks/usePlaceOrder';
import formatToTimePickerTime from '@/utils/helpers/formatToTimePickerTime';
import Page from '@/components/layout/PageLayout';
import Button from '@/components/shared/Button';
import AddressSection from '@/components/ui/address/AddressSection';
import SizzleCheckbox from '@/components/shared/SizzleCheckbox';

export default function CheckoutPage() {
  const [isAsapSelected, setIsAsapSelected] = useState<boolean>(true);
  const { data: addresses } = useAddresses();
  const { mutate: placeOrder } = usePlaceOrder();

  const now = new Date();
  const earliest = new Date(now.getTime() + 30 * 60 * 1000);
  const earliesIsoString = earliest.toISOString();

  const methods = useForm<CheckoutSchema>({
    defaultValues: { deliveryTime: earliest.toISOString() }
  });

  const handleDateTimeChange = (data: string | null) => {
    if (data) {
      const date = new Date(data).toISOString();
      methods.setValue('deliveryTime', date);
    }
  };

  const handleAsapSelect = (e: React.ChangeEvent<HTMLInputElement>) => {
    setIsAsapSelected(e.target.checked);
    methods.setValue('deliveryTime', earliesIsoString);
  };

  const onSubmit = (data: CheckoutSchema) => {
    const result = checkoutSchema.safeParse(data);

    if (!result.success) {
      toast.error(result.error?.errors[0].message);
      return;
    }

    placeOrder(data);
  };

  return (
    <Page>
      <FormProvider {...methods}>
        <form
          onSubmit={methods.handleSubmit(onSubmit)}
          className='flex flex-col justify-center items-center gap-6'
        >
          <AddressSection addresses={addresses} />
          <section className='w-full bg-white rounded-xl shadow-md p-6 flex flex-col justify-center items-center gap-4'>
            <h2 className='font-rubik text-2xl font-bold uppercase'>
              Delivery time
            </h2>
            <div className='flex justify-center items-center gap-5'>
              <SizzleCheckbox
                checked={isAsapSelected}
                onChange={handleAsapSelect}
                label='As soon as possible'
              />
              <DateTimePicker
                minDate={now}
                timePickerProps={{ min: formatToTimePickerTime(earliest) }}
                defaultValue={earliest}
                disabled={isAsapSelected}
                onChange={handleDateTimeChange}
              />
            </div>
          </section>
          <Button>Submit</Button>
        </form>
      </FormProvider>
    </Page>
  );
}
