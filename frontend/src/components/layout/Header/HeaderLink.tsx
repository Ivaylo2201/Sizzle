import { Link } from 'react-router-dom';

type HeaderLinkProps = {
  to: string;
  onClick?: () => void;
  className?: string;
} & React.PropsWithChildren;

export default function HeaderLink({
  to,
  onClick,
  className,
  children
}: HeaderLinkProps) {
  return (
    <Link
      to={to}
      onClick={onClick}
      className={`py-2 px-3 font-DMSans text-white hover:opacity-75 transition-opacity duration-200 uppercase ${className}`}
    >
      {children}
    </Link>
  );
}
