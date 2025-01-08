import { Control, FieldValues, SubmitHandler, useForm } from 'react-hook-form';
import { toast } from 'react-toastify';
import { ZodSchema } from 'zod';
import Button from '../shared/Button';
import { ClipLoader } from 'react-spinners';

type BaseFormProps<T extends FieldValues> = {
  schema: ZodSchema<T>;
  onSubmit: SubmitHandler<T>;
  title: string;
  footer: React.ReactNode;
  renderFields: (control: Control<T>) => React.ReactNode;
};

export default function BaseForm<T extends FieldValues>({
  schema,
  onSubmit,
  title,
  renderFields,
  footer
}: BaseFormProps<T>) {
  const {
    handleSubmit,
    control,
    formState: { isSubmitting }
  } = useForm<T>();

  const handleFormSubmit: SubmitHandler<T> = async (data) => {
    const result = schema.safeParse(data);

    if (!result.success) {
      toast.error(result.error.issues[0].message);
      return;
    }

    await onSubmit(data);
  };

  return (
    <div className='flex flex-col gap-9 items-center font-DMSans'>
      <p className='text-4xl text-theme-darkgray font-bold'>{title}</p>

      <section className='flex flex-col gap-3 justify-center'>
        {renderFields(control)}
      </section>

      <section className='flex flex-col items-center gap-5'>
        {footer}

        <Button
          onClick={handleSubmit(handleFormSubmit)}
          colors={{
            bg: 'bg-theme-darkgray',
            text: 'text-white'
          }}
        >
          {isSubmitting ? (
            <ClipLoader size={20} color='text-white' />
          ) : (
            'Sign in'
          )}
        </Button>
      </section>
    </div>
  );
}
