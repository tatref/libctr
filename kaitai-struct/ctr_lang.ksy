meta:
  id: ctr_lang
  title: Crash Team Racing language files
  application: Crash Team Racing
  file-extension: lang
  ks-version: 0.8
  endian: le
  encoding: ascii
doc: |
  Parser for the lang files
  version 0

seq:
  - id: strings_count
    type: u4
  - id: offset
    type: u4

instances:
  strings:
    pos: 8
    type: str
    terminator: 0
    repeat: expr
    repeat-expr: strings_count

  something:
    pos: offset
    type: u4
