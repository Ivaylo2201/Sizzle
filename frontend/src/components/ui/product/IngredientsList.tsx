import React from 'react';

type IngredientsList = {
  ingredients: string[];
};

export default function IngredientsList({ ingredients }: IngredientsList) {
  return (
    <ul className='grid grid-cols-2 gap-x-6 gap-y-2 max-w-xl mx-auto text-sm list-disc'>
      {ingredients.map((item, index) => (
        <React.Fragment key={index}>
          <li className='font-semibold'>{item}</li>
        </React.Fragment>
      ))}
    </ul>
  );
}
