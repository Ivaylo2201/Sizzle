import { useSuspenseQuery } from "@tanstack/react-query";
import { httpClient } from "@/utils/httpClient";
import type { ShortProduct } from "@/utils/types/ShortProduct";

async function fetchProducts(category: string) {
  const res = await httpClient.get<ShortProduct[]>(`/products/${category}`);
  return res.data;
}

export default function useProducts(category: string) {
  return useSuspenseQuery({
    queryKey: ['products', category],
    queryFn: () => fetchProducts(category),
  })
}