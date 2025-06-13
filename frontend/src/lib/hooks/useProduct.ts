import { useSuspenseQuery } from "@tanstack/react-query";
import { httpClient } from "@/utils/httpClient";
import type { LongProduct } from "@/utils/types/product/LongProduct";

export default function useProduct(id: string | undefined) {
  return useSuspenseQuery({
    queryKey: ['product', id],
    queryFn: async () => {
      const res = await httpClient.get<LongProduct>(`/products/${id}`); 
      return res.data;
    },
  })
}