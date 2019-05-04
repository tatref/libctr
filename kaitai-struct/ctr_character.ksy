meta:
  id: ctr_character
  file-extension: chr
  endian: le
  ks-version: 0.8
doc: |
  Parser for the CTR characters (low, med, hi) and animations (dance, lose)
  version 0.1


seq:
  - id: size
    type: u4
  - id: name
    type: str
    encoding: ASCII
    size: 16
    terminator: 0
  - id: unknown1
    size: 8
  - id: name2
    type: str
    encoding: ASCII
    size: 16
    terminator: 0
  - id: magic1
    contents: [0x00, 0x00, 0x00, 0x00]
  - id: unknown2
    size: 12
  - id: wx8_ptr
    type: u4
  - id: magic2
    contents: [0x00, 0x00, 0x00, 0x00]
  - id: unknown_ptr1
    type: u4
  - id: unknown_ptr2
    type: u4
  - id: magic3
    contents: [0x00, 0x00, 0x00, 0x00]  
  - id: animations_count
    type: u4
  - id: animations_table_ptr
    type: u4

  - id: magic4
    contents: [0x00, 0x00, 0x00, 0x00]  



instances:
  animations_index:
    pos: animations_table_ptr + 4
    type: animation_entry
    repeat: expr
    repeat-expr: animations_count
  wx8section:
    pos: wx8_ptr + 4
    type: u4
    doc: |
      ends with [0xff 0xff 0xff 0xff]


types:
  animation_entry:
    seq:
      - id: animation_ptr
        type: u4
    instances:
      animation:
        pos: animation_ptr + 4
        type: animation
    types:
      animation:
        seq:
          #- id: unknown1
          #  type: u4
          #  # maybe this does not belong to the animation?
          - id: animation_name
            type: str
            encoding: ASCII
            size: 16
            terminator: 0
          - id: unknown_count1
            type: u1
          - id: unknown_xx
            type: u1
          - id: unknown_size1
            type: u2
            doc: |
              starts after bytes 0x00 * 16, 0x1c, 0x00 * 3
          - id: unknown_ptr2
            type: u4
          - id: unknown3
            type: u4
          - id: unknown4
            type: u4
          - id: unknown_data1
            type: unknown_data1
            repeat: expr
            repeat-expr: unknown_count1
        types:
          unknown_data1:
            seq:
              - id: magic1
              #  contents: [0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
              #  0x1c,0x00,0x00,0x00]
                size: 16 + 4
              - id: data1
                size: _parent.unknown_size1 - 20
        instances:
          magic1:
            pos: unknown_ptr2 + 4
            contents: [0xff, 0x01, 0x00, 0x00]


