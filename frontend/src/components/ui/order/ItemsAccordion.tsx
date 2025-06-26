import type { Item } from '@/utils/types/models/Item';
import { Accordion } from '@mantine/core';

type ItemsAccordionProps = {
  items: Item[];
};

export default function ItemsAccordion({ items }: ItemsAccordionProps) {
  return (
    <Accordion>
      <Accordion.Item value='items'>
        <Accordion.Control>Items</Accordion.Control>
        <Accordion.Panel>
          <section>
            <ul className='grid grid-cols-2 list-[square] list-inside marker:text-theme-pink'>
              {items.map((item, index) => (
                <li className='text-sm' key={index}>
                  {item.productName} - ${item.price.toFixed(2)}
                </li>
              ))}
            </ul>
          </section>
        </Accordion.Panel>
      </Accordion.Item>
    </Accordion>
  );
}
