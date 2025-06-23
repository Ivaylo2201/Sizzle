import type { Review as TReview } from '@/utils/types/models/Review';
import Review from '@/components/ui/review/Review';

type ReviewListProps = {
  reviews: TReview[];
};

export default function ReviewList({ reviews }: ReviewListProps) {
  const LIMIT = 6;

  return (
    <div className='flex flex-col justify-center items-center gap-6'>
      <h1 className='font-rubik text-3xl font-bold text-theme-pink'>Latest reviews</h1>
      <ul className='grid grid-cols-1 md:grid-cols-2 gap-4'>
        {reviews.slice(0, LIMIT).map((review, i) => (
          <li>
            <Review key={i} {...review} />
          </li>
        ))}
      </ul>
    </div>
  );
}
