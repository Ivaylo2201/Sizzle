import { create } from 'zustand';

type AuthStore = {
  isAuthenticated: boolean;
  signIn: () => void;
  signOut: () => void;
};

export const useAuthStore = create<AuthStore>((set) => ({
  isAuthenticated: !!localStorage.getItem('token'),
  signIn: () => set({ isAuthenticated: true }),
  signOut: () => {
    set({ isAuthenticated: false });
    localStorage.removeItem('token');
  }
}));
