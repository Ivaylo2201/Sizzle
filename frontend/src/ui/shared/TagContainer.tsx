type TagContainerProps = React.PropsWithChildren & {
  className?: string;
};

export default function TagContainer({
  children,
  className = ''
}: TagContainerProps) {
  return (
    <div
      className={`absolute items-start top-5 left-5 flex flex-col gap-1.5 ${className}`}
    >
      {children}
    </div>
  );
}
