import { useSuspenseQuery } from "@tanstack/react-query";

import { httpClient } from "@/utils/httpClient";
import type { Address } from "@/utils/types/models/Address";

type UseAddressesResponse = Address[];

async function getAddresses() {
  const res = await httpClient.get<UseAddressesResponse>('/profile/addresses');
  return res.data;
}

export default function useAddresses() {
  return useSuspenseQuery({
    queryKey: ['addresses'],
    queryFn: () => getAddresses(),
    staleTime: 60 * 60 * 1000,
    retry: false
  });
}