import type { z } from 'zod';
import { Link } from 'react-router';
import { useForm } from 'react-hook-form';
import { toast } from 'react-toastify';
import { Checkbox, Loader, PasswordInput, TextInput } from '@mantine/core';
import { UserRound, KeyRound, Phone } from 'lucide-react';

import Button from '@/components/shared/Button';
import useSignUp from '@/lib/hooks/useSignUp';
import { signUpSchema } from '@/lib/schemas/signUpSchema';
import PrivacyPolicyAndTermsOfService from '@/components/shared/PrivacyPolicyAndTermsOfService';

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

        <TextInput
          size='md'
          variant='filled'
          label='Phone number'
          leftSectionPointerEvents='none'
          leftSection={<Phone size={18} />}
          styles={{
            input: {
              color: '#737374',
              backgroundColor: 'var(--color-gray-200)',
              fontFamily: 'Rubik, sans-serif'
            }
          }}
          {...register('phoneNumber')}
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

        <PasswordInput
          size='md'
          variant='filled'
          label='Confirm password'
          leftSectionPointerEvents='none'
          leftSection={<KeyRound size={18} />}
          styles={{
            input: {
              color: '#737374',
              backgroundColor: 'var(--color-gray-200)',
              fontFamily: 'Rubik, sans-serif'
            }
          }}
          {...register('passwordConfirmation')}
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
