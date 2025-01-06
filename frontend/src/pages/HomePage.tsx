import NavbarLayout from '../layouts/NavbarLayout';
import cheeseburger from '../assets/common/hero-cheeseburger.png';
import sidebarTexture from '../assets/common/sidebar-texture.jpg';
import { Link } from 'react-router-dom';

export default function HomePage() {
  return (
    <NavbarLayout>
      <main className=' bg-white flex justify-between'>
        <aside
          className='h-full w-[12rem] hidden md:block'
          style={{
            backgroundSize: 'auto 175%',
            backgroundImage: `url(${sidebarTexture})`,
            backgroundRepeat: 'no-repeat'
          }}
        ></aside>

        <section className='py-10 flex flex-grow flex-col lg:flex-row justify-center gap-10 items-center md:items-left'>
          <section className='flex flex-col gap-4 px-4'>
            <div className='bg-theme-red h-2 w-56'></div>
            <p className='py-2 font-Montserrat uppercase font-light text-4xl md:text-2xl lg:text-5xl '>
              new bacon cheeseburger
            </p>
            <Link
              to={'/menu'}
              className='bg-theme-red hover:bg-theme-lightred transition-colors w-2/5 text-center duration-250 px-10 py-3 rounded-full text-white font-Montserrat uppercase'
            >
              Explore the menu
            </Link>
          </section>
          <div className='w-1/3'>
            <img
              src={cheeseburger}
              alt='Image'
              className='h-full w-full object-contain'
            />
          </div>
        </section>

        <aside
          className='h-full w-[12rem] hidden md:block'
          style={{
            backgroundSize: 'auto 175%',
            backgroundImage: `url(${sidebarTexture})`,
            backgroundRepeat: 'no-repeat',
            backgroundPosition: 'right center'
          }}
        ></aside>
      </main>
    </NavbarLayout>
  );
}
