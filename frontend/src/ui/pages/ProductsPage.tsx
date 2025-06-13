import Page from "@/ui/layouts/PageLayout";
import ProductsList from "@/ui/components/ProductList";
import useProducts from "@/lib/hooks/useProducts";
import { useParams } from "react-router";

export default function ProductPage() {
  const { category } = useParams();
  const { data: products } = useProducts(category);

  return (
    <Page>
      <ProductsList products={products} />
    </Page>
  );
};
