import Header from '@/components/layout/Header/Header';
import Footer from '@/components/layout/Footer/Footer';

type PageLayoutProps = React.PropsWithChildren & { className?: string };

export default function PageLayout({
  children,
  className = ''
}: PageLayoutProps) {
  return (
    <div className='flex flex-col min-h-screen bg-theme-beige'>
      <Header />
      <main
        className={`flex justify-center items-center grow p-10 ${className}`}
      >
        {children}
      </main>
      <Footer />
    </div>
  );
}
