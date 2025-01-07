import { create } from 'zustand';

type AuthState = {
  isAuthenticated: boolean;
  signIn: () => void;
  signOut: () => void;
};

const useAuthStore = create<AuthState>((set) => ({
  isAuthenticated: false,
  signIn: () => set({ isAuthenticated: true }),
  signOut: () => set({ isAuthenticated: false })
}));

export default useAuthStore;
