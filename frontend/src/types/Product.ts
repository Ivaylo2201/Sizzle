type Product = {
  pk: number;
  imageUrl: string;
  discountPercentage: number;
  price: number;
  discountedPrice: number;
  title: string;
  rating: 0 | 1 | 2 | 3 | 4 | 5;
};

export default Product;