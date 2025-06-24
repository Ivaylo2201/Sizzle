import { httpClient } from '@/utils/httpClient';
import type { City } from '@/utils/types/models/City';
import { useQuery } from '@tanstack/react-query';

type UseCitiesResponse = City[];

async function getCities() {
  const res = await httpClient.get<UseCitiesResponse>('/cities');
  return res.data;
}

export default function useCities() {
  return useQuery({
    queryKey: ['cities'],
    queryFn: () => getCities(),
    staleTime: 60 * 60 * 1000,
    retry: false
  });
}
