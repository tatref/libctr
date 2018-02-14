meta:
  id: ctr_tim2x
  application: Crash Team Racing
  file-extension: tim2x
  endian: le
  imports:
    - psx_tim
doc: |
  tim2x contains 2 TIMs in a row
  version 0

seq:
  - id: magic
    contents: [0x20, 0x00, 0x00, 0x00]
  - id: tim1_size
    type: u4
  - id: tim1
    type: psx_tim
  - id: tim2_size
    type: u4
  - id: tim2
    type: psx_tim
