import { LogIn } from 'lucide-react';
import { Link } from 'react-router';

export default function SignInButton() {
  return (
    <Link
      to='/auth/sign-in'
      className='bg-theme-pink shadow-xl hover:bg-theme-orange transition-colors duration-200 flex justify-center items-center rounded-full p-2 gap-4 cursor-pointer relative font-dmsans'
    >
      <LogIn className='text-white' size={19} strokeWidth={1.75} />
    </Link>
  );
}
