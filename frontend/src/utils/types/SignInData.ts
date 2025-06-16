import type z from 'zod';
import type { signInSchema } from '@/lib/schemas/SignInSchema';

export type SignInData = z.infer<typeof signInSchema>;
