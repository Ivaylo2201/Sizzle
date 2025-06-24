import ItemCard from '@/components/ui/item/ItemCard';
import type { Item } from '@/utils/types/models/Item';

type ItemListProps = {
  items: Item[];
};

export default function ItemList({ items }: ItemListProps) {
  return (
    <div className='flex flex-col gap-4.5'>
      {items.map((item, i) => (
        <ItemCard {...item} key={i} />
      ))}
    </div>
  );
}
