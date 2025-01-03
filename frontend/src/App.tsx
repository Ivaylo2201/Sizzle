import { BrowserRouter } from 'react-router-dom';

import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

import Router from './router';

function App() {
  return (
    <>
      <ToastContainer theme='dark' pauseOnFocusLoss={false} />
      <BrowserRouter>
        <Router />
      </BrowserRouter>
    </>
  );
}

export default App;
