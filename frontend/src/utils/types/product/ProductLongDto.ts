import type { ProductShortDto } from '@/utils/types/product/ProductShortDto';
import type { ReviewDto } from '@/utils/types/review/ReviewDto';

export type ProductLongDto = ProductShortDto & {
  calories: number;
  categoryName: string;
  reviews: ReviewDto[];
  ingredients: string[];
};
