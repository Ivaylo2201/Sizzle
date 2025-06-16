type TagProps = {
  content: string | React.ReactNode;
  className?: string;
};

export default function Tag({ content, className = '' }: TagProps) {
  return (
    <span
      className={`px-3 py-1 font-bold text-white font-dmsans rounded-xl text-center ${className}`}
    >
      {content}
    </span>
  );
}
