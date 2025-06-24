import type { Address } from '@/utils/types/models/Address';

type AddressCardProps = { className?: string } & Address;

export default function AddressCard({
  cityName,
  streetName,
  streetNumber,
  className = ''
}: AddressCardProps) {
  return (
    <div
      className={`bg-theme-beige rounded-2xl shadow-md flex flex-col font-rubik p-4 border-2 cursor-pointer ${className}`}
    >
      <h1 className='font-bold'>{cityName}</h1>
      <p>
        {streetNumber} {streetName}
      </p>
    </div>
  );
}
