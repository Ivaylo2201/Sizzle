import { httpClient } from '@/utils/httpClient';
import { useMutation, useQueryClient } from '@tanstack/react-query';
import type { AxiosError } from 'axios';
import { toast } from 'react-toastify';

type UseQuantityChangeResponse = { message: string };
type UseQuantityChangeRequest = { id: number; quantity: number };
type UseQuantityChangeAxiosError = AxiosError<{ message: string }>;

async function updateItemQuantity({ id, quantity }: UseQuantityChangeRequest) {
  const res = await httpClient.patch(`/items/${id}`, { quantity });
  return res.data;
}

export default function useQuantityChange() {
  const queryClient = useQueryClient();

  return useMutation<
    UseQuantityChangeResponse,
    UseQuantityChangeAxiosError,
    UseQuantityChangeRequest
  >({
    mutationFn: (data) => updateItemQuantity(data),
    onSuccess: () => queryClient.invalidateQueries({ queryKey: ['cart'] }),
    onError: () => toast.error('Something went wrong.')
  });
}
