import Logo from '../../common/Logo';
import LogoBurger from '../../../icons/LogoBurger';
import AuthenticatedButtons from './AuthenticatedButtons';
import UnauthenticatedButtons from './UnauthenticatedButtons';
import Navlink from './Navlink';

type NavbarProps = {
  isAuthenticated: boolean;
};

export default function Navbar({ isAuthenticated }: NavbarProps) {
  return (
    <nav className='bg-[#242424] py-2 flex flex-col gap-2 items-center md:flex-row md:justify-around'>
      <section className='w-80 flex justify-center items-center'>
        <Logo color='white' size={3} redirectable={{ url: '/' }} />
      </section>

      <section className='flex-grow flex justify-center items-center gap-5 '>
        <Navlink to='/menu'>Menu</Navlink>
        <Navlink to='/locations'>Locations</Navlink>
        <Navlink to='/gallery'>Gallery</Navlink>
      </section>

      <section className='w-80 flex justify-center items-center'>
        {isAuthenticated ? (
          <AuthenticatedButtons />
        ) : (
          <UnauthenticatedButtons />
        )}
      </section>
    </nav>
  );
}
