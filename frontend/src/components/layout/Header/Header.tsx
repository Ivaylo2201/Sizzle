import CategoryLink from '@/components/shared/CategoryLink';
import HeaderButtons from '@/components/layout/Header/HeaderButtons';
import Logo from '@/components/shared/Logo';

export default function Header() {
  return (
    <header className='flex flex-col md:flex-row py-5 gap-4 md:gap-0 justify-around items-center shadow-md bg-theme-peach-beige'>
      <section>
        <Logo />
      </section>
      <section className='flex justify-center items-center gap-8'>
        <CategoryLink to='/burgers'>Burgers</CategoryLink>
        <CategoryLink to='/doners'>Döners</CategoryLink>
        <CategoryLink to='/snacks'>Snacks</CategoryLink>
      </section>
      <section className='flex justify-center items-center gap-4'>
        <HeaderButtons />
      </section>
    </header>
  );
}
