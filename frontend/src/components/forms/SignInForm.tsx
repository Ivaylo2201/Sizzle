import { schema } from '../../schemas/signInSchema';
import useSignIn from '../../hooks/useSignIn';
import EmailField from './fields/EmailField';
import PasswordField from './fields/PasswordField';
import { Link, useNavigate } from 'react-router-dom';
import BaseForm from './BaseForm';

export default function SignInForm() {
  const navigate = useNavigate();
  const { mutateAsync } = useSignIn();

  const onSubmit = async (data: any) => {
    await mutateAsync(data, {
      onSuccess: (res) => {
        localStorage.setItem('token', res.access);
        localStorage.setItem('refresh', res.refresh);
        navigate('/')
      }
    });
  };

  return (
    <BaseForm
      schema={schema}
      onSubmit={onSubmit}
      title='Sign in'
      renderFields={(control) => (
        <>
          <EmailField control={control} />
          <PasswordField control={control} />
          <Link
            className='text-theme-gray hover:text-theme-darkgray text-sm transition-colors duration-150'
            to='/auth/reset'
          >
            Forgot password?
          </Link>
        </>
      )}
      footer={
        <p className='text-theme-gray text-bold'>
          Not registered yet?&nbsp;
          <Link
            className='text-theme-darkgray font-semibold hover:text-opacity-85 transition-colors duration-200'
            to='/auth/signup'
          >
            Sign up
          </Link>
        </p>
      }
    />
  );
}
