import { Swiper, SwiperSlide } from 'swiper/react';
import { Autoplay } from 'swiper/modules';

import CategoryLink from './CategoryLink';
import { Category } from '../../../types/Category';

type CarouselProps = {
  categories: Category[];
};

export default function CategoryCarousel({ categories }: CarouselProps) {
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
        <SwiperSlide className='flex justify-center items-center shadow-none' key={i}>
          <CategoryLink imageUrl={category.imageUrl} title={category.title} className='w-full' />
        </SwiperSlide>
      ))}
    </Swiper>
  );
}
