import { create } from 'zustand';
import Cart from '../types/cart/Cart';
import { axiosClient as axios } from '../api/axiosClient';
import { toast } from 'react-toastify';

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
    const { data } = await axios.post<{ detail: string }>('/cart/add/', 
      {
        pk,
        quantity,
      }, 
      {
        headers: {
          Authorization: `Bearer ${localStorage.getItem('token')}`, 
        },
      }
    );
    toast.success(data.detail);
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
    const res = await axios.get<Cart>('/cart/', {
      headers: {
        Authorization: `Bearer ${localStorage.getItem('token')}`, 
      },
    });
    set({ cart: res.data });
  }
}));
