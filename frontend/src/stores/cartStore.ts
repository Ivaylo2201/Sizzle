import { create } from 'zustand';
import Cart from '../types/cart/Cart';
import { axiosClient as axios } from '../api/axiosClient';

export type CartState = {
  cart: Cart;
  add: (pk: number, quantity: number) => Promise<void>;
  remove: (pk: number) => Promise<void>;
  fetch: () => Promise<void>;
  order: () => Promise<void>;
};

export const useCartStore = create<CartState>((set, get) => ({
  cart: { items: [], subtotal: 0 },
  add: async (pk: number, quantity: number) => {
    // api call;
    set({
      cart: {
        items: [...get().cart.items, { pk, quantity }],
        subtotal: get().cart.subtotal + 1
      }
    });
    get().fetch();
  },
  remove: async (pk: number) => {
    // api call
    get().fetch();
  },
  order: async () => {
    // api call
    get().fetch();
  },
  fetch: async () => {
    const res = await axios.get<Cart>('/cart/');
    set({ cart: res.data });
  }
}));
