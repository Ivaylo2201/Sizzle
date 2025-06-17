import { useSuspenseQuery } from '@tanstack/react-query';
import { httpClient } from '@/utils/httpClient';
import type { Item } from '@/utils/types/models/Item';

type UseCartResponse = {
  items: Item[];
  total: number;
};

async function getCart() {
  const res = await httpClient.get<UseCartResponse>('/carts/items');
  return res.data;
}

export default function useCart() {
  return useSuspenseQuery({
    queryKey: ['cart'],
    queryFn: getCart
  });
}
