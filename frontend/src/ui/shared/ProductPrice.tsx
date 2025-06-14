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
    <div className='flex items-center gap-2 font-rubik text-theme-pink'>
      {isDiscounted && (
        <h3 className='font-bold text-xl'>${price.toFixed(2)}</h3>
      )}

      <h3
        className={`${
          isDiscounted ? 'text-theme-gray line-through' : 'font-bold text-xl'
        }`}
      >
        ${initialPrice.toFixed(2)}
      </h3>
    </div>
  );
}
