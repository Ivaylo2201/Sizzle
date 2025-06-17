import type z from 'zod';
import { Link } from 'react-router';
import { useForm } from 'react-hook-form';
import { Checkbox, Loader, PasswordInput, TextInput } from '@mantine/core';
import { UserRound, KeyRound } from 'lucide-react';
import { toast } from 'react-toastify';

import Button from '@/components/ui/button/Button';
import useSignIn from '@/lib/hooks/useSignIn';
import { signInSchema } from '@/lib/schemas/signInSchema';
import PrivacyPolicyAndTermsOfService from '@/components/shared/PrivacyPolicyAndTermsOfService';

type SignInSchema = z.infer<typeof signInSchema>;

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
        <TextInput
          size='md'
          variant='filled'
          label='Username'
          leftSectionPointerEvents='none'
          leftSection={<UserRound size={18} />}
          styles={{
            input: {
              color: '#737374',
              backgroundColor: 'var(--color-gray-200)',
              fontFamily: 'Rubik, sans-serif'
            }
          }}
          {...register('username')}
        />

        <PasswordInput
          size='md'
          variant='filled'
          label='Password'
          leftSectionPointerEvents='none'
          leftSection={<KeyRound size={18} />}
          styles={{
            input: {
              color: '#737374',
              backgroundColor: 'var(--color-gray-200)',
              fontFamily: 'Rubik, sans-serif'
            }
          }}
          {...register('password')}
        />
      </div>

      <Checkbox
        defaultChecked={false}
        label='Remember me'
        color='var(--color-theme-pink)'
        styles={{
          label: {
            fontFamily: 'Rubik, sans-serif'
          }
        }}
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
