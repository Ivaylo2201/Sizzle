import HeaderLink from './HeaderLink';

export default function UnauthenticatedButtons() {
  return (
    <>
      <HeaderLink to='/auth/signin'>Sign in</HeaderLink>
      <HeaderLink to='/auth/signup'>Sign up</HeaderLink>
    </>
  );
}
