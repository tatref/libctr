meta:
  id: ctr_bigfile
  title: Crash Team Racing BIGFILE
  application: Crash Team Racing
  file-extension: BIG
  endian: le
  ks-version: 0.8
doc: |
  BIGFILE.BIG parser
  version 1.0


seq:
  - id: magic
    contents: [0, 0, 0, 0]
  - id: files_count
    type: u4
    doc: number of entries in the bigfile

instances:
  index:
    pos: 8
    type: index_entry
    repeat: expr
    repeat-expr: files_count

types:
  index_entry:
    doc: |
      Represents an entry in the bigfile

    seq:
      - id: offset
        doc: Pointer to the beginning of the entry (absolute offset). Unit is in 2048 bytes
        type: u4
      - id: size
        doc: Size of the entry in bytes
        type: u4
    instances:
      file_content:
        io: _root._io
        pos: offset * 2048
        size: size

