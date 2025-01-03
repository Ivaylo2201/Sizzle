import { useEffect, useState } from 'react';

import categorySalad from '../../../assets/categories/categorySalads.jpg'
import categoryPizza from '../../../assets/categories/categoryPasta.jpg'
import categorySushi from '../../../assets/categories/categorySushi.jpg'
import categoryGrill from '../../../assets/categories/categoryGrill.jpg'
import categoryBurger from '../../../assets/categories/categoryBurgers.jpg'
import categoryPasta from '../../../assets/categories/categoryPasta.jpg'
import categoryDesserts from '../../../assets/categories/categoryDesserts.jpg'
import categoryDrinks from '../../../assets/categories/categoryDrinks.jpg'

import CategoryCarousel from './CategoryCarousel';
import CategoryGrid from './CategoryGrid';

export default function CategoryList() {
  const [isVertical, setIsVertical] = useState<boolean | null>(null);

  useEffect(() => {
    const handleResize = (): void => setIsVertical(window.innerWidth < 1400);

    handleResize(); // Calculate initial orientation

    window.addEventListener('resize', handleResize); // Call the function on each window resize

    // Cleanup function - remove listener, called when the components unmounts
    return () => window.removeEventListener('resize', handleResize);
  }, []);

  const categories: { imageUrl: string; title: string }[] = [
    { imageUrl: categorySalad, title: 'salads' },
    { imageUrl: categoryPizza, title: 'pizzas' },
    { imageUrl: categorySushi, title: 'sushi' },
    { imageUrl: categoryGrill, title: 'grill' },
    { imageUrl: categoryBurger, title: 'burgers' },
    { imageUrl: categoryPasta, title: 'pasta' },
    { imageUrl: categoryDesserts, title: 'desserts' },
    { imageUrl: categoryDrinks, title: 'drinks' }
  ];

  return isVertical ? (
    <CategoryGrid categories={categories} />
  ) : (
    <CategoryCarousel categories={categories} />
  );
}
