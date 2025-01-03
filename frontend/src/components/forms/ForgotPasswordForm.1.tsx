import { useForm, SubmitHandler } from 'react-hook-form';
import { toast } from 'react-toastify';

import logo from "../../assets/logo.png";
import EmailField from './fields/EmailField';
import Button from '../generics/Button';
import { ClipLoader } from 'react-spinners';
import { Link } from 'react-router-dom';
import { z } from 'zod';
import Logo from '../common/Logo';

const schema = z.object({
  email: z
    .string({ required_error: 'Email is required' })
    .email({ message: 'Email is invalid!' })
});

type ForgotPasswordFormData = z.infer<typeof schema>;

async function sendEmail() {
  return await new Promise<string>((resolve, reject) =>
    setTimeout(() => resolve('Check your email!'), 1000)
  );
}

export default function ForgotPasswordForm() {
  const {
    handleSubmit,
    control,
    formState: { isSubmitting }
  } = useForm<ForgotPasswordFormData>();

  const onSubmit: SubmitHandler<ForgotPasswordFormData> = async (data) => {
    const result = schema.safeParse(data);

    if (!result.success) {
      toast.error(result.error.issues[0].message);
      return;
    }

    console.log(data);

    try {
      const res: string = await sendEmail();
      toast.success(res);
    } catch (error) {
      toast.error((error as Error).message);
    }
  };

  return (
    <div className='flex flex-col gap-4 items-center'>
      <Logo size={8} />

      <EmailField control={control} />

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
          'Send email'
        )}
      </Button>

      <Link
        className='text-theme-gray hover:text-theme-darkgray font-DMSans text-sm transition-colors duration-150'
        to='/signin'
      >
        Back to sign in
      </Link>
    </div>
  );
}
