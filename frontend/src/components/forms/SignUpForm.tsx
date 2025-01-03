import { SubmitHandler, useForm } from "react-hook-form";
import { toast } from "react-toastify";
import { z } from "zod";
import EmailField from "./fields/EmailField";
import PasswordField from "./fields/PasswordField";
import AuthLink from "../generics/AuthLink";
import Button from "../generics/Button";
import { ClipLoader } from "react-spinners";
import Logo from "../common/Logo";


const schema = z
  .object({
    email: z
      .string({ required_error: 'Email is required' })
      .email({ message: 'Email is invalid!' }),
    password: z
      .string({ required_error: 'Password is required' })
      .min(2, 'Password must be at least 8 characters long'),
    passwordConfirmation: z.string({
      required_error: 'Confirmation is required'
    })
  })
  .refine((data) => data.password === data.passwordConfirmation, {
    message: 'Passwords do not match!',
    path: ['passwordConfirmation']
  });

type SignUpFormData = z.infer<typeof schema>;

// function useSignUpUser() {
//   return useMutation({
//     mutationFn: async (data: SignUpFormData) => {
//       return await new Promise((resolve, reject) =>
//         setTimeout(() => resolve({ email: ['Email already in use!'] }), 1000)
//       );
//     }
//   });
// }

export default function SignUpForm() {
  const {
    handleSubmit,
    control,
    formState: { isSubmitting }
  } = useForm<SignUpFormData>();
  // const { mutateAsync } = useSignUpUser();

  const onSubmit: SubmitHandler<SignUpFormData> = async (data) => {
    const result = schema.safeParse(data);

    if (!result.success) {
      toast.error(result.error.issues[0].message);
      return;
    }

    console.log(data);

    // await mutateAsync(data, {
    //   onSuccess: () => toast.success('Successfully signed up!'),
    //   onError: (error: any) => {
    //     toast.error(error.email[0]);
    //   }
    // });
  };

  return (
    <div className='flex flex-col gap-4 items-center'>
      <Logo size={8} scalable />

      <section className='flex flex-col gap-3 '>
        <EmailField control={control} />
        <PasswordField control={control} />
        <PasswordField control={control} confirming />
      </section>

      <AuthLink
        text={'Already have an account?'}
        button={{
          href: '/signin',
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
        {isSubmitting ? <ClipLoader size={20} color='text-white' /> : 'Sign up'}
      </Button>
    </div>
  );
}
