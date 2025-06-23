import { Accordion } from '@mantine/core';

type IngredientsAccordionProps = {
  ingredients: string[];
};

export default function IngredientsAccordion({
  ingredients
}: IngredientsAccordionProps) {
  return (
    <Accordion>
      <Accordion.Item value='ingredients'>
        <Accordion.Control>Ingredients</Accordion.Control>
        <Accordion.Panel>
          <ul className='grid grid-cols-2 list-[square] list-inside marker:text-theme-pink'>
            {ingredients.map((ingredient, index) => (
              <li className='text-sm' key={index}>
                {ingredient}
              </li>
            ))}
          </ul>
        </Accordion.Panel>
      </Accordion.Item>
    </Accordion>
  );
}
