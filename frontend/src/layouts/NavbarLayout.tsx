import Navbar from '../components/layout/Navbar/Navbar';
import useAuthStore from '../stores/authStore';
import Page from './Page';

type NavbarLayoutProps = { idented?: boolean } & React.PropsWithChildren;

export default function NavbarLayout({ idented, children }: NavbarLayoutProps) {
  const { isAuthenticated } = useAuthStore();

  return (
    <Page>
      <Navbar isAuthenticated={isAuthenticated} />
      <main className={idented ? 'p-7' : ''}>{children}</main>
    </Page>
  );
}
