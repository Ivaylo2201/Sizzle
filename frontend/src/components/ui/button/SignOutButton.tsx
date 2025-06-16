import { useAuthStore } from '@/lib/stores/useAuthStore';
import { LogOut } from 'lucide-react';

export default function SignOutButton() {
  const { signOut } = useAuthStore();

  return (
    <button
      onClick={signOut}
      className='bg-theme-pink shadow-xl hover:bg-theme-orange transition-colors duration-200 flex justify-center items-center rounded-full p-2 gap-4 cursor-pointer relative font-dmsans'
    >
      <LogOut className='text-white' size={19} strokeWidth={1.75} />
    </button>
  );
}
