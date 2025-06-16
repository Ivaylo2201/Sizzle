import { Suspense } from 'react';
import { BrowserRouter, Routes, Route } from 'react-router';

import ProductsPage from '@/ui/pages/ProductsPage';
import ProductPage from '@/ui/pages/ProductPage';
import HomePage from '@/ui/pages/HomePage';
import NotFoundErrorBoundary from '@/ui/shared/NotFoundErrorBoundary';
import NotFoundPage from '@/ui/pages/NotFoundPage';
import LoadingSpinner from '@/ui/shared/LoadingSpinner';
import SignInPage from '@/ui/pages/SignInPage';
import SignUpPage from '@/ui/pages/SignUpPage';
import OrdersPage from '@/ui/pages/OrdersPage';
import CartPage from '@/ui/pages/CartPage';
import CheckoutPage from '@/ui/pages/CheckoutPage';
import SignInRequired from '@/ui/components/auth/SignInRequired';

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

        <Route path='/cart'>
          <Route
            index
            element={
              <SignInRequired>
                <CartPage />
              </SignInRequired>
            }
          />
          <Route
            path='checkout'
            element={
              <SignInRequired>
                <CheckoutPage />
              </SignInRequired>
            }
          />
        </Route>

        <Route path='/auth'>
          <Route path='sign-in' element={<SignInPage />} />
          <Route path='sign-up' element={<SignUpPage />} />
        </Route>

        <Route
          path='/orders'
          element={
            <SignInRequired>
              <OrdersPage />
            </SignInRequired>
          }
        />

        <Route path='*' element={<NotFoundPage />} />
      </Routes>
    </BrowserRouter>
  );
}
