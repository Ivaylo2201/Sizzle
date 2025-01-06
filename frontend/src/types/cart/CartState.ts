import Cart from "./Cart";

export type CartState = {
  cart: Cart;
  add: (pk: number, quantity: number) => Promise<void>;
  remove: (pk: number) => Promise<void>;
  fetch: () => Promise<void>;
  order: () => Promise<void>;
};