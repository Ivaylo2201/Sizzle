import { z } from 'zod';

export const signUpSchema = z
  .object({
    username: z
      .string()
      .min(1, 'Username must be provided.')
      .min(5, 'Username must be between 5 and 25 characters.')
      .max(25, 'Username must be between 5 and 25 characters.'),

    phoneNumber: z
      .string()
      .min(1, 'Phone number must be provided.')
      .length(10, 'Phone number must be 10 characters long.'),

    password: z
      .string()
      .min(1, 'Password must be provided.')
      .min(5, 'Password must be at least 5 characters long.')
      .regex(
        /^(?=.*[A-Za-z])(?=.*\d).+$/,
        'Password must contain both letters and numbers.'
      ),

    passwordConfirmation: z.string().min(1, 'Password must be confirmed.'),

    rememberMe: z.boolean()
  })
  .refine((data) => data.password === data.passwordConfirmation, {
    message: 'Passwords do not match.',
    path: ['passwordConfirmation']
  })
  .refine((data) => !data.password.includes(data.username), {
    message: 'Password must not contain username.',
    path: ['password']
  });

export type SignUpSchema = z.infer<typeof signUpSchema>;
