import { Accordion } from '@mantine/core';

type DeliveryAccordionProps = {
  cityName: string;
  streetName: string;
  streetNumber: number;
  notes: string | null;
};

export default function DeliveryAccordion({
  cityName,
  streetName,
  streetNumber,
  notes
}: DeliveryAccordionProps) {
  return (
    <Accordion>
      <Accordion.Item value='Delivery'>
        <Accordion.Control>Delivery</Accordion.Control>
        <Accordion.Panel>
          <ul className='flex flex-col gap-2 list-[square] list-inside marker:text-theme-pink text-sm'>
            <li>
              <span>Address:</span>
              <p className='text-theme-gray italic'>{`${cityName}, ${streetNumber} ${streetName}`}</p>
            </li>
            <li>
              <span>Notes:</span>
              <p className='text-theme-gray italic'>
                {notes ?? 'No additional information provided.'}
              </p>
            </li>
          </ul>
        </Accordion.Panel>
      </Accordion.Item>
    </Accordion>
  );
}
