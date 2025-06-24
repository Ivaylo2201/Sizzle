import type { z } from 'zod';
import { Link } from 'react-router';
import { useForm } from 'react-hook-form';
import { toast } from 'react-toastify';
import { Loader } from '@mantine/core';
import { UserRound, KeyRound, Phone } from 'lucide-react';

import Button from '@/components/shared/Button';
import useSignUp from '@/lib/hooks/useSignUp';
import { signUpSchema } from '@/lib/schemas/signUpSchema';
import PrivacyPolicyAndTermsOfService from '@/components/shared/PrivacyPolicyAndTermsOfService';
import SizzlePasswordInput from '@/components/shared/SizzlePasswordInput';
import SizzleTextInput from '@/components/shared/SizzleTextInput';
import SizzleCheckbox from '@/components/shared/SizzleCheckbox';

type SignUpSchema = z.infer<typeof signUpSchema>;

export default function SignUpForm() {
  const { register, handleSubmit } = useForm<SignUpSchema>();
  const { mutate, isPending } = useSignUp();

  const onSubmit = (data: SignUpSchema) => {
    const result = signUpSchema.safeParse(data);

    if (!result.success) {
      toast.error(result.error?.errors[0].message || 'Something went wrong.');
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
        Sign up to get started
      </h1>

      <div className='gap-3 flex flex-col'>
        <SizzleTextInput
          label='Username'
          leftSectionPointerEvents='none'
          leftSection={<UserRound size={18} />}
          {...register('username')}
        />

        <SizzleTextInput
          label='Phone number'
          leftSectionPointerEvents='none'
          leftSection={<Phone size={18} />}
          {...register('phoneNumber')}
        />

        <SizzlePasswordInput
          label='Password'
          leftSectionPointerEvents='none'
          leftSection={<KeyRound size={18} />}
          {...register('password')}
        />

        <SizzlePasswordInput
          label='Confirm password'
          leftSectionPointerEvents='none'
          leftSection={<KeyRound size={18} />}
          {...register('passwordConfirmation')}
        />
      </div>

      <SizzleCheckbox
        defaultChecked={false}
        label='Remember me'
        {...register('rememberMe')}
      />

      <Button className='h-10 flex justify-center items-center'>
        {isPending ? (
          <Loader size={15} style={{ '--loader-color': 'white' }} />
        ) : (
          'Sign up'
        )}
      </Button>

      <Link
        to='/auth/sign-in'
        className='text-center text-theme-pink font-rubik text-sm transition-colors duration-200 hover:text-theme-orange'
      >
        Already have an account?
      </Link>

      <PrivacyPolicyAndTermsOfService />
    </form>
  );
}
