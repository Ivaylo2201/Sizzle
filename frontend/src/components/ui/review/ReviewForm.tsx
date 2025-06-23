import { useRef, useState } from 'react';
import { Rating, Textarea } from '@mantine/core';

import useAddReview from '@/lib/hooks/useAddReview';
import Button from '@/components/shared/Button';

type ReviewFormProps = {
  productId: string;
};

export default function ReviewForm({ productId }: ReviewFormProps) {
  const [selectedRating, setSelectedRating] = useState<number>(0);
  const commentRef = useRef<string | null>(null);
  const { mutate } = useAddReview(productId);

  const addReview = () => {
    mutate({
      comment: commentRef.current,
      rating: selectedRating,
      productId
    });
  };

  const handleCommentChange = (e: React.ChangeEvent<HTMLTextAreaElement>) => {
    commentRef.current = e.target.value;
  };

  return (
    <form className='bg-white min-w-[30rem] font-rubik shadow-md rounded-xl flex flex-col gap-4 justify-center items-center py-8'>
      <h1 className='text-theme-pink text-2xl font-bold'>Leave a review</h1>
      <Textarea
        label='Comment'
        className='w-3/4'
        onChange={handleCommentChange}
      />
      <div className='flex justify-center items-center gap-5'>
        <Rating
          value={selectedRating}
          size={25}
          onChange={setSelectedRating}
          style={{ '--rating-color': 'var(--color-theme-orange)' }}
        />
        <Button onClick={addReview}>Submit</Button>
      </div>
    </form>
  );
}
