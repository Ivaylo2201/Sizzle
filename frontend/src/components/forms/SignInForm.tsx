import EmailField from './fields/EmailField';
import PasswordField from './fields/PasswordField';
import Button from '../shared/Button';
import { SubmitHandler, useForm } from 'react-hook-form';
import { toast } from 'react-toastify';
import { z } from 'zod';
import { Link, useNavigate } from 'react-router-dom';
import { ClipLoader } from 'react-spinners';
import { schema } from '../../schemas/signInSchema';
import useSignIn from '../../hooks/useSignIn';

type SignInFormData = z.infer<typeof schema>;

export default function SignInForm() {
  const {
    handleSubmit,
    control,
    formState: { isSubmitting }
  } = useForm<SignInFormData>();

  const navigate = useNavigate();
  const { mutateAsync } = useSignIn();

  const onSubmit: SubmitHandler<SignInFormData> = async (data) => {
    const result = schema.safeParse(data);

    if (!result.success) {
      toast.error(result.error.issues[0].message);
      return;
    }

    await mutateAsync(data, {
      onSuccess: () => navigate('/')
    });
  };

  return (
    <div className='flex flex-col gap-9 items-center font-DMSans'>
      <p className='text-4xl text-theme-darkgray font-bold'>
        Sign in
      </p>

      <section className='flex flex-col gap-3 justify-center'>
        <EmailField control={control} />
        <PasswordField control={control} />

        <Link
          className='text-theme-gray hover:text-theme-darkgray text-sm transition-colors duration-150'
          to='/auth/reset'
        >
          Forgot password?
        </Link>
      </section>

      <section className='flex flex-col items-center gap-5'>
        <p className=' text-theme-gray text-bold'>
          Not registered yet?&nbsp;
          <Link
            className='text-theme-darkgray font-semibold hover:text-opacity-85 transition-colors duration-200'
            to='/auth/signup'
          >
            Sign up
          </Link>
        </p>

        <Button
          onClick={handleSubmit(onSubmit)}
          colors={{
            bg: 'bg-theme-darkgray',
            text: 'text-white'
          }}
        >
          {isSubmitting ? (
            <ClipLoader size={20} color='text-white' />
          ) : (
            'Sign in'
          )}
        </Button>
      </section>
    </div>
  );
}
