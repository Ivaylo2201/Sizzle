import { useSuspenseQuery } from '@tanstack/react-query';
import { httpClient } from '@/utils/http/httpClient';
import type { CartResponse } from '@/utils/types/responses/CartResponse';

export default function useCart() {
  return useSuspenseQuery({
    queryKey: ['cart'],
    queryFn: async () => {
      const res = await httpClient.get<CartResponse>('/carts/items');
      return res.data;
    }
  });
}
