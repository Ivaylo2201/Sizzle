import { Swiper, SwiperSlide } from 'swiper/react';
import { Autoplay, Pagination } from 'swiper/modules';

type ImageSwiperProps = {
  images: string[];
};

export default function ImageSwiper({ images }: ImageSwiperProps) {
  return (
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
        <SwiperSlide key={index}>
          <img
            src={image}
            alt={`Slide ${index + 1}`}
            className='w-full h-full object-cover'
          />
        </SwiperSlide>
      ))}
    </Swiper>
  );
}
