import { useAuthStore } from "@/lib/stores/useAuthStore";
import { Navigate } from "react-router";

type SignInRequiredProps = React.PropsWithChildren;

export default function SignInRequired({ children }: SignInRequiredProps) {
  const { isAuthenticated } = useAuthStore();

  if (!isAuthenticated)
    return <Navigate to='/auth/sign-in' replace />

  return children;
}
