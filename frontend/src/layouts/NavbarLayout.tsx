import Navbar from '../components/layout/Navbar';
import Page from './Page';

export default function NavbarLayout({ children }: React.PropsWithChildren) {
  return (
    <Page className='gap'>
      <Navbar />
      {children}
    </Page>
  );
}
