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
