import { useForm, SubmitHandler } from 'react-hook-form';
import { toast } from 'react-toastify';

import EmailField from './fields/EmailField';
import Button from '../shared/Button';
import { ClipLoader } from 'react-spinners';
import { Link } from 'react-router-dom';
import { z } from 'zod';
import { schema } from '../../schemas/resetPasswordSchema';

type ResetPasswordFormData = z.infer<typeof schema>;

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
  } = useForm<ResetPasswordFormData>();

  const onSubmit: SubmitHandler<ResetPasswordFormData> = async (data) => {
    const result = schema.safeParse(data);

    if (!result.success) {
      toast.error(result.error.issues[0].message);
      return;
    }
  };

  return (
    <div className='flex flex-col gap-9 items-center'>
      <p className='text-4xl font-DMSans text-theme-darkgray font-bold text-center'>
        Reset your password
      </p>

      <EmailField control={control} />

      <section className='flex flex-col items-center gap-4'>
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
          to='/auth/signin'
        >
          Back to sign in
        </Link>
      </section>
    </div>
  );
}
