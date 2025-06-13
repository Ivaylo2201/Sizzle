import type { ShortProduct } from "@/utils/types/product/ShortProduct";
import { useNavigate } from "react-router";
import DiscountLabel from "./DiscountLabel";
import ProductPriceLabel from "./ProductPriceLabel";
import { Rating } from '@mantine/core';

type ProductCardProps = {
  product: ShortProduct
}

export default function ProductCard({ product }: ProductCardProps) {
  const navigate = useNavigate();
  const onCardClick = () => navigate(`/product/${product.id}`);

  const imageUrl = `${import.meta.env.VITE_IMAGE_BASE_URL}/${product.imageUrl}`
  const isDiscounted = product.discountPercentage > 0;

  return (
    <article className=" relative w-80 p-3 bg-white shadow-md rounded-2xl flex flex-col" >
      {isDiscounted &&
       <DiscountLabel discountPercentage={product.discountPercentage} />}

      <img 
        src={imageUrl}
        alt={`Image of ${product.productName}`}
        className="w-[15rem] my-2 object-contain self-center"
      />
      <h2 className="font-rubik text-xl px-2">{product.productName}</h2>
      <ProductPriceLabel price={product.price} initialPrice={product.initialPrice} />
      <p className="font-rubik text-theme-gray px-2 text-sm line-clamp-2">{product.description}</p>
      <Rating className="my-4 px-2" defaultValue={product.rating} readOnly />
      <button className="flex-auto bg-theme-pink text-white p-2 rounded-xl font-rubik cursor-pointer hover:bg-theme-lightpink duration-150 transition-colors" onClick={onCardClick}>View</button>
    </article>
  );
}
