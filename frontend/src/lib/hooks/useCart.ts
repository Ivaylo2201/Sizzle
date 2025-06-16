import { useSuspenseQuery } from '@tanstack/react-query';
import { httpClient } from '@/utils/http/httpClient';
import type { Item } from '@/utils/types/models/Item';

type Response = {
  items: Item[];
  total: number;
};

export default function useCart() {
  return useSuspenseQuery({
    queryKey: ['cart'],
    queryFn: async () => {
      const res = await httpClient.get<Response>('/carts/items', {
        headers: { Authorization: localStorage.getItem('token') }
      });
      return res.data;
    }
  });
}
