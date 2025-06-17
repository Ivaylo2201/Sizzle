type HeaderSectionProps = React.HTMLAttributes<HTMLElement>;

export default function HeaderSection({
  children,
  className = '',
  ...props
}: HeaderSectionProps) {
  return (
    <section
      className={`w-1/3 flex justify-center items-center ${className}`}
      {...props}
    >
      {children}
    </section>
  );
}
