import { httpClient } from '@/utils/httpClient';
import { useMutation, useQueryClient } from '@tanstack/react-query';
import { useNavigate } from 'react-router';
import { toast } from 'react-toastify';
import type { AxiosError } from 'axios';

type UsePlaceOrderRequest = {
  addressId: number;
  deliveryTime: string;
};

type UsePlaceOrderResponse = {
  message: string;
};

type UsePlaceOrderAxiosError = AxiosError<{ message: string }>;

async function placeOrder(data: UsePlaceOrderRequest) {
  const res = await httpClient.post<UsePlaceOrderResponse>('/orders', data);
  return res.data;
}

export default function usePlaceOrder() {
  const navigate = useNavigate();
  const queryClient = useQueryClient();

  return useMutation<
    UsePlaceOrderResponse,
    UsePlaceOrderAxiosError,
    UsePlaceOrderRequest
  >({
    mutationFn: (data) => placeOrder(data),
    onSuccess: (res) => {
      navigate('/');
      toast.success(res.message);
      queryClient.invalidateQueries({ queryKey: ['orders'] });
    },
    onError: (e) =>
      toast.error(e.response?.data.message || 'Something went wrong.')
  });
}
