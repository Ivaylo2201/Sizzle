import { useEffect, useState } from 'react';

import categorySalad from '../../../assets/categories/categorySalads.jpg';
import categoryPizza from '../../../assets/categories/categoryPizza.jpg';
import categorySushi from '../../../assets/categories/categorySushi.jpg';
import categoryGrill from '../../../assets/categories/categoryGrill.jpg';
import categoryBurger from '../../../assets/categories/categoryBurgers.jpg';
import categoryPasta from '../../../assets/categories/categoryPasta.jpg';
import categoryDesserts from '../../../assets/categories/categoryDesserts.jpg';
import categoryDrinks from '../../../assets/categories/categoryDrinks.jpg';

import GridMenu from './GridMenu';
import CarouselMenu from './CarouselMenu';
import TCategory from '../../../types/category';

export default function Menu() {
  const [isDesktop, setIsDesktop] = useState<boolean | null>(null);

  useEffect(() => {
    const handleResize = () => setIsDesktop(window.innerWidth >= 1400);

    handleResize();

    window.addEventListener('resize', handleResize);

    return () => window.removeEventListener('resize', handleResize);
  }, []);

  const categories: TCategory[] = [
    { imageUrl: categorySalad, title: 'salads' },
    { imageUrl: categoryPizza, title: 'pizzas' },
    { imageUrl: categorySushi, title: 'sushi' },
    { imageUrl: categoryGrill, title: 'grill' },
    { imageUrl: categoryBurger, title: 'burgers' },
    { imageUrl: categoryPasta, title: 'pasta' },
    { imageUrl: categoryDesserts, title: 'desserts' },
    { imageUrl: categoryDrinks, title: 'drinks' }
  ];

  return isDesktop ? (
    <CarouselMenu categories={categories} />
  ) : (
    <GridMenu categories={categories} />
  );
}
