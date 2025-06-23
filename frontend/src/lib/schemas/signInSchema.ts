import { z } from 'zod';

export const signInSchema = z.object({
  username: z.string().min(1, 'Username must be provided.'),
  password: z.string().min(1, 'Password must be provided.'),
  rememberMe: z.boolean()
});
