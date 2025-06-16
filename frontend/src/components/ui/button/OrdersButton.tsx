import { Hamburger } from 'lucide-react';
import { NavLink } from 'react-router';

export default function OrdersButton() {
  return (
    <NavLink
      to='/orders'
      className={({ isActive }) =>
        `shadow-xl transition-colors duration-200 flex justify-center items-center rounded-full p-2 gap-4 cursor-pointer relative font-dmsans ${
          isActive ? 'bg-theme-orange' : 'bg-theme-pink hover:bg-theme-orange'
        }`
      }
    >
      <Hamburger className='text-white' size={19} strokeWidth={1.75} />
    </NavLink>
  );
}
