import useProducts from '@/lib/hooks/useProducts'

type ProductListProps = { category: string}

export default function ProductList({ category }: ProductListProps) {
  const { data: products } = useProducts(category);

  return (
    <div>
      {products.map((product) => (
        <div key={product.id}>{product.productName}</div>
      ))}
    </div>
  )
}
