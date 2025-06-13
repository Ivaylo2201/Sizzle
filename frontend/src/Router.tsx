import { BrowserRouter, Routes, Route } from "react-router";
import ProductsPage from "@/ui/pages/ProductsPage";

export default function Router() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/products/:category' element={<ProductsPage />} />
      </Routes>
    </BrowserRouter>
  );
}