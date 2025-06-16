import type z from 'zod';
import type { signInSchema } from '@/lib/schemas/signInSchema';

export type SignInRequest = z.infer<typeof signInSchema>;