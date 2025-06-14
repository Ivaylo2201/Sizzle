import { BrowserRouter, Routes, Route } from 'react-router';

import ProductsPage from '@/ui/pages/ProductsPage';
import Header from './ui/layouts/Header';

export default function Router() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/' element={<Header />} />
        <Route path='/products/:category' element={<ProductsPage />} />
        <Route path='/404' element={<div>404</div>} />
      </Routes>
    </BrowserRouter>
  );
}
