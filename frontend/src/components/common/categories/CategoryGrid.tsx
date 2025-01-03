import { Category } from '../../../types/Category';
import CategoryLink from './CategoryLink';

type CategoryGridProps = {
  categories: Category[];
};

export default function CategoryGrid({ categories }: CategoryGridProps) {
  return (
    <div className='flex justify-center items-center'>
      <section className='w-5/6 flex flex-wrap justify-center items-center gap-6'>
        {categories.map((category, i) => (
          <CategoryLink
            imageUrl={category.imageUrl}
            title={category.title}
            key={i}
            className='w-96'
          />
        ))}
      </section>
    </div>
  );
}
