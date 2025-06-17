import type { Item } from '@/utils/types/models/Item';
import ItemCard from '@/components/ui/item/ItemCard';

type ItemListProps = {
  items: Item[];
};

export default function ItemList({ items }: ItemListProps) {
  return (
    <div className='flex flex-col gap-6'>
      {items.map((item, i) => (
        <ItemCard {...item} key={i} />
      ))}
    </div>
  );
}
