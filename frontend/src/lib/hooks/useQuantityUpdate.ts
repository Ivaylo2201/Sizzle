import { httpClient } from '@/utils/httpClient';
import { useMutation, useQueryClient } from '@tanstack/react-query';
import type { AxiosError } from 'axios';
import { toast } from 'react-toastify';

type UseQuantityUpdateResponse = { message: string };
type UseQuantityUpdateRequest = { id: number; quantity: number };
type UseQuantityUpdateAxiosError = AxiosError<{ message: string }>;

async function updateItemQuantity({ id, quantity }: UseQuantityUpdateRequest) {
  const res = await httpClient.patch(`/items/${id}`, { quantity });
  return res.data;
}

export default function useQuantityUpdate() {
  const queryClient = useQueryClient();

  return useMutation<
    UseQuantityUpdateResponse,
    UseQuantityUpdateAxiosError,
    UseQuantityUpdateRequest
  >({
    mutationFn: (data) => updateItemQuantity(data),
    onSuccess: () => queryClient.invalidateQueries({ queryKey: ['cart'] }),
    onError: () => toast.error('Something went wrong.')
  });
}
