import CategoryLink from '@/ui/shared/CategoryLink';
import Logo from '../shared/Logo';

export default function Header() {
  return (
    <header className='flex flex-col md:flex-row py-2 gap-1.5 justify-around items-center'>
      <section className=''>
        <Logo />
      </section>
      <section className='flex justify-center items-center gap-8'>
        <CategoryLink to='/burgers'>Burgers</CategoryLink>
        <CategoryLink to='/doners'>Döners</CategoryLink>
        <CategoryLink to='/snacks'>Snacks</CategoryLink>
      </section>
    </header>
  );
}
