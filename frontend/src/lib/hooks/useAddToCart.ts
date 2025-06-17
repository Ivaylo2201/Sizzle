import { httpClient } from '@/utils/httpClient';
import { useMutation } from '@tanstack/react-query';
import type { AxiosError } from 'axios';
import { toast } from 'react-toastify';

type UseAddToCartResponse = {
  message: string;
};

type UseAddToCartRequest = {
  productId: string;
  quantity: number;
};

type UseAddToCartAxiosError = AxiosError<{ message: string }>;

async function addToCart(data: UseAddToCartRequest) {
  const res = await httpClient.post('/carts/items', data);
  return res.data;
}

export default function useAddToCart() {
  return useMutation<
    UseAddToCartResponse,
    UseAddToCartAxiosError,
    UseAddToCartRequest
  >({
    mutationFn: (data) => addToCart(data),
    onSuccess: (res) => toast.success(res.message),
    onError: (e) => {
      toast.error(e.response?.data.message || 'Something went wrong.');
    }
  });
}
