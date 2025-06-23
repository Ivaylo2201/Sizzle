import { Accordion } from '@mantine/core';

type DetailsAccordionProps = {
  weight: number;
  calories: number;
};

export default function DetailsAccordion({
  weight,
  calories
}: DetailsAccordionProps) {
  return (
    <Accordion>
      <Accordion.Item value='details'>
        <Accordion.Control>Details</Accordion.Control>
        <Accordion.Panel>
          <ul className='list-[square] list-inside marker:text-theme-pink'>
            <li className='text-sm'>Weight - {weight} gr.</li>
            <li className='text-sm'>Calories - {calories} kCal</li>
          </ul>
        </Accordion.Panel>
      </Accordion.Item>
    </Accordion>
  );
}
