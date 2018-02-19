meta:
  id: ctr_character
  file-extension: chr
  endian: le
doc: |
  Parser for the CTR characters
  version 0


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
    size: 32
    
  - id: animations_count
    type: u4
  - id: animations_table_ptr
    type: u4

  - id: unknown3
    size: 52



instances:
  animations_index:
    pos: animations_table_ptr + 4
    type: animation_entry
    repeat: expr
    repeat-expr: animations_count
    


types:
  animation_entry:
    seq:
      - id: animation_ptr
        type: u4
    instances:
      animation:
        pos: animation_ptr
        type: anim
    types:
      anim:
        seq:
          - id: unknown1
            type: u4
            # maybe this does not belong to the animation?
          - id: animation_name
            type: str
            encoding: ASCII
            size: 16
            terminator: 0
          - id: unknown2
            type: u4
          - id: unknown3
            type: u4


