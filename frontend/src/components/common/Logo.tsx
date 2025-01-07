import { useNavigate } from 'react-router-dom';
import LogoBurger from '../../icons/LogoBurger';

type LogoProps = {
  size: number;
  color?: 'black' | 'white';
  redirectUrl?: string;
  className?: string;
};

export default function Logo({
  size,
  color = 'black',
  redirectUrl,
  className = ''
}: LogoProps) {
  const navigate = useNavigate();

  return (
    <span
      className={`inline-flex justify-center items-center ${className} ${
        redirectUrl ? 'cursor-pointer' : ''
      }`}
      onClick={redirectUrl ? () => navigate(redirectUrl) : undefined}
    >
      <LogoBurger
        color={color === 'black' ? '#000000' : '#ffffff'}
        size={size}
      />
    </span>
  );
}
