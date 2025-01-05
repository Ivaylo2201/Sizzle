type PageProps = { className?: string } & React.PropsWithChildren;

export default function Page({ children, className }: PageProps) {
  return (
    <div className={`h-screen flex flex-col ${className}`}>{children}</div>
  );
}
