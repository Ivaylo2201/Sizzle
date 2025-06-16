import type { AxiosError } from "axios";
import { toast } from 'react-toastify';
import { useNavigate } from "react-router";

import { httpClient } from "@/utils/httpClient";
import { useMutation } from "@tanstack/react-query";
import { useAuthStore } from "@/lib/stores/useAuthStore";
import type { SignUpData } from "@/utils/types/SignUpData";

type Response = { token: string }

export default function useSignUp() {
  const { login } = useAuthStore();
  const navigate = useNavigate();

  return useMutation<Response, AxiosError, SignUpData>({
    mutationFn: async (data) => {
      const res = await httpClient.post<Response>('/auth/sign-up', data);
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