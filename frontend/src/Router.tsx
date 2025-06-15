import { Suspense } from 'react';
import { BrowserRouter, Routes, Route } from 'react-router';

import ProductsPage from '@/ui/pages/ProductsPage';
import ProductPage from '@/ui/pages/ProductPage';
import HomePage from '@/ui/pages/HomePage';
import NotFoundErrorBoundary from '@/ui/shared/NotFoundErrorBoundary';
import NotFoundPage from '@/ui/pages/NotFoundPage';
import LoadingSpinner from '@/ui/shared/LoadingSpinner';

export default function Router() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/' element={<HomePage />} />
        <Route
          path='/product/:guid'
          element={
            <Suspense fallback={<LoadingSpinner />}>
              <NotFoundErrorBoundary>
                <ProductPage />
              </NotFoundErrorBoundary>
            </Suspense>
          }
        />
        <Route
          path='/products/:category'
          element={
            <Suspense fallback={<LoadingSpinner />}>
              <NotFoundErrorBoundary>
                <ProductsPage />
              </NotFoundErrorBoundary>
            </Suspense>
          }
        />
        <Route path='*' element={<NotFoundPage />} />
      </Routes>
    </BrowserRouter>
  );
}
