meta:
  id: ctr_character
  file-extension: chr
  endian: le
doc: |
  Parser for the CTR characters
  version 0


seq:
  - id: header
    type: header

types:
  header:
    seq:
      - id: size
        type: u4
      - id: name
        type: str
        encoding: ASCII
        size: 16
        terminator: 0
      - id: unknown1
        size: 0x88
      - id: animation1_ptr
        type: u4
      - id: animation2_ptr
        type: u4
      - id: animation3_ptr
        type: u4
      - id: animation4_ptr
        type: u4

    instances:
      animation1:
        pos: animation1_ptr
        type: animation
      animation2:
        pos: animation2_ptr
        type: animation
      animation3:
        pos: animation3_ptr
        type: animation
      animation4:
        pos: animation4_ptr
        type: animation

    types:
      animation:
        seq:
          - id: unknown1
            type: u4
          - id: name
            type: str
            encoding: ASCII
            size: 16
            terminator: 0


