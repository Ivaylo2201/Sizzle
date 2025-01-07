import Star from '../../../icons/Star';

type RatingProps = {
  stars: number;
};

export default function Rating({ stars }: RatingProps) {
  const MAX_STARS = 5;

  return (
    <section className='flex py-1 gap-0.5 justify-center items-center text-lg'>
      {Array.from({ length: stars }).map((_, i) => (
        <Star key={i} filled />
      ))}
      {Array.from({ length: MAX_STARS - stars }).map((_, i) => (
        <Star key={i} />
      ))}
    </section>
  );
}
