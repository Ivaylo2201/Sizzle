import type { AxiosError } from 'axios';
import { toast } from 'react-toastify';
import { useNavigate } from 'react-router';

import { useMutation } from '@tanstack/react-query';
import { useAuthStore } from '@/lib/stores/useAuthStore';
import type { SignInResponse } from '@/utils/types/responses/SignInResponse';
import type { SignInRequest } from '@/utils/types/requests/SignInRequest';
import { httpClient } from '@/utils/http/httpClient';

export default function useSignIn() {
  const { signIn } = useAuthStore();
  const navigate = useNavigate();

  return useMutation<SignInResponse, AxiosError, SignInRequest>({
    mutationFn: async (data) => {
      const res = await httpClient.post<SignInResponse>('/auth/sign-in', data);
      return res.data;
    },
    onSuccess: (data) => {
      localStorage.setItem('token', `Bearer ${data.token}`);
      navigate('/');
      signIn();
    },
    onError: (error) => {
      toast.error(
        (error.response?.data as { message: string }).message ||
          'Something went wrong.'
      );
    }
  });
}
