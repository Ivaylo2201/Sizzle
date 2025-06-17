import CategoryLink from '@/components/shared/CategoryLink';
import HeaderButtons from '@/components/layout/Header/HeaderButtons';
import Logo from '@/components/shared/Logo';
import HeaderSection from './HeaderSection';

export default function Header() {
  return (
    <header className='flex flex-col md:flex-row py-5 gap-4 md:gap-0 shadow-md bg-theme-peach-beige'>
      <HeaderSection>
        <Logo />
      </HeaderSection>
      <HeaderSection className='gap-8'>
        <CategoryLink to='/burgers'>Burgers</CategoryLink>
        <CategoryLink to='/doners'>Döners</CategoryLink>
        <CategoryLink to='/snacks'>Snacks</CategoryLink>
      </HeaderSection>
      <HeaderSection className='gap-4'>
        <HeaderButtons />
      </HeaderSection>
    </header>
  );
}
