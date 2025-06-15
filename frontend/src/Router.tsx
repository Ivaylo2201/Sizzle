import { BrowserRouter, Routes, Route } from 'react-router';

import ProductsPage from '@/ui/pages/ProductsPage';
import ProductPage from '@/ui/pages/ProductsPage';
import HomePage from '@/ui/pages/HomePage';

export default function Router() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/' element={<HomePage />} />
        <Route path='/products/:category' element={<ProductsPage />} />
        <Route path='/product/:guid' element={<ProductPage />} />
        <Route path='/404' element={<div>404</div>} />
      </Routes>
    </BrowserRouter>
  );
}
