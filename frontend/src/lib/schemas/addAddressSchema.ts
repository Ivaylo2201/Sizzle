import { z } from 'zod';

export const addAddressSchema = z.object({
  cityName: z.string({ required_error: 'City must be selected.' }),

  streetName: z
    .string({ required_error: 'Street name must be provided.' })
    .min(3, 'Street name must be between 3 and 25 characters.')
    .max(25, 'Street name must be between 3 and 25 characters.'),

  streetNumber: z
    .number({ required_error: 'Street number must be provided.' })
    .min(0, 'Street number must be between 0 and 500.')
    .max(500, 'Street number must be between 0 and 500.')
});

export type AddAddressSchema = z.infer<typeof addAddressSchema>;
