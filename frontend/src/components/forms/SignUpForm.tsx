import { SubmitHandler, useForm } from 'react-hook-form';
import { toast } from 'react-toastify';
import { z } from 'zod';
import EmailField from './fields/EmailField';
import PasswordField from './fields/PasswordField';
import Button from '../shared/Button';
import { ClipLoader } from 'react-spinners';
import { schema } from '../../schemas/signUpSchema';
import useSignUp from '../../hooks/useSignUp';
import { Link, useNavigate } from 'react-router-dom';
import BaseForm from './BaseForm';

export default function SignUpForm() {
  const navigate = useNavigate();
  const { mutateAsync } = useSignUp();

  const onSubmit = async (data: any) => {
    await mutateAsync(data, {
      onSuccess: () => navigate('/')
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
          <PasswordField control={control} isConfirming />
        </>
      )}
      footer={
        <p className='font-DMSans text-theme-gray text-bold'>
          Already have an account?&nbsp;
          <Link
            className='text-theme-darkgray font-semibold hover:text-opacity-85 transition-colors duration-200'
            to='/auth/signin'
          >
            Sign in
          </Link>
        </p>
      }
    />
  );
}
