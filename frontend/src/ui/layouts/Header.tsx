import CategoryLink from '@/ui/shared/CategoryLink';

export default function Header() {
  return (
    <header className='flex flex-col md:flex-row justify-around items-center'>
      <p className='my-3 font-caprasimo font-bold text-4xl md:text-3xl uppercase'>
        <span className='text-theme-pink'>Siz</span>
        <span className='text-theme-orange'>zle</span>
      </p>
      <div className='flex justify-center items-center gap-8'>
        <CategoryLink to='/burgers'>Burgers</CategoryLink>
        <CategoryLink to='/doners'>Döners</CategoryLink>
        <CategoryLink to='/snacks'>Snacks</CategoryLink>
      </div>
    </header>
  );
}
