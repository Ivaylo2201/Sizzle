import { httpClient } from '@/utils/httpClient';
import { useMutation, useQueryClient } from '@tanstack/react-query';
import type { AxiosError } from 'axios';
import { toast } from 'react-toastify';
import type { AddAddressSchema } from '../schemas/addAddressSchema';

type UseAddAddressRequest = AddAddressSchema;

type UseAddAddressResponse = {
  message: string;
};

type UseAddAddressAxiosError = AxiosError<{ message: string }>;

async function addAddress(data: UseAddAddressRequest) {
  const res = await httpClient.post<UseAddAddressResponse>(
    '/profile/addresses',
    data
  );
  return res.data;
}

export default function useAddAddress() {
  const queryClient = useQueryClient();

  return useMutation<
    UseAddAddressResponse,
    UseAddAddressAxiosError,
    UseAddAddressRequest
  >({
    mutationFn: (data) => addAddress(data),
    onSuccess: (res) => {
      queryClient.invalidateQueries({ queryKey: ['addresses'] });
      toast.success(res.message);
    },
    onError: (e) =>
      toast.error(e.response?.data.message || 'Something went wrong.')
  });
}
