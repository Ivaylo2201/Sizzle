import { Link } from 'react-router';
import { useForm } from 'react-hook-form';
import { PasswordInput, TextInput } from '@mantine/core';
import { UserRound, KeyRound } from 'lucide-react';

import Button from '@/components/ui/button/Button';
import useSignIn from '@/lib/hooks/useSignIn';
import type { SignInRequest } from '@/utils/types/requests/SignInRequest';

export default function SignInForm() {
  const { register, handleSubmit } = useForm<SignInRequest>();
  const { mutate } = useSignIn();

  return (
    <form
      onSubmit={handleSubmit((data) => mutate(data))}
      className='min-w-[25rem] bg-white rounded-xl px-15 py-15 shadow-md flex flex-col  gap-8'
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
              backgroundColor: 'var(--color-gray-200)'
            }
          }}
          {...register('password')}
        />
      </div>
      <Button>Sign in</Button>
      <Link
        to='/auth/sign-up'
        className='text-center text-theme-pink font-rubik text-sm transition-colors duration-200 hover:text-theme-orange'
      >
        Do not have an account yet?
      </Link>
    </form>
  );
}
