import { useRef, useState } from 'react';
import { Rating, Textarea } from '@mantine/core';
import { toast } from 'react-toastify';

import useAddReview from '@/lib/hooks/useAddReview';
import Button from '@/components/shared/Button';
import type { LongProduct } from '@/utils/types/models/LongProduct';
import SizzleRating from '@/components/shared/SizzleRating';

type ReviewFormProps = {
  product: LongProduct;
};

export default function ReviewForm({ product }: ReviewFormProps) {
  const [selectedRating, setSelectedRating] = useState<number | null>(null);
  const commentRef = useRef<string | null>(null);
  const { mutate } = useAddReview(product);

  const addReview = (e: React.FormEvent) => {
    e.preventDefault();

    if (!selectedRating) {
      toast.error('Rating must be provided.');
      return;
    }

    mutate({
      comment: commentRef.current,
      rating: selectedRating,
      productId: product.id
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
        <SizzleRating
          value={selectedRating ?? 0}
          size={25}
          onChange={setSelectedRating}
        />
        <Button onClick={addReview}>Submit</Button>
      </div>
    </form>
  );
}
