import type z from 'zod';
import type { signUpSchema } from '@/lib/schemas/signUpSchema';

export type SignUpRequest = z.infer<typeof signUpSchema>;