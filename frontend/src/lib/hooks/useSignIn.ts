import type { AxiosError } from "axios";
import { toast } from 'react-toastify';
import { useNavigate } from "react-router";

import { httpClient } from "@/utils/httpClient";
import { useMutation } from "@tanstack/react-query";
import { useAuthStore } from "@/lib/stores/useAuthStore";
import type { SignInData } from "@/utils/types/SignInData";

type Response = { token: string }

export default function useSignIn() {
  const { login } = useAuthStore();
  const navigate = useNavigate();

  return useMutation<Response, AxiosError, SignInData>({
    mutationFn: async (data) => {
      const res = await httpClient.post<Response>('/auth/sign-in', data);
      return res.data;
    },
    onSuccess: (data) => {
      localStorage.setItem('token', `Bearer ${data.token}`);
      navigate('/');
      login();
    },
    onError: (error) => {
      toast.error((error.response?.data as { message: string }).message || 'Something went wrong.');
    }
  });
}