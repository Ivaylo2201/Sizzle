import { Modal } from '@mantine/core';

type AddAddressModalProps = {
  opened: boolean;
  close: () => void;
};

export default function AddAddressModal({
  opened,
  close
}: AddAddressModalProps) {
  return (
    <Modal opened={opened} onClose={close} title='Add address' centered>
      <p>address form TODO</p>
    </Modal>
  );
}
