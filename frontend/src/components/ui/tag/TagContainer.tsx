type TagContainerProps = React.PropsWithChildren & {
  className?: string;
};

export default function TagContainer({
  children,
  className = ''
}: TagContainerProps) {
  return (
    <div
      className={`absolute z-50 items-start top-5 left-5 flex flex-col gap-2 ${className}`}
    >
      {children}
    </div>
  );
}
