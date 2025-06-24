import { z } from 'zod';

export const checkoutSchema = z.object({
  addressId: z.number({ required_error: 'Address must be selected.' }),
  notes: z.string().optional(),
  deliveryTime: z.string({required_error: 'Delivery time must be provided.'})
});

export type CheckoutSchema = z.infer<typeof checkoutSchema>;
