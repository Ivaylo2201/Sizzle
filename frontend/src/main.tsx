import { createRoot } from 'react-dom/client';
import './index.css';

import ProductList from '@/ui/components/ProductList.tsx';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';

const queryClient = new QueryClient();

createRoot(document.getElementById('root')!).render(
  <QueryClientProvider client={queryClient}>
    <ProductList category='burgers' />
  </QueryClientProvider>
);
