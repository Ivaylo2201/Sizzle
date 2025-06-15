import { useSuspenseQuery } from '@tanstack/react-query';
import { httpClient } from '@/utils/httpClient';
import type { ProductLongDto } from '@/utils/types/product/ProductLongDto';

export default function useProduct(guid: string | undefined) {
  return useSuspenseQuery({
    queryKey: ['product', guid],
    queryFn: async () => {
      const res = await httpClient.get<ProductLongDto>(`/products/${guid}`);
      return res.data;
    },
    staleTime: 60 * 60 * 1000,
    retry: false
  });
}
