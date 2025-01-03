import EmailField from './fields/EmailField';
import PasswordField from './fields/PasswordField';
import Button from '../generics/Button';
import AuthLink from '../generics/AuthLink';
import { SubmitHandler, useForm } from 'react-hook-form';
import { toast } from 'react-toastify';
import { z } from 'zod';
import { Link, useNavigate } from 'react-router-dom';
import { ClipLoader } from 'react-spinners';
import Logo from '../common/Logo';

const signInFormDataSchema = z.object({
  email: z
    .string({ required_error: 'Email is required' })
    .email({ message: 'Invalid email' }),
  password: z
    .string({ required_error: 'Password is required' })
    .min(5, 'Password length must be greater than 5 characters')
});

type SignInFormData = z.infer<typeof signInFormDataSchema>;

// function useSignInUser() {
//   return useMutation({
//     mutationFn: async (data: SignInFormData) => {
//       return await new Promise((_, resolve) => setTimeout(resolve, 1000));
//     }
//   });
// }

export default function SignInForm() {
  const {
    handleSubmit,
    control,
    formState: { isSubmitting }
  } = useForm<SignInFormData>();

  const navigate = useNavigate();
  // const { mutateAsync } = useSignInUser();

  const onSubmit: SubmitHandler<SignInFormData> = async (data) => {
    const result = signInFormDataSchema.safeParse(data);

    if (!result.success) {
      toast.error(result.error.issues[0].message);
      return;
    }

    console.log(data);

    await new Promise((resolve, _) => setTimeout(resolve, 1000))
    navigate('/');

    // await mutateAsync(data, {
    //   onSuccess: () => toast.success('Successfully signed in!'),
    //   onError: () => toast.error('Failed to sign in!')
    // });
  };

  return (
    <div className='flex flex-col gap-4 items-center'>
      <Logo size={8} scalable />

      <section className='flex flex-col gap-3 justify-center'>
        <EmailField control={control} />
        <PasswordField control={control} />
        <Link
          className='text-theme-gray hover:text-theme-darkgray font-DMSans text-sm transition-colors duration-150'
          to='/forgot-password'
        >
          Forgot password?
        </Link>
      </section>

      <AuthLink
        text={'Not registered yet?'}
        button={{
          href: '/signup',
          text: 'Sign up'
        }}
      />

      <Button
        onClick={handleSubmit(onSubmit)}
        colors={{
          bg: 'bg-theme-darkgray',
          text: 'text-white'
        }}
      >
        {isSubmitting ? <ClipLoader size={20} color='text-white' /> : 'Sign in'}
      </Button>
    </div>
  );
}
