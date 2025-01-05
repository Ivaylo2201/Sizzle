import { create } from 'zustand';

type AuthState = {
  isAuthenticated: boolean;
  email: string | null;
  signIn: (email: string) => void;
  signOut: () => void;
};

const useAuthStore = create<AuthState>((set, get) => ({
  isAuthenticated: false,
  email: null,
  signIn: (email) => {
    console.log(`Logging in as ${email}`);
    set({ isAuthenticated: true, email: email })
  },
  signOut: () => {
    console.log(`${get().email} logged out`);
    set({ isAuthenticated: false, email: null })
  }
}));

export default useAuthStore;
