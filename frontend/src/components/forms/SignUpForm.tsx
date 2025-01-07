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

type SignUpFormData = z.infer<typeof schema>;

export default function SignUpForm() {
  const {
    handleSubmit,
    control,
    formState: { isSubmitting }
  } = useForm<SignUpFormData>();

  const navigate = useNavigate();
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
    <div className='flex flex-col gap-9 items-center font-DMSans'>
      <p className='text-4xl text-theme-darkgray font-bold'>Sign up</p>

      <section className='flex flex-col gap-3 '>
        <EmailField control={control} />
        <PasswordField control={control} />
        <PasswordField control={control} isConfirming />
      </section>

      <section className='flex flex-col items-center gap-5'>
        <p className='font-DMSans text-theme-gray text-bold'>
          Already have an account?&nbsp;
          <Link
            className='text-theme-darkgray font-semibold hover:text-opacity-85 transition-colors duration-200'
            to='/auth/signin'
          >
            Sign in
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
            'Sign up'
          )}
        </Button>
      </section>
    </div>
  );
}
