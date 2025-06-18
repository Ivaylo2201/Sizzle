import { httpClient } from '@/utils/httpClient';
import { useMutation, useQueryClient } from '@tanstack/react-query';
import type { AxiosError } from 'axios';
import { toast } from 'react-toastify';

type UseItemRemoveResponse = {};
type UseItemRemoveRequest = { id: number };
type UseItemRemoveAxiosError = AxiosError<{ message: string }>;

async function removeItem(request: UseItemRemoveRequest) {
  const res = await httpClient.delete(`/carts/items/${request.id}`);
  return res.data;
}

export default function useItemRemove() {
  const queryClient = useQueryClient();

  return useMutation<
    UseItemRemoveResponse,
    UseItemRemoveAxiosError,
    UseItemRemoveRequest
  >({
    mutationFn: (data) => removeItem(data),
    onSuccess: () => queryClient.invalidateQueries({ queryKey: ['cart'] }),
    onError: () => toast.error('Failed to remove item.')
  });
}
