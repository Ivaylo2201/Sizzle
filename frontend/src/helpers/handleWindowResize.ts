import { Dispatch } from "react";

export default function handleWindowResize(
  boundary: number,
  setter: Dispatch<React.SetStateAction<boolean | null>>
): void {
  setter(window.innerWidth >= boundary);
}
