import Navbar from '../components/layout/Navbar/Navbar';
import Page from './Page';

export default function NavbarLayout({ children }: React.PropsWithChildren) {
  return (
    <Page>
      <Navbar isAuthenticated={true} />
      <main className='bg-red-500 h-screen p-6'>{children}</main>
    </Page>
  );
}
