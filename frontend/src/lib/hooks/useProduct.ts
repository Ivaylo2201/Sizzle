import { useSuspenseQuery } from '@tanstack/react-query';
import { httpClient } from '@/utils/http/httpClient';
import type { ProductResponse } from '@/utils/types/responses/ProductResponse';

export default function useProduct(guid: string | undefined) {
  return useSuspenseQuery({
    queryKey: ['product', guid],
    queryFn: async () => {
      const res = await httpClient.get<ProductResponse>(`/products/${guid}`);
      return res.data;
    },
    staleTime: 60 * 60 * 1000,
    retry: false
  });
}
