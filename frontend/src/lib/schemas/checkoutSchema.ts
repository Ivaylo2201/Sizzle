import { z } from 'zod';

export const checkoutSchema = z.object({
  addressId: z.number(),
  notes: z.string().optional(),
  deliveryTime: z.string()
});

export type CheckoutSchema = z.infer<typeof checkoutSchema>;
