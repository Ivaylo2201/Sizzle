import type { Item } from '@/utils/types/models/Item';

export type Order = {
  id: number;
  items: Item[];
  cityName: string;
  streetName: string;
  streetNumber: number;
  createdAt: string;
  total: number;
  notes: string | null;
};
