import { Link } from 'react-router-dom';

type AuthLinkProps = {
  text: string;
  button: {
    href: string;
    text: string;
  };
};

export default function AuthLink({ text, button }: AuthLinkProps) {
  return (
    <section className='my-4'>
      <p className='font-DMSans text-theme-gray text-bold'>
        {text}&nbsp;
        <Link
          className='text-theme-darkgray font-semibold hover:text-opacity-85 transition-colors duration-200'
          to={button.href}
        >
          {button.text}
        </Link>
      </p>
    </section>
  );
}
