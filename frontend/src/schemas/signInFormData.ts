import { z } from 'zod';

const signInFormDataSchema = z.object({
  email: z
    .string({ required_error: 'Email is required' })
    .email({ message: 'Invalid email' }),
  password: z
    .string({ required_error: 'Password is required' })
    .min(5, 'Password length must be greater than 5 characters')
});

export default signInFormDataSchema;