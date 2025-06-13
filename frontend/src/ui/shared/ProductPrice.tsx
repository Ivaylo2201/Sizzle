type ProductPriceProps = {
  price: number;
  initialPrice: number;
};

export default function ProductPrice({
  price,
  initialPrice
}: ProductPriceProps) {
  const isDiscounted = price < initialPrice;

  return (
    <div className='flex items-center gap-2'>
      {isDiscounted && (
        <h3 className='text-theme-pink font-rubik font-bold text-xl'>
          ${price.toFixed(2)}
        </h3>
      )}

      <h3
        className={`text-theme-gray font-rubik ${
          isDiscounted ? 'line-through' : ''
        }`}
      >
        ${initialPrice.toFixed(2)}
      </h3>
    </div>
  );
}
