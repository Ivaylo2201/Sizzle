type ProductPriceProps = {
  price: number;
  initialPrice: number;
  mode: 'card' | 'page';
};

export default function ProductPrice({
  price,
  initialPrice,
  mode
}: ProductPriceProps) {
  const isDiscounted = price < initialPrice;
  const sizeClass = mode === 'page' ? 'text-3xl' : 'text-xl';

  return (
    <div className='flex items-center gap-2 font-rubik text-theme-pink'>
      {isDiscounted && (
        <h3 className={`font-bold ${sizeClass}`}>${price.toFixed(2)}</h3>
      )}

      <h3
        className={`${
          isDiscounted
            ? `text-theme-gray line-through ${mode === 'page' ? 'text-xl' : ''}`
            : `font-bold ${sizeClass}`
        }`}
      >
        ${initialPrice.toFixed(2)}
      </h3>
    </div>
  );
}
