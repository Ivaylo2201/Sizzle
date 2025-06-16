import React from 'react';

import { useAuthStore } from '@/lib/stores/useAuthStore';
import CartButton from '@/components/ui/button/CartButton';
import OrdersButton from '@/components/ui/button/OrdersButton';
import SignOutButton from '@/components/ui/button/SignOutButton';
import SignInButton from '@/components/ui/button/SignInButton';
import SignUpButton from '@/components/ui/button/SignUpButton';

export default function HeaderButtons() {
  const { isAuthenticated } = useAuthStore();

  if (isAuthenticated) {
    return (
      <React.Fragment>
        <OrdersButton />
        <CartButton />
        <SignOutButton />
      </React.Fragment>
    );
  }

  return (
    <React.Fragment>
      <SignInButton />
      <SignUpButton />
    </React.Fragment>
  );
}
