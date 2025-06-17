import type { AxiosError } from 'axios';
import { toast } from 'react-toastify';
import { useNavigate } from 'react-router';
import { useMutation } from '@tanstack/react-query';

import { useAuthStore } from '@/lib/stores/useAuthStore';
import { httpClient } from '@/utils/httpClient';
import type { z } from 'zod';
import type { signInSchema } from '../schemas/signInSchema';

type UseSignInResponse = { token: string };
type UseSignInAxiosError = AxiosError<{ message: string }>;
type UseSignInRequest = z.infer<typeof signInSchema>;

async function signIn(data: UseSignInRequest) {
  const res = await httpClient.post<UseSignInResponse>('/auth/sign-in', data);
  return res.data;
}

export default function useSignIn() {
  const navigate = useNavigate();
  const { signIn: storeSignIn } = useAuthStore();

  return useMutation<UseSignInResponse, UseSignInAxiosError, UseSignInRequest>({
    mutationFn: (data) => signIn(data),
    onSuccess: (res, { rememberMe }) => {
      storeSignIn(res.token, rememberMe);
      navigate('/');
    },
    onError: (e) => toast.error(e.response?.data.message || 'Something went wrong.')
  });
}
