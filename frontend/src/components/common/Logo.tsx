import { NavigateFunction, useNavigate } from 'react-router-dom';
import logoImg from '../../assets/logo.png';

type LogoProps = {
  size: number;
  redirectUrl?: string;
  scalable?: boolean;
};

export default function Logo({ size, redirectUrl, scalable }: LogoProps) {
  const navigate: NavigateFunction = useNavigate();

  return (
    <img
      src={logoImg}
      onClick={redirectUrl ? () => navigate(redirectUrl) : undefined}
      alt='Sizzle logo'
      className={`object-contain ${
        scalable ? 'hover:scale-105 transition-all duration-300' : ''
      } mb-2 ${redirectUrl ? 'cursor-pointer' : ''} `}
      style={{ width: `${size}rem`, height: `${size}rem` }}
    />
  );
}
