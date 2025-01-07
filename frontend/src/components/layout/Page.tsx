type PageProps = React.PropsWithChildren;

export default function Page({ children }: PageProps) {
  return (
    <div className='h-screen flex flex-col justify-center items-center'>
      {children}
    </div>
  );
}
