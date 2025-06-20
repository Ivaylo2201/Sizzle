import { BrowserRouter, Routes, Route } from 'react-router';

import ProductsPage from '@/components/pages/ProductsPage';
import ProductPage from '@/components/pages/ProductPage';
import HomePage from '@/components/pages/HomePage';
import NotFoundPage from '@/components/pages/NotFoundPage';
import SignInPage from '@/components/pages/SignInPage';
import SignUpPage from '@/components/pages/SignUpPage';
import OrdersPage from '@/components/pages/OrdersPage';
import CartPage from '@/components/pages/CartPage';
import CheckoutPage from '@/components/pages/CheckoutPage';
import NotFoundErrorBoundaryLayout from '@/components/layout/NotFoundErrorBoundaryLayout';
import AuthenticatedLayout from '@/components/layout/AuthenticatedLayout';

export default function Router() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/' element={<HomePage />} />

        <Route
          path='/product/:guid'
          element={
            <NotFoundErrorBoundaryLayout>
              <ProductPage />
            </NotFoundErrorBoundaryLayout>
          }
        />

        <Route
          path='/products/:category'
          element={
            <NotFoundErrorBoundaryLayout>
              <ProductsPage />
            </NotFoundErrorBoundaryLayout>
          }
        />

        <Route path='/cart'>
          <Route
            index
            element={
              <AuthenticatedLayout>
                <CartPage />
              </AuthenticatedLayout>
            }
          />

          <Route
            path='checkout'
            element={
              <AuthenticatedLayout>
                <CheckoutPage />
              </AuthenticatedLayout>
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
            <AuthenticatedLayout>
              <OrdersPage />
            </AuthenticatedLayout>
          }
        />

        <Route path='*' element={<NotFoundPage />} />
      </Routes>
    </BrowserRouter>
  );
}
