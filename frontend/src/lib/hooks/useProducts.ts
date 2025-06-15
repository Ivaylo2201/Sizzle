import { useSuspenseQuery } from '@tanstack/react-query';
import { httpClient } from '@/utils/httpClient';
import type { ProductShortDto } from '@/utils/types/product/ProductShortDto';

export default function useProducts(category: string | undefined) {
  return useSuspenseQuery({
    queryKey: ['products', category],
    queryFn: async () => {
      const res = await httpClient.get<ProductShortDto[]>(
        `/products/${category}`
      );
      return res.data;
    },
    staleTime: 60 * 60 * 1000,
    retry: false
  });
}
