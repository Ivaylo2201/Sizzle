import React from 'react'

type DiscountLabelProps = {
  discountPercentage: number
}

export default function DiscountLabel({ discountPercentage }: DiscountLabelProps) {
  return (
    <span className='absolute py-1.5 px-4.5 top-3 left-3 bg-theme-pink rounded-xl'>
      <h6 className='text-white font-rubik'>-{discountPercentage}%</h6>
    </span>
  )
}
