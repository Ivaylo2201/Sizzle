type PageProps = { className?: string } & React.PropsWithChildren;

export default function Page({ children, className }: PageProps) {
  return <main className={`h-screen flex flex-col ${className}`}>{children}</main>;
}
