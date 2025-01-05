import { Link } from 'react-router-dom';
export default function UnauthenticatedButtons() {
  return (
    <section className='h-full flex items-center px-2 gap-6'>
      <Link
        to='signin'
        className='py-2 font-Montserrat text-white rounded-full uppercase'
      >
        Sign in
      </Link>
      <Link
        to='signup'
        className='bg-theme-red hover:bg-theme-lightred transition-colors duration-300 px-6 py-2 font-Montserrat text-white rounded-full uppercase'
      >
        Sign up
      </Link>
    </section>
  );
}
