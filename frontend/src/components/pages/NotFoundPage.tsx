import { Link } from 'react-router';

import Page from '@/components/layout/PageLayout';
import patty from '@/assets/patty.png';

export default function NotFoundPage() {
  return (
    <Page>
      <div className='flex flex-col justify-center items-center'>
        <section className='flex justify-center items-center'>
          <span className='text-[8rem] md:text-[14rem] xl:text-[18rem] text-theme-pink font-rubik-mono-one'>
            4
          </span>
          <img
            className='mb-5 ml-2 size-42 md:size-60 xl:size-[25rem]'
            src={patty}
            alt='0'
          />
          <span className='text-[8rem] md:text-[14rem] xl:text-[18rem] text-theme-pink font-rubik-mono-one'>
            4
          </span>
        </section>
        <div className='font-rubi font-extrabold text-theme-orange text-center text-4xl'>
          <p>{import.meta.env.VITE_404_MESSAGE}</p>
        </div>
        <Link
          className='bg-theme-pink text-white text-xl my-14 px-8 py-3 rounded-full font-dmsans shadow-lg transition-colors duration-200 hover:bg-theme-orange'
          to='/'
        >
          Back to Home
        </Link>
      </div>
    </Page>
  );
}
