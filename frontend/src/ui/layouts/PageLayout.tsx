type PageLayoutProps = React.PropsWithChildren;

export default function PageLayout({ children }: PageLayoutProps) {
  return (
    <div>
      <main className="flex justify-center items-center py-10">{children}</main>
    </div>
  );
}
