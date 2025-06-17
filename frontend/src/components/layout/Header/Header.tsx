import CategoryLink from '@/components/shared/CategoryLink';
import HeaderButtons from '@/components/layout/Header/HeaderButtons';
import Logo from '@/components/shared/Logo';
import Section from '@/components/shared/Section';

export default function Header() {
  return (
    <header className='flex flex-col md:flex-row py-5 gap-4 md:gap-0 shadow-md justify-center items-center bg-theme-peach-beige'>
      <Section>
        <Logo />
      </Section>
      <Section className='gap-8'>
        <CategoryLink to='/burgers'>Burgers</CategoryLink>
        <CategoryLink to='/doners'>Döners</CategoryLink>
        <CategoryLink to='/snacks'>Snacks</CategoryLink>
      </Section>
      <Section className='gap-4'>
        <HeaderButtons />
      </Section>
    </header>
  );
}
