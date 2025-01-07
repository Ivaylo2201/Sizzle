type DiscountLabelProps = { discountPercentage: number };

export default function DiscountLabel({
  discountPercentage
}: DiscountLabelProps) {
  return (
    <span className='bg-red-500 text-white px-1.5 py-0.5 rounded-lg absolute top-2.5 right-2.5'>
      -{discountPercentage}%
    </span>
  );
}
