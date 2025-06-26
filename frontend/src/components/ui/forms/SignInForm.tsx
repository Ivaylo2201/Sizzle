import { Link } from 'react-router';
import { useForm } from 'react-hook-form';
import { Loader } from '@mantine/core';
import { UserRound } from 'lucide-react';
import { toast } from 'react-toastify';

import Button from '@/components/shared/Button';
import useSignIn from '@/lib/hooks/useSignIn';
import { signInSchema, type SignInSchema } from '@/lib/schemas/signInSchema';
import PrivacyPolicyAndTermsOfService from '@/components/shared/PrivacyPolicyAndTermsOfService';
import SizzleCheckbox from '@/components/shared/SizzleCheckbox';
import SizzleTextInput from '@/components/shared/SizzleTextInput';
import SizzlePasswordInput from '@/components/shared/SizzlePasswordInput';


export default function SignInForm() {
  const { register, handleSubmit } = useForm<SignInSchema>();
  const { mutate, isPending } = useSignIn();

  const onSubmit = (data: SignInSchema) => {
    const result = signInSchema.safeParse(data);

    if (!result.success) {
      toast.error(result.error?.errors[0].message);
      return;
    }

    mutate(data);
  };

  return (
    <form
      onSubmit={handleSubmit(onSubmit)}
      className='w-[27.5rem] bg-white rounded-xl px-15 py-15 shadow-md flex flex-col gap-6'
    >
      <h1 className='font-dmsans text-2xl font-bold text-center'>
        Sign in to your account
      </h1>

      <div className='gap-3 flex flex-col'>
        <SizzleTextInput
          label='Username'
          leftSectionPointerEvents='none'
          leftSection={<UserRound size={18} />}
          {...register('username')}
        />

        <SizzlePasswordInput
          label='Password'
          {...register('password')}
        />
      </div>

      <SizzleCheckbox
        label='Remember me'
        {...register('rememberMe')}
      />

      <Button className='h-10 flex justify-center items-center'>
        {isPending ? (
          <Loader size={15} style={{ '--loader-color': 'white' }} />
        ) : (
          'Sign in'
        )}
      </Button>

      <Link
        to='/auth/sign-up'
        className='text-center text-theme-pink font-rubik text-sm transition-colors duration-200 hover:text-theme-orange'
      >
        Do not have an account yet?
      </Link>

      <PrivacyPolicyAndTermsOfService />
    </form>
  );
}
