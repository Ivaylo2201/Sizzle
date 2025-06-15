import CategoryLink from '@/ui/shared/CategoryLink';

export default function Header() {
  return (
    <header className='py-5 gap-10 flex justify-center items-center'>
      <CategoryLink to='/burgers'>Burgers</CategoryLink>
      <CategoryLink to='/doners'>Döners</CategoryLink>
      <CategoryLink to='/snacks'>Snacks</CategoryLink>
    </header>
  );
}
