import React from 'react';
import { createRoot } from 'react-dom/client';
import '@mantine/core/styles.css';
import './index.css';

import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import Router from '@/Router';
import { MantineProvider } from '@mantine/core';

const queryClient = new QueryClient();

createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <MantineProvider>
      <QueryClientProvider client={queryClient}>
        <Router />
      </QueryClientProvider>
    </MantineProvider>
  </React.StrictMode>
);
