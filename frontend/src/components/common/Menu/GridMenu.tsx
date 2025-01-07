import TMenu from '../../../types/menu';
import Category from './Category';

export default function GridMenu({ categories }: TMenu) {
  return (
    <div className='flex justify-center items-center'>
      <section className='w-5/6 flex flex-wrap justify-center items-center gap-6'>
        {categories.map((category, i) => (
          <Category
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
