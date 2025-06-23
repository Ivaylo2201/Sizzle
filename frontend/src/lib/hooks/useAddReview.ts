import { useMutation, useQueryClient } from '@tanstack/react-query';
import { toast } from 'react-toastify';
import type { AxiosError } from 'axios';

import { httpClient } from '@/utils/httpClient';
import type { LongProduct } from '@/utils/types/models/LongProduct';

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

export default function useAddReview(product: LongProduct) {
  const queryClient = useQueryClient();

  return useMutation<
    UseAddReviewResponse,
    UseAddReviewAxiosError,
    UseAddReviewRequest
  >({
    mutationFn: (data) => addReview(data),
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['product', product.id] });
      queryClient.invalidateQueries({ queryKey: ['products', product.categoryName.toLowerCase()] });
      toast.success('Review added successfully!');
    },
    onError: (e) => {
      toast.error(e.response?.data.message || 'Something went wrong.');
    }
  });
}
