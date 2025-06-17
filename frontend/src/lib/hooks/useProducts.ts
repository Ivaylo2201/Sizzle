import { useSuspenseQuery } from '@tanstack/react-query';
import { httpClient } from '@/utils/httpClient';
import type { ShortProduct } from '@/utils/types/models/ShortProduct';

type UseProductsResponse = ShortProduct[];

async function getProducts(category: string | undefined) {
  const res = await httpClient.get<UseProductsResponse>(
    `/products/${category}`
  );
  return res.data;
}

export default function useProducts(category: string | undefined) {
  return useSuspenseQuery({
    queryKey: ['products', category],
    queryFn: () => getProducts(category),
    staleTime: 60 * 60 * 1000,
    retry: false
  });
}
