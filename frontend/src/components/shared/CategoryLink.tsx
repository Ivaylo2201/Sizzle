import { NavLink } from 'react-router';

type CategoryLinkProps = React.PropsWithChildren & {
  to: string;
};

export default function CategoryLink({ to, children }: CategoryLinkProps) {
  return (
    <NavLink
      to={`/products${to}`}
      className={({ isActive }) =>
        `font-rubik font-bold text-xl transition-colors duration-150 ${
          isActive ? 'text-theme-orange' : 'text-theme-pink hover:text-theme-orange'
        }`
      }
    >
      {children}
    </NavLink>
  );
}
