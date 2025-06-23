import { Rating, type RatingProps } from '@mantine/core';

type SizzleRatingProps = RatingProps;

export default function SizzleRating({
  value,
  onChange,
  size = 20,
  ...rest
}: SizzleRatingProps) {
  return (
    <Rating
      value={value}
      size={size}
      onChange={onChange}
      style={{ '--rating-color': 'var(--color-theme-orange)' }}
      {...rest}
    />
  );
}
