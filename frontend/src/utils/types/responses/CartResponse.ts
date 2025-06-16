import type { Item } from '@/utils/types/models/Item';

export type CartResponse = {
  items: Item[];
  total: number;
};
