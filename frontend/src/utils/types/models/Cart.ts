import type { Item } from "@/utils/types/models/Item";

export type Cart = {
  items: Item[];
  total: number;
};