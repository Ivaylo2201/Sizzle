import { useSuspenseQuery } from "@tanstack/react-query";
import { httpClient } from "@/utils/httpClient";
import type { ShortProduct } from "@/utils/types/product/ShortProduct";

export default function useProducts(category: string | undefined) {
  return useSuspenseQuery({
    queryKey: ['products', category],
    queryFn: async () => {
      const res = await httpClient.get<ShortProduct[]>(`/products/${category}`);
      return res.data;
    },
  })
}