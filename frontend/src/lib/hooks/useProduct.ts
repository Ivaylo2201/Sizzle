import { useSuspenseQuery } from "@tanstack/react-query";
import { httpClient } from "@/utils/httpClient";
import type { ProductLongDto } from "@/utils/types/product/ProductLongDto";

export default function useProduct(id: string | undefined) {
  return useSuspenseQuery({
    queryKey: ['product', id],
    queryFn: async () => {
      const res = await httpClient.get<ProductLongDto>(`/products/${id}`); 
      return res.data;
    },
  })
}