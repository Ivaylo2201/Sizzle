import Header from '@/ui/layouts/Header';

type PageProps = React.PropsWithChildren;

export default function Page({ children }: PageProps) {
  return (
    <div className='bg-theme-lightgreen'>
      <Header />
      <main className='flex justify-center items-center py-10'>{children}</main>
    </div>
  );
}
