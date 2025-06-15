import { Link } from 'react-router';

import Page from '@/ui/layouts/Page';
import patty from '@/assets/patty.png';

export default function NotFoundPage() {
  const message = (import.meta.env.VITE_404_MESSAGE as string)
    .replace(/\\n/g, '\n')
    .split('\n');

  return (
    <Page>
      <div className='flex flex-col justify-center items-center'>
        <section className='flex justify-center items-center'>
          <span className='text-[8rem] md:text-[14rem] xl:text-[18rem] text-theme-orange font-rubik-mono-one'>
            4
          </span>
          <img
            className='mb-5 ml-2 size-42 md:size-60 xl:size-[25rem]'
            src={patty}
            alt='0'
          />
          <span className='text-[8rem] md:text-[14rem] xl:text-[18rem] text-theme-orange font-rubik-mono-one'>
            4
          </span>
        </section>
        <div className='font-rubik font-semibold text-theme-orange text-center text-4xl'>
          {message.map((m) => (
            <p>{m}</p>
          ))}
        </div>
        <Link
          className='bg-theme-pink text-white font-dmsans text-2xl px-14 py-4 my-18 rounded-full cursor-pointer duration-500 transition-colors hover:bg-theme-orange'
          to='/'
        >
          Back to Home
        </Link>
      </div>
    </Page>
  );
}
