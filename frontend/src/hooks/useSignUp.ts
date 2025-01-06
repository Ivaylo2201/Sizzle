import { useMutation } from 'react-query';
import useAuthStore from '../stores/authStore';
import { schema } from '../schemas/signUpFormData';
import { z } from 'zod';
import { axiosClient as axios } from '../api/axiosClient';
import { AxiosError } from 'axios';
import { toast } from 'react-toastify';
import { AuthResponse } from '../types/AuthResponse';

type User = z.infer<typeof schema>;
type FieldErrors = { [K in keyof User]?: string[] };

export default function useSignUp() {
  const { signIn } = useAuthStore();

  const mutation = useMutation<AuthResponse, AxiosError<FieldErrors>, User>({
    mutationFn: async (user: User) => {
      const res = await axios.post<AuthResponse>('/auth/signup', user);
      return res.data;
    },
    onSuccess: (data: AuthResponse) => {
      signIn(data.email);
    },
    onError: (error) => {
      if (
        !error.response ||
        error.status === undefined ||
        error.status < 400 ||
        error.status >= 500
      ) {
        toast.error('Something went wrong!');
        return;
      }

      toast.error(
        Object.entries(error.response.data).filter(
          ([_, errors]) => errors !== undefined
        )[0][1][0]
      );
    }
  });

  return mutation;
}
