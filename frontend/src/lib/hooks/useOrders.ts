import { useSuspenseQuery } from '@tanstack/react-query';

import { httpClient } from '@/utils/httpClient';
import type { Order } from '@/utils/types/models/Order';

type GetOrdersResponse = Order[];

async function getOrders() {
  const res = await httpClient.get<GetOrdersResponse>('/orders');
  return res.data;
}

export default function useOrders() {
  return useSuspenseQuery({
    queryKey: ['orders'],
    queryFn: () => getOrders(),
    staleTime: 60 * 60 * 1000,
    retry: false
  });
}
