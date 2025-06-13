type ProductPriceProps = {
  price: number;
  initialPrice: number;
}

export default function ProductPriceLabel({ price, initialPrice }: ProductPriceProps) {
  const isDiscounted = price < initialPrice;

  return (
    <span className="flex items-center text-2xl font-rubik px-2 my-2 gap-2">
      <h2 className=" text-theme-pink">€{price.toFixed(2)}</h2>

      {isDiscounted && <h2 className="text-theme-gray text-xl line-through"> €{initialPrice.toFixed(2)}</h2>}
    </span>
  )
}
