import Page from '@/components/layout/PageLayout';
import hero from '@/assets/hero.jpg';
import burger1 from '@/assets/burger1.jpg';
import burger2 from '@/assets/burger2.jpg';
import burger3 from '@/assets/burger3.jpg';

export default function HomePage() {
  return (
    <Page className='px-0 py-0 items-start'>
      <div className='flex flex-col justify-center items-center w-full'>
        <div
          className='relative w-full h-96 bg-cover bg-center flex justify-center items-center'
          style={{ backgroundImage: `url(${hero})` }}
        >
          <div className='absolute inset-0 bg-black opacity-50'></div>

          <p className='relative text-6xl font-bold font-dmsans text-white text-center'>
            The best burgers in town!
          </p>
        </div>
        <section className='flex flex-col xl:flex-row justify-center items-center py-8 gap-12'>
          {[burger1, burger2, burger3].map((burger, index) => (
            <div
              key={index}
              className='size-100 rounded-xl shadow-lg overflow-hidden'
            >
              <img
                src={burger}
                alt={`Burger ${index + 1}`}
                className='w-full h-full object-cover transition-transform duration-200 hover:scale-110'
              />
            </div>
          ))}
        </section>
      </div>
    </Page>
  );
}
