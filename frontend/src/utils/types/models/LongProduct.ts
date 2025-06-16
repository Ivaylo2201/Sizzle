import type { ShortProduct } from '@/utils/types/models/ShortProduct';
import type { Review } from '@/utils/types/models/Review';

export type LongProduct = ShortProduct & {
  calories: number;
  categoryName: string;
  reviews: Review[];
  ingredients: string[];
};
