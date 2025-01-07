import { useNavigate } from 'react-router-dom';
import TCategory from '../../../types/category';

export default function Category({ imageUrl, title, className }: TCategory) {
  const navigate = useNavigate();

  return (
    <div
      onClick={() => navigate(`/menu/${title}`)}
      className={`${className} h-60 rounded-xl shadow-xl overflow-hidden relative hover:cursor-pointer`}
    >
      <img
        className='w-full h-full object-cover brightness-75 hover:scale-110 transition-all duration-300'
        src={imageUrl}
        alt={title}
      />
      <h1 className='absolute bottom-10 left-5 text-white font-Montserrat uppercase font-bold text-3xl'>
        {title}
      </h1>
      <h1 className='absolute bottom-4 left-5 text-white italic font-Montserrat text-xl'>
        See more
      </h1>
    </div>
  );
}
