import Navlink from './Navlink';
export default function UnauthenticatedButtons() {
  return (
    <>
      <Navlink to='/auth/signin'>Sign in</Navlink>
      <Navlink to='/auth/signup'>Sign up</Navlink>
    </>
  );
}
