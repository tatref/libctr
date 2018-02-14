meta:
  id: ctr_animation
  title: Crash Team Racing animations
  application: Crash Team Racing
  file-extension: xxx
  endian: le
  ks-version: 0.8
doc: |
  Parser for the `dance` and `lose` animations
  version 0

seq:
  - id: header
    type: header
  

types:
  header:
    seq:
      - id: content_size
        doc: TODO from where to where?
        type: u4
      - id: name
        type: str
        encoding: ASCII
        size: 16
      - id: unknown1
        type: u2
      - id: magic
        contents: [0x01, 0x00]
      - id: magic1
        contents: [0x18, 0x00, 0x00, 0x00]
      - id: name2
        type: str
        encoding: ASCII
        size: 16
      - id: magic2
        contents: [0x00, 0x00, 0x00, 0x00]
      - id: magic3
        contents: [0x20, 0x4e, 0x00, 0x00]
      - id: unknown2
        type: u4
      - id: unknown3
        type: u4
      - id: unknown4
        type: u4
      - id: magic4
        contents: [0x00, 0x00, 0x00, 0x00]
      - id: wx8_header_end
        type: u4
        doc: end of WX8 header, points to some 0xffff
      - id: unknown6
        type: u4
      - id: magic5
        contents: [0x00, 0x00, 0x00, 0x00]
      - id: unknown7
        type: u4
        doc: |
          xxxx
      - id: unknown8
        type: u4
        doc: |
          xxxx
      - id: magic6
        contents: [0x00, 0x00, 0x00, 0x00]
      - id: unknown9
        type: u4
        doc: |
          xxxx

