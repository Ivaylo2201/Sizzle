import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';

import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

import SignInPage from './pages/SignInPage';
import SignUpPage from './pages/SignUpPage';
import ForgotPasswordPage from './pages/ForgotPasswordPage';
import HomePage from './pages/HomePage';

function App() {
  return (
    <>
      <ToastContainer theme='dark' />
      <Router>
        <Routes>
          <Route path='/' element={<HomePage />} />
          <Route path='/signin' element={<SignInPage />} />
          <Route path='/signup' element={<SignUpPage />} />
          <Route path='/forgot-password' element={<ForgotPasswordPage />} />
        </Routes>
      </Router>
    </>
  );
}

export default App;
