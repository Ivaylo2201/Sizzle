import CategoryLink from '@/ui/components/product/CategoryLink';
import Logo from '@/ui/components/product/Logo';
import HeaderButtons from '@/ui/components/header/HeaderButtons';

export default function Header() {
  return (
    <header className='flex flex-col md:flex-row py-5 gap-4 md:gap-0 justify-around items-center'>
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
