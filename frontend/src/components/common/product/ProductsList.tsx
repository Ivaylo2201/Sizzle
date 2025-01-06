import Product from "../../../types/Product";
import ProductCard from "./ProductCard";

type ProductsListProps = {
  category: string;
}

const products = [
  {
    pk: 1,
    imageUrl: 'https://images.unsplash.com/photo-1512058564362-b9b206470b16',
    discountPercentage: 10,
    price: 18,
    discountedPrice: 16.2,
    title: 'Pepperoni Pizza',
    rating: 4.5,
    category: 'pizzas'
  },
  {
    pk: 2,
    imageUrl: 'https://images.unsplash.com/photo-1576158228662-b07424ee8255',
    discountPercentage: 5,
    price: 25,
    discountedPrice: 23.75,
    title: 'Salmon Sushi',
    rating: 4.8,
    category: 'Sushi'
  },
  {
    pk: 3,
    imageUrl: 'https://images.unsplash.com/photo-1562112970-c67270d16518',
    discountPercentage: 15,
    price: 15,
    discountedPrice: 12.75,
    title: 'Cheeseburger',
    rating: 4.3,
    category: 'Burger'
  },
  {
    pk: 4,
    imageUrl: 'https://images.unsplash.com/photo-1561928957-03f1f9a993b4',
    discountPercentage: 20,
    price: 12,
    discountedPrice: 9.6,
    title: 'Caesar Salad',
    rating: 4.0,
    category: 'Salad'
  },
  {
    pk: 5,
    imageUrl: 'https://images.unsplash.com/photo-1571292475028-88c88b71a350',
    discountPercentage: 10,
    price: 22,
    discountedPrice: 19.8,
    title: 'Spaghetti Carbonara',
    rating: 4.7,
    category: 'Pasta'
  },
  {
    pk: 6,
    imageUrl: 'https://images.unsplash.com/photo-1604581175913-615399dc88a1',
    discountPercentage: 8,
    price: 20,
    discountedPrice: 18.4,
    title: 'Grilled Chicken',
    rating: 4.6,
    category: 'Grill'
  },
  {
    pk: 7,
    imageUrl: 'https://images.unsplash.com/photo-1596435747160-c7cbf9d89b67',
    discountPercentage: 5,
    price: 16,
    discountedPrice: 15.2,
    title: 'Margherita Pizza',
    rating: 4.2,
    category: 'pizzas'
  },
  {
    pk: 8,
    imageUrl: 'https://images.unsplash.com/photo-1606189706779-d566f99de779',
    discountPercentage: 15,
    price: 10,
    discountedPrice: 8.5,
    title: 'Chocolate Cake',
    rating: 4.8,
    category: 'Dessert'
  },
  {
    pk: 9,
    imageUrl: 'https://images.unsplash.com/photo-1587795916235-e32fe8b6a1e9',
    discountPercentage: 5,
    price: 8,
    discountedPrice: 7.6,
    title: 'Miso Soup',
    rating: 4.1,
    category: 'Sushi'
  },
  {
    pk: 10,
    imageUrl: 'https://images.unsplash.com/photo-1562114124-b9c5288cba1c',
    discountPercentage: 10,
    price: 14,
    discountedPrice: 12.6,
    title: 'Vegetable Salad',
    rating: 4.0,
    category: 'Salad'
  },
  {
    pk: 11,
    imageUrl: 'https://images.unsplash.com/photo-1596489603690-8e140e1c57b0',
    discountPercentage: 12,
    price: 17,
    discountedPrice: 14.96,
    title: 'Chicken Burger',
    rating: 4.4,
    category: 'Burger'
  },
  {
    pk: 12,
    imageUrl: 'https://images.unsplash.com/photo-1576474666822-63b625cfbaf0',
    discountPercentage: 8,
    price: 28,
    discountedPrice: 25.76,
    title: 'Seafood Pasta',
    rating: 4.6,
    category: 'Pasta'
  },
  {
    pk: 13,
    imageUrl: 'https://images.unsplash.com/photo-1592616263943-92ac7e9b0b5a',
    discountPercentage: 10,
    price: 35,
    discountedPrice: 31.5,
    title: 'Grilled Steak',
    rating: 4.9,
    category: 'Grill'
  },
  {
    pk: 14,
    imageUrl: 'https://images.unsplash.com/photo-1591847367886-2171b70a493d',
    discountPercentage: 5,
    price: 12,
    discountedPrice: 11.4,
    title: 'Panna Cotta',
    rating: 4.7,
    category: 'Dessert'
  },
  {
    pk: 15,
    imageUrl: 'https://images.unsplash.com/photo-1604535314247-f22fd3485c8f',
    discountPercentage: 20,
    price: 15,
    discountedPrice: 12,
    title: 'Chicken Wings',
    rating: 4.3,
    category: 'Grill'
  },
  {
    pk: 16,
    imageUrl: 'https://images.unsplash.com/photo-1590504780825-6bb44cf7c097',
    discountPercentage: 10,
    price: 18,
    discountedPrice: 16.2,
    title: 'Hawaiian Pizza',
    rating: 4.2,
    category: 'pizzas'
  },
  {
    pk: 17,
    imageUrl: 'https://images.unsplash.com/photo-1587734583014-c19c5cc62528',
    discountPercentage: 8,
    price: 9,
    discountedPrice: 8.28,
    title: 'Tiramisu',
    rating: 4.8,
    category: 'Dessert'
  },
  {
    pk: 18,
    imageUrl: 'https://images.unsplash.com/photo-1598670312673-c76a0e08701d',
    discountPercentage: 5,
    price: 22,
    discountedPrice: 20.9,
    title: 'Tempura',
    rating: 4,
    category: 'Sushi'
  },
  {
    pk: 19,
    imageUrl: 'https://images.unsplash.com/photo-1589932779079-60fa995db18c',
    discountPercentage: 10,
    price: 21,
    discountedPrice: 18.9,
    title: 'Fettuccine Alfredo',
    rating: 4.5,
    category: 'Pasta'
  },
  {
    pk: 20,
    imageUrl: 'https://images.unsplash.com/photo-1588715352015-9f95a1841d3e',
    discountPercentage: 12,
    price: 10,
    discountedPrice: 8.8,
    title: 'Apple Pie',
    rating: 4.7,
    category: 'Dessert'
  }
];


export default function ProductsList({category}: ProductsListProps) {

  return (  
    <div className="flex flex-wrap justify-center items-center gap-5">
      {products.filter((product) => product.category === category).map((product) => (
        <ProductCard
          key={product.pk}
          pk={product.pk}
          imageUrl={product.imageUrl}
          discountPercentage={product.discountPercentage}
          price={product.price}
          discountedPrice={product.discountedPrice}
          title={product.title}
          rating={5}
        />
      ))}
    </div>
  );
};
