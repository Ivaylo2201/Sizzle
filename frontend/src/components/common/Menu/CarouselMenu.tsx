import { Swiper, SwiperSlide } from 'swiper/react';
import { Autoplay } from 'swiper/modules';
import Category from './Category';
import TMenu from '../../../types/menu';

export default function CarouselMenu({ categories }: TMenu) {
  return (
    <Swiper
      modules={[Autoplay]}
      autoplay={{
        delay: 4000,
        disableOnInteraction: false
      }}
      spaceBetween={20}
      className='w-[90%]'
      breakpoints={{
        1835: {
          slidesPerView: 4
        },
        1400: {
          slidesPerView: 3
        }
      }}
    >
      {categories.map((category, i) => (
        <SwiperSlide
          className='flex justify-center items-center shadow-none'
          key={i}
        >
          <Category
            imageUrl={category.imageUrl}
            title={category.title}
            className='w-full'
          />
        </SwiperSlide>
      ))}
    </Swiper>
  );
}
