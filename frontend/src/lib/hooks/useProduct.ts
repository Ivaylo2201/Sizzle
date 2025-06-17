import { useSuspenseQuery } from '@tanstack/react-query';
import { httpClient } from '@/utils/httpClient';
import type { ShortProduct } from '@/utils/types/models/ShortProduct';
import type { Review } from '@/utils/types/models/Review';

type UseProductResponse = ShortProduct & {
  calories: number;
  categoryName: string;
  reviews: Review[];
  ingredients: string[];
};

async function getProduct(guid: string | undefined) {
  const res = await httpClient.get<UseProductResponse>(`/products/${guid}`);
  return res.data;
}

export default function useProduct(guid: string | undefined) {
  return useSuspenseQuery({
    queryKey: ['product', guid],
    queryFn: () => getProduct(guid),
    staleTime: 60 * 60 * 1000,
    retry: false
  });
}
