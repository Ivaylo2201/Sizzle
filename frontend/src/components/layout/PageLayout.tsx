import Header from '@/components/layout/Header/Header';
import Footer from '@/components/layout/Footer/Footer';

type PageLayoutProps = React.PropsWithChildren;

export default function PageLayout({ children }: PageLayoutProps) {
  return (
    <div className='flex flex-col min-h-screen bg-theme-beige'>
      <Header />
      <main className='flex justify-center items-center grow p-10'>
        {children}
      </main>
      <Footer />
    </div>
  );
}
