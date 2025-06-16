import type { AxiosError } from 'axios';
import { toast } from 'react-toastify';
import { useNavigate } from 'react-router';

import { httpClient } from '@/utils/http/httpClient';
import { useMutation } from '@tanstack/react-query';
import { useAuthStore } from '@/lib/stores/useAuthStore';
import type { SignUpRequest } from '@/utils/types/requests/SignUpRequest';
import type { SignUpResponse } from '@/utils/types/responses/SignUpResponse';

export default function useSignUp() {
  const { signIn } = useAuthStore();
  const navigate = useNavigate();

  return useMutation<SignUpResponse, AxiosError, SignUpRequest>({
    mutationFn: async (data) => {
      const res = await httpClient.post<SignUpResponse>('/auth/sign-up', data);
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
