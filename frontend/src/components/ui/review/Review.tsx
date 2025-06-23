import type { Review as TReview } from '@/utils/types/models/Review';
import { Rating } from '@mantine/core';

type ReviewProps = TReview;

export default function Review({
  rating,
  comment,
  username,
  createdAt
}: ReviewProps) {
  return (
    <article className='min-w-[25rem] bg-white shadow-md rounded-xl flex flex-col p-4 gap-3 font-rubik'>
      <div className='flex flex-col gap-1'>
        <div className='flex items-center gap-2'>
          <p>{username}</p>
          <p className='text-sm text-theme-gray italic'>
            {new Date(createdAt).toLocaleDateString('en-US', {
              year: 'numeric',
              month: 'short',
              day: 'numeric'
            })}
          </p>
        </div>

        <Rating
          value={rating}
          readOnly
          size={15}
          style={{ '--rating-color': 'var(--color-theme-orange)' }}
        />
      </div>
      <p className='text-theme-gray italic'>
        {comment ?? 'No comment provided.'}
      </p>
    </article>
  );
}
