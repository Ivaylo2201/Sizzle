import { useMutation } from 'react-query';

import { z } from 'zod';
import { schema } from '../schemas/signInSchema';
import { toast } from 'react-toastify';
import { AxiosError } from 'axios';
import { axiosClient as axios } from '../api/axiosClient';
import { AuthResponse } from '../types/AuthResponse';
import useAuthStore from '../stores/authStore';

type User = z.infer<typeof schema>;

export default function useSignIn() {
  const { signIn } = useAuthStore();

  const mutation = useMutation<AuthResponse, AxiosError<{ detail: string }>, User>({
    mutationFn: async (user) => {
      const res = await axios.post<AuthResponse>('auth/token/', user);
      return res.data;
    },
    onSuccess: () => signIn(),
    onError: (error) => {
      if (error.response) {
        toast.error(error.response.data.detail);
      } else {
        toast.error('Something went wrong!');
      }
    }
  });

  return mutation;
}
