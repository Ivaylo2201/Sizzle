import { Link } from 'react-router-dom';
import Logo from '../../common/Logo';
import LogoBurger from '../../../icons/LogoBurger';
import AuthenticatedButtons from './AuthenticatedButtons';
import UnauthenticatedButtons from './UnauthenticatedButtons';

type NavbarProps = {
  isAuthenticated: boolean;
};

export default function Navbar({ isAuthenticated }: NavbarProps) {
  return (
    <nav className='bg-[#242424] py-3 flex justify-around items-center'>
      <section>
        <Logo iconColor='white' size={3} redirectable={{ url: '/' }} />
      </section>
      <section className='flex items-center justify-center gap-4'>
        <Link
          to='/menu'
          className='py-2 font-Montserrat text-white rounded-full uppercase'
        >
          Menu
        </Link>
        <Link
          to='/gallery'
          className='py-2 font-Montserrat text-white rounded-full uppercase'
        >
          Gallery
        </Link>
        <Link
          to='/contact'
          className='py-2 font-Montserrat text-white rounded-full uppercase'
        >
          Contact
        </Link>
      </section>
      {isAuthenticated ? <AuthenticatedButtons /> : <UnauthenticatedButtons />}
    </nav>
  );
}
