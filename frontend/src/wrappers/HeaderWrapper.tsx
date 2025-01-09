import useAuthStore from '../stores/authStore';
import Header from '../components/layout/Header/Header';

type HeaderWrapperProps = {
  hasPadding?: boolean;
  className?: string;
} & React.PropsWithChildren;

export default function HeaderWrapper({
  hasPadding = true,
  className,
  children
}: HeaderWrapperProps) {
  const { isAuthenticated } = useAuthStore();

  return (
    <div className='h-screen flex flex-col'>
      <Header isAuthenticated={isAuthenticated} />
      <main
        className={`${
          hasPadding ? 'p-4' : ''
        } ${className} flex-grow `}
      >
        {children}
      </main>
    </div>
  );
}
