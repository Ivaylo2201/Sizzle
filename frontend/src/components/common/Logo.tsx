import { NavigateFunction, useNavigate } from 'react-router-dom';
import logoBurger from '../../assets/common/logo-burger.png';
import LogoBurger from '../../icons/LogoBurger';

type LogoProps = {
  size: number;
  iconColor?: 'black' | 'white';
  redirectable?: {
    url: string;
  };
  vertical?: boolean;
  className?: string;
};

export default function Logo({
  size,
  iconColor = 'black',
  redirectable,
  vertical,
  className = ''
}: LogoProps) {
  const navigate: NavigateFunction = useNavigate();

  return (
    <div
      className={` flex justify-center items-center ${className} ${
        vertical ? 'flex-col gap-1' : 'gap-3'
      } ${redirectable && 'cursor-pointer'}`}
      onClick={redirectable ? () => navigate(redirectable.url) : undefined}
    >
      <LogoBurger
        color={iconColor === 'black' ? '#000000' : '#ffffff'}
        size={size}
      />

      <p
        style={{ fontSize: `${size * 0.8}rem` }}
        className='font-Montserrat text-red-500 font-extrabold uppercase tracking-widest'
      >
        Sizzle
      </p>
    </div>
  );
}
