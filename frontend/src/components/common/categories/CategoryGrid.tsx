import Category from './CategoryLink';

type CategoryGridProps = {
  categories: { imageUrl: string; title: string }[];
};

export default function CategoryGrid({ categories }: CategoryGridProps) {
  return (
    <div className='flex justify-center items-center'>
      <section className='w-5/6 flex flex-wrap justify-center items-center gap-6'>
        {categories.map((category, i) => (
          <Category
            imageUrl={category.imageUrl}
            title={category.title}
            key={i}
          />
        ))}
      </section>
    </div>
  );
}
