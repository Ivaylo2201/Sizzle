import { useQuery } from "react-query";
import { axiosClient as axios } from "../api/axiosClient";
import Product from "../types/product";

export default function useProducts(category?: string) {
  return useQuery({
    queryKey: ["products", category],
    queryFn: async () => {
      const res = await axios.get<Product[]>("/products/", { params: { category } });
      console.log(res.data);
      return res.data
    }
  })
}