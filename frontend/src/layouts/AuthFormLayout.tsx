import { PropsWithChildren } from 'react';
import { useEffect, useState } from 'react';

import pizza from '../assets/loginPizza.jpg';
import sushi from '../assets/loginSushi.jpg';
import burger from '../assets/loginBurger.jpg';
import steak from '../assets/loginGrill.jpg';
import cake from '../assets/loginDessert.jpg';
import salad from '../assets/loginSalad.jpg';
import handleWindowResize from '../helpers/handleWindowResize';
import ImageSwiper from '../components/common/ImageSwiper';
import Page from './Page';

export default function AuthFormLayout({ children }: PropsWithChildren) {
  const [isDesktop, setIsDesktop] = useState<boolean | null>(null);

  useEffect(() => {
    const WINDOW_BOUNDARY: number = 950;
    const resize = () => handleWindowResize(WINDOW_BOUNDARY, setIsDesktop);

    resize();

    window.addEventListener('resize', resize);

    return () => window.removeEventListener('resize', resize);
  }, []);

  return (
    <Page className='justify-center items-center'>
      <div className='max-w-[875px] h-[625px] flex rounded-xl overflow-hidden shadow-lg'>
        {isDesktop && (
          <section className='w-[55%] h-full shadow-xl'>
            <ImageSwiper images={[salad, sushi, pizza, burger, steak, cake]} />
          </section>
        )}

        <section className='bg-white flex-1 flex flex-col p-16 justify-center'>
          {children}
        </section>
      </div>
    </Page>
  );
}
