import { SubmitHandler, useForm } from 'react-hook-form';
import { toast } from 'react-toastify';
import { z } from 'zod';
import EmailField from './fields/EmailField';
import PasswordField from './fields/PasswordField';
import AuthLink from '../generics/AuthLink';
import Button from '../generics/Button';
import { ClipLoader } from 'react-spinners';
import { schema } from '../../schemas/signUpFormData';
import useSignUp from '../../hooks/useSignUp';
import { NavigateFunction, useNavigate } from 'react-router-dom';

type SignUpFormData = z.infer<typeof schema>;

export default function SignUpForm() {
  const {
    handleSubmit,
    control,
    formState: { isSubmitting }
  } = useForm<SignUpFormData>();

  const navigate: NavigateFunction = useNavigate();
  const { mutateAsync } = useSignUp();

  const onSubmit: SubmitHandler<SignUpFormData> = async (data) => {
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
    <div className='flex flex-col gap-9 items-center'>
      <p className='text-4xl font-DMSans text-theme-darkgray font-bold'>
        Sign up
      </p>

      <section className='flex flex-col gap-3 '>
        <EmailField control={control} />
        <PasswordField control={control} />
        <PasswordField control={control} confirming />
      </section>

      <section className='flex flex-col items-center gap-1.5'>
        <AuthLink
          text={'Already have an account?'}
          button={{
            href: '/auth/signin',
            text: 'Sign in'
          }}
        />

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
            'Sign up'
          )}
        </Button>
      </section>
    </div>
  );
}
