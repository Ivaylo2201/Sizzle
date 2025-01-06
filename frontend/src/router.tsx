import { Route, Routes } from 'react-router-dom';
import HomePage from './pages/HomePage';
import SignInPage from './pages/SignInPage';
import SignUpPage from './pages/SignUpPage';
import ForgotPasswordPage from './pages/ForgotPasswordPage';
import MenuPage from './pages/MenuPage';
import ProductsPage from './pages/ProductsPage';

export default function Router() {
  return (
    <Routes>
      <Route path='/auth'>
        <Route path='signin' element={<SignInPage />} />
        <Route path='signup' element={<SignUpPage />} />
        <Route path='forgot-password' element={<ForgotPasswordPage />} />
      </Route>

      <Route path='/' element={<HomePage />} />
      <Route path='/menu/:category' element={<ProductsPage />} />
      <Route path='/menu' element={<MenuPage />} />
    </Routes>
  );
}
