import { DateTimePicker } from '@mantine/dates';
import { useForm } from 'react-hook-form';
import { toast } from 'react-toastify';

import {
  checkoutSchema,
  type CheckoutSchema
} from '@/lib/schemas/checkoutSchema';
import useAddresses from '@/lib/hooks/useAddresses';
import Page from '@/components/layout/PageLayout';
import AddressList from '@/components/ui/address/AddressList';
import Button from '@/components/shared/Button';
import formatToTimePickerTime from '@/utils/helpers/formatToTimePickerTime';

export default function CheckoutPage() {
  const { data: addresses } = useAddresses();

  const now = new Date();
  const earliest = new Date(now.getTime() + 30 * 60 * 1000);

  const { handleSubmit, setValue } = useForm<CheckoutSchema>({
    defaultValues: { deliveryTime: earliest.toISOString() }
  });

  const handleDateTimeChange = (data: string | null) => {
    if (data) {
      const date = new Date(data).toISOString();
      setValue('deliveryTime', date);
    }
  };

  const onSubmit = (data: CheckoutSchema) => {
    console.log(data);
    const result = checkoutSchema.safeParse(data);

    if (!result.success) {
      toast.error(result.error?.errors[0].message);
      return;
    }

    // mutate(data);
  };

  return (
    <Page>
      <form onSubmit={handleSubmit(onSubmit)}>
        <AddressList
          addresses={addresses}
          onSelect={(id) => setValue('addressId', id)}
        />
        <DateTimePicker
          minDate={now}
          timePickerProps={{ min: formatToTimePickerTime(earliest) }}
          defaultValue={earliest}
          onChange={handleDateTimeChange}
        />
        <Button>Submit</Button>
      </form>
    </Page>
  );
}
