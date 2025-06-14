import { NavLink } from 'react-router';

type CategoryLinkProps = React.PropsWithChildren & {
  to: string;
};

export default function CategoryLink({ to, children }: CategoryLinkProps) {
  return (
    <NavLink
      to={`/products${to}`}
      className={({ isActive }) =>
        `px-8 py-2 text-lg rounded-full font-dmsans shadow-md transition-colors duration-150 ${
          isActive ? 'bg-[#036b39] text-white' : 'bg-white text-black'
        }`
      }
    >
      {children}
    </NavLink>
  );
}
