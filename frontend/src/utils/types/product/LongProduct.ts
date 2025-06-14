import type { ShortProduct } from "@/utils/types/product/ShortProduct";
import type { Review } from "@/utils/types/review/Review";

export type LongProduct = ShortProduct & {
  calories: number;
  categoryName: string;
  reviews: Review[];
  ingredients: string[];
}