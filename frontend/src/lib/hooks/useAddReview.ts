import { useMutation, useQueryClient } from '@tanstack/react-query';
import { toast } from 'react-toastify';
import type { AxiosError } from 'axios';

import { httpClient } from '@/utils/httpClient';

type UseAddReviewRequest = {
  rating: number;
  comment: string | null;
  productId: string;
};

type UseAddReviewResponse = { message: string };
type UseAddReviewAxiosError = AxiosError<{ message: string }>;

async function addReview(data: UseAddReviewRequest) {
  const res = await httpClient.post('/reviews', data);
  return res.data;
}

export default function useAddReview(productId: string) {
  const queryClient = useQueryClient();

  return useMutation<
    UseAddReviewResponse,
    UseAddReviewAxiosError,
    UseAddReviewRequest
  >({
    mutationFn: (data) => addReview(data),
    onSuccess: () => {
      toast.success('Review added successfully!');
      queryClient.invalidateQueries({ queryKey: ['product', productId] });
    },
    onError: (e) => {
      toast.error(e.response?.data.message || 'Something went wrong.');
    }
  });
}
