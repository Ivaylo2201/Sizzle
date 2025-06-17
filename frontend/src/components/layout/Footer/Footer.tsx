import { Phone } from 'lucide-react';
import Section from '@/components/shared/Section';

export default function Footer() {
  return (
    <footer className='font-rubik font-bold bg-theme-peach-beige flex flex-col justify-center items-center md:flex-row gap-5 py-5'>
      <Section>
        <div className=' text-theme-orange flex gap-3'>
          <Phone fill='currentColor' />
          <p>
            +359 892 350 754 -{' '}
            <span className='text-theme-pink'>Order NOW!</span>
          </p>
        </div>
      </Section>
      <Section>
        <p className='text-theme-pink'>
          © {new Date().getFullYear()} Sizzle. All rights reserved.
        </p>
      </Section>
      <Section>
        <div className='flex gap-2'>
          <span className='text-theme-pink'>Location:</span>
          <span className='text-theme-orange'>
            Varna, 102 Macedonia str. (Mon-Fri 09:00-18:00)
          </span>
        </div>
      </Section>
    </footer>
  );
}
