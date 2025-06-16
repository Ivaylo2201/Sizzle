import { Navigate } from "react-router";
import { useAuthStore } from "@/lib/stores/useAuthStore";

type AuthenticatedLayoutProps = React.PropsWithChildren;

export default function AuthenticatedLayout({ children }: AuthenticatedLayoutProps) {
  const { isAuthenticated } = useAuthStore();

  if (!isAuthenticated)
    return <Navigate to='/auth/sign-in' replace />

  return children;
}