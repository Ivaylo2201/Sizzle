import type { Review as TReview } from '@/utils/types/models/Review';
import Review from './Review';

type ReviewListProps = {
  reviews: TReview[];
};

export default function ReviewList({ reviews }: ReviewListProps) {
  return (
    <div className='grid grid-cols-1 md:grid-cols-2 gap-4'>
      {reviews.map((review, i) => (
        <Review key={i} {...review} />
      ))}
    </div>
  );
}
