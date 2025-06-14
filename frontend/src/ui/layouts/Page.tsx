import Header from '@/ui/layouts/Header';

type PageLayoutProps = React.PropsWithChildren;

export default function PageLayout({ children }: PageLayoutProps) {
  return (
    <div className='bg-theme-lightgreen'>
      <Header />
      <main className='flex justify-center items-center py-10'>{children}</main>
    </div>
  );
}
