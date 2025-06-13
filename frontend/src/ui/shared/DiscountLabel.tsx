type DiscountLabelProps = {
  discountPercentage: number
}

export default function DiscountLabel({ discountPercentage }: DiscountLabelProps) {
  return (
    <span className='absolute py-1.5 px-4 top-5 left-5 bg-theme-pink rounded-xl'>
      <h6 className='text-white font-dmsans'>-{discountPercentage}%</h6>
    </span>
  )
}
