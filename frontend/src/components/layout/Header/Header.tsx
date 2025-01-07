import Logo from '../../common/Logo';
import AuthenticatedButtons from './AuthenticatedButtons';
import HeaderLink from './HeaderLink';

import UnauthenticatedButtons from './UnauthenticatedButtons';

type HeaderProps = {
  isAuthenticated: boolean;
};

export default function Header({ isAuthenticated }: HeaderProps) {
  return (
    <nav className='bg-[#242424] py-2 flex flex-col gap-2 items-center md:flex-row md:justify-around'>
      <section className='w-80 py-1 md:py-0 flex justify-center items-center'>
        <Logo color='white' size={3} redirectUrl='/' />
      </section>

      <section className='flex-grow flex justify-center items-center gap-5 '>
        <HeaderLink to='/menu'>Menu</HeaderLink>
        <HeaderLink to='/locations'>Locations</HeaderLink>
        <HeaderLink to='/gallery'>Gallery</HeaderLink>
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
