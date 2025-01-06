import { z } from "zod";

export const schema = z
  .object({
    email: z
      .string({ required_error: 'Email is required' })
      .email({ message: 'Email is invalid!' }),
    password: z
      .string({ required_error: 'Password is required' })
      .min(2, 'Password must be at least 8 characters long'),
    passwordConfirmation: z.string({
      required_error: 'Confirmation is required'
    })
  })
  .refine((data) => data.password === data.passwordConfirmation, {
    message: 'Passwords do not match!',
    path: ['passwordConfirmation']
  });