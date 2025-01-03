import { Navigate } from 'react-router-dom';

export default function ProtectedLayout({ children }: React.PropsWithChildren) {
  // TODO: implement logic to check if the user is authenticated
  const isAuthenticated: boolean = true;

  console.log(isAuthenticated ? "rendering" : "redirecting");

  return isAuthenticated ? <>{children}</> : <Navigate to='/signin' />;
}
