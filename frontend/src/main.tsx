import React from 'react';
import { createRoot } from 'react-dom/client';
import { MantineProvider } from '@mantine/core';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import { ToastContainer } from 'react-toastify';

import '@mantine/core/styles.css';
import '@mantine/dates/styles.css';
import 'react-toastify/dist/ReactToastify.css';
import './index.css';

import Router from '@/Router';

const queryClient = new QueryClient();

createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <MantineProvider>
      <QueryClientProvider client={queryClient}>
        <Router />
        <ToastContainer
          autoClose={500}
          pauseOnHover={false}
          toastStyle={{
            fontFamily: 'Rubik, sans-serif',
            backgroundColor: 'var(--color-theme-beige)'
          }}
          closeButton={false}
        />
      </QueryClientProvider>
    </MantineProvider>
  </React.StrictMode>
);
