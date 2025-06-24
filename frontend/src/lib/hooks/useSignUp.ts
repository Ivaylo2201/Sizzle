import type { AxiosError } from 'axios';
import { toast } from 'react-toastify';
import { useNavigate } from 'react-router';
import { useMutation } from '@tanstack/react-query';
import type z from 'zod';

import { useAuthStore } from '@/lib/stores/useAuthStore';
import type { signUpSchema } from '@/lib/schemas/signUpSchema';
import { httpClient } from '@/utils/httpClient';

type UseSignUpResponse = { token: string };
type UseSignUpAxiosError = AxiosError<{ message: string }>;
type UseSignUpRequest = z.infer<typeof signUpSchema>;

async function signUp(data: UseSignUpRequest) {
  const res = await httpClient.post<UseSignUpResponse>('/auth/sign-up', data);
  return res.data;
}

export default function useSignUp() {
  const { signIn } = useAuthStore();
  const navigate = useNavigate();

  return useMutation<UseSignUpResponse, UseSignUpAxiosError, UseSignUpRequest>({
    mutationFn: (data) => signUp(data),
    onSuccess: (res, { rememberMe }) => {
      signIn(res.token, rememberMe);
      navigate('/');
    },
    onError: (e) =>
      toast.error(e.response?.data.message || 'Something went wrong.')
  });
}
