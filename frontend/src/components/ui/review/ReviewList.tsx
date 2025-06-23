import React from 'react';

import type { Review as TReview } from '@/utils/types/models/Review';
import Review from '@/components/ui/review/Review';

type ReviewListProps = {
  reviews: TReview[];
};

export default function ReviewList({ reviews }: ReviewListProps) {
  const limit = 6;
  const hasReviews = reviews.length > 0;

  return (
    <div className='flex flex-col justify-center items-center gap-6'>
      {hasReviews ? (
        <React.Fragment>
          <h1 className='font-rubik text-3xl font-bold text-theme-pink'>
            Latest reviews
          </h1>
          <ul className='grid grid-cols-1 md:grid-cols-2 gap-4'>
            {reviews.slice(0, limit).map((review, i) => (
              <li key={i}>
                <Review {...review} />
              </li>
            ))}
          </ul>
        </React.Fragment>
      ) : (
        <p className='text-3xl font-rubik font-bold text-theme-gray'>
          No reviews yet
        </p>
      )}
    </div>
  );
}
