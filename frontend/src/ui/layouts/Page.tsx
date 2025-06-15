import Header from '@/ui/layouts/Header';

type PageProps = React.PropsWithChildren;

export default function Page({ children }: PageProps) {
  return (
    <div className='flex flex-col min-h-screen bg-theme-beige'>
      <Header />
      <main className='flex justify-center items-center grow p-10'>{children}</main>
    </div>
  );
}
