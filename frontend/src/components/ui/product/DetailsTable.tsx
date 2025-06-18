type DetailsTableProps = {
  weight: number;
  calories: number;
}

export default function DetailsTable({ weight, calories }: DetailsTableProps) {
  return (
    <table className='w-full text-left text-sm border border-theme-gray'>
      <tbody>
        <tr className='border-b'>
          <td className='px-4 py-2 text-theme-gray italic'>Weight (kCal)</td>
          <td className='px-4 py-2 italic'>{weight}</td>
        </tr>
        <tr>
          <td className='px-4 py-2 italic text-theme-gray'>Calories (Grams)</td>
          <td className='px-4 py-2 italic'>{calories}</td>
        </tr>
      </tbody>
    </table>
  );
}
