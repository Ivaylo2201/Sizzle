import { useMutation } from 'react-query';
import useAuthStore from '../stores/authStore';
import { z } from 'zod';
import schema from '../schemas/signInFormData';
import { toast } from 'react-toastify';
import { AxiosError } from 'axios';
import { NavigateFunction, useNavigate } from 'react-router-dom';
import { axiosClient as axios } from '../api/axiosClient';

type User = z.infer<typeof schema>;
type SignInResponse = { access: string; refresh: string; user: User };
type SignInErrors = { detail: string };

export default function useSignIn() {
  const { signIn } = useAuthStore();
  const navigate: NavigateFunction = useNavigate();

  const mutation = useMutation<SignInResponse, AxiosError<SignInErrors>, User>({
    mutationFn: async (user: User) => {
      // Mock
      // await new Promise((_, reject) =>
      //   setTimeout(
      //     () =>
      //       reject({
      //         response: {
      //           data: {
      //             detail: 'Token is invalid or expired'
      //           },
      //           status: 400,
      //           statusText: 'Bad Request'
      //         },
      //         message: 'Request failed with status code 400'
      //       }),
      //     1000
      //   )
      // );
      // return { access: '1212', refresh: '1212', user };

      const res = await axios.post<SignInResponse>('/auth/signin', user);
      return res.data;
    },
    onSuccess: (data: SignInResponse) => {
      signIn(data.user.email);
      navigate('/');
    },
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
