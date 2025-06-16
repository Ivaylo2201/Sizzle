import type z from 'zod';
import type { signUpSchema } from '@/lib/schemas/signUpSchema';

export type SignUpData = z.infer<typeof signUpSchema>;