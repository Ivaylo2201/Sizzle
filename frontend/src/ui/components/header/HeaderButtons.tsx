import { useAuthStore } from '@/lib/stores/useAuthStore';

import CartButton from '@/ui/components/header/CartButton';
import OrdersButton from '@/ui/components/header/OrdersButton';
import SignOutButton from '@/ui/components/header/SignOutButton';
import SignInButton from '@/ui/components/header/SignInButton';
import SignUpButton from '@/ui/components/header/SignUpButton';

export default function HeaderButtons() {
  const { isAuthenticated } = useAuthStore();

  if (isAuthenticated) {
    return (
      <>
        <CartButton />
        <OrdersButton />
        <SignOutButton />
      </>
    );
  }

  return (
    <>
      <SignInButton />
      <SignUpButton />
    </>
  );
}
