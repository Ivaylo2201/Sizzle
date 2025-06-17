type SectionProps = React.HTMLAttributes<HTMLElement>;

export default function Section({
  children,
  className = '',
  ...props
}: SectionProps) {
  return (
    <section
      className={`md:w-1/3 flex justify-center items-center ${className}`}
      {...props}
    >
      {children}
    </section>
  );
}
