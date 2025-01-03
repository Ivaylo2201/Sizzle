import { Swiper, SwiperSlide } from 'swiper/react';
import { Autoplay, Pagination } from 'swiper/modules';

import 'swiper/css';
import 'swiper/css/navigation';
import 'swiper/css/pagination';

type ImageSwiperProps = {
  images: string[];
};

export default function ImageSwiper({ images }: ImageSwiperProps) {
  return (
    <>
      <Swiper
        modules={[Autoplay, Pagination]}
        pagination={{ clickable: true }}
        autoplay={{
          delay: 4000,
          disableOnInteraction: false
        }}
        className='w-full h-full'
      >
        {images.map((image, index) => (
          <SwiperSlide key={index} className='w-full h-full'>
            <img
              src={image}
              alt={`Slide ${index + 1}`}
              className='w-full h-full object-cover'
            />
          </SwiperSlide>
        ))}
      </Swiper>

      <style>{`
        .swiper-pagination-bullet {
          background-color: white !important; 
          opacity: 0.5; 
        }
        .swiper-pagination-bullet-active {
          background-color: white !important; 
          opacity: 1;
        }
      `}</style>
    </>
  );
}
