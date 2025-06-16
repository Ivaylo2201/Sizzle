import { Link } from 'react-router';

export default function Logo() {
  return (
    <Link to='/' className='font-caprasimo font-bold text-3xl uppercase cursor-pointer'>
      <span className='text-theme-pink'>Siz</span>
      <span className='text-theme-orange'>zle</span>
    </Link>
  );
}
