import { BrowserRouter, Routes, Route } from "react-router";
import ProductList from "./lists/ProductList";
import ProductPage from "./pages/ProductPage";
import ProductCard from "../shared/ProductCard";
import type { ShortProduct } from "@/utils/types/product/ShortProduct";

const product: ShortProduct = {
  id: '1234-5678-9101',
  productName: 'Classic burger',
  initialPrice: 8,
  price: 6,
  rating: 4,
  discountPercentage: 20,
  imageUrl: '/burgers/classic_burger.png',
  description: "Simple yet irresistible—a traditional beef burger made with love, nostalgia, and the perfect balance of flavors.",
}

export default function Router() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/products/:category' element={<ProductList />} />
        <Route path='/product/:productId' element={<ProductPage />} />
        <Route path='/404' element={<div>404</div>} />
      </Routes>
    </BrowserRouter>
  );
}