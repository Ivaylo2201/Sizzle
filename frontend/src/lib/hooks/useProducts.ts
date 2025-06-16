import { useSuspenseQuery } from '@tanstack/react-query';
import { httpClient } from '@/utils/http/httpClient';
import type { ProductsResponse } from '@/utils/types/responses/ProductsResponse';

export default function useProducts(category: string | undefined) {
  return useSuspenseQuery({
    queryKey: ['products', category],
    queryFn: async () => {
      const res = await httpClient.get<ProductsResponse>(
        `/products/${category}`
      );
      return res.data;
    },
    staleTime: 60 * 60 * 1000,
    retry: false
  });
}
