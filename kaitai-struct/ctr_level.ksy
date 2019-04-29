meta:
  id: ctr_level
  application: CTR (Crash Team Racing)
  file-extension: lev
  endian: le
  ks-version: 0.8
doc: |
  Parser for CTR levels
  Original code https://github.com/DCxDemo/CTR-tools
  version 0.1


seq:
  - id: header
    type: header

instances:
  info_header:
    pos: header.ptr_info_header
    type: info_header


types:
  header:
    seq:
      - id: size
        type: u4
      - id: ptr_info_header
        type: u4
      - id: unknown1
        type: u4
      - id: unknown2
        type: u4
      - id: num_pickup_headers
        type: s4
      - id: ptr_pickup_headers
        type: u4
      - id: num_pickup_models 
        type: s4
      - id: ptr_faces_array
        type: u4
      - id: unknown3
        type: u4
      - id: unknown4
        type: u4
      - id: ptr_pickup_headers_ptr_array
        type: u4
      - id: unknown5
        type: u4
      - id: magic1
        contents: [0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00]
        # works for all except  intro_race_today, intro_pass_tiny, intro_canyon_coco, intro_temple_polar
        # the value is then [212,0,0,0,224,0,0,0]

    instances:
      objects_index:
        pos: ptr_pickup_headers_ptr_array + 4
        type: object_entry
        repeat: expr
        repeat-expr: num_pickup_headers
        
    types:
      object_entry:
        seq:
          - id: object_instance_ptr
            type: u4
        instances:
          object_instance:
            type: object_instance
            pos: object_instance_ptr + 4

        types:
          object_instance:
            seq:
              - id: name
                type: str
                encoding: ASCII
                size: 16
                terminator: 0
              - id: mesh_ptr
                type: u4
              - id: px
                type: s2
              - id: py
                type: s2
              - id: pz
                type: s2
              - id: p0
                type: s2
              - id: magic1
                contents: [0x00, 0x00, 0x00, 0x00]
              - id: unknown1
                type: u4
              - id: unknown2
                type: u4
              - id: unknown3
                type: u4
              - id: unknown4
                type: u4
              - id: ax
                type: s2
              - id: ay
                type: s2
              - id: az
                type: s2
              - id: bx
                type: s2
              - id: by
                type: s2
              - id: bz
                type: s2
              - id: event_type
                type: u4
                doc: |
                  https://github.com/DCxDemo/CTR-tools/blob/master/formats/formats.txt
                
            instances:
              object_mesh:
                pos: mesh_ptr
                type: mesh
                
            types:
              mesh:
                seq:
                  - id: unknown1
                    type: u4
                  - id: name
                    type: str
                    size: 16
                    encoding: ASCII
                    terminator: 0
                  - id: unknown2
                    type: u4
                    doc: |
                      always the same for a given type of object
                  - id: name2_ptr
                    type: u4
                    doc: |
                      ptr to name2 + 4
                  - id: name2
                    type: str
                    size: 16
                    encoding: ASCII
                    terminator: 0
                  - id: magic1
                    contents: [0x00, 0x00, 0x00, 0x00]
                  - id: unknown4
                    size: 12
                  - id: wx8_ptr
                    type: u4
                    doc: |
                      always the same for a given type of object
                  - id: unknown_ptr1
                    type: u4
                  - id: unknown_table_ptr
                    doc: |
                      pointer to a table of pointers of variable size, see table_ptr instances
                    type: u4
                  - id: unknown_ptr3
                    type: u4
                  - id: magic2
                    contents: [0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00]
                instances:
                  table_ptr_end:
                    pos: unknown_table_ptr + 4
                    type: u4
                  table_ptr:
                    doc: |
                      this can contain a lot of pointers (70 for "c" mesh), or very few (8 for "cactus_short"
                      fixme: does not work for "cowskull" (out of bounds)
                    pos: unknown_table_ptr + 4
                    type: u4
                    repeat: until
                    repeat-until: _io.pos > table_ptr_end



  info_header:
      seq:
        - id: unknown1
          type: u4
        - id: faces_count
          type: s4
        - id: vertices_count
          type: s4
        - id: unknown2
          type: u4
        - id: ngon_array_ptr
          type: s4
        - id: vertices_array_ptr
          type: u4
        - id: unknown3
          type: u4
        - id: face_array_ptr
          type: u4
        - id: face_count_unknown
          type: s4
          
      instances:
        vertices:
          pos: vertices_array_ptr + 4
          type: vertex
          repeat: expr
          repeat-expr: vertices_count
        ngons:
          pos: ngon_array_ptr + 4
          type: ngon
          repeat: expr
          repeat-expr: faces_count
          
      types:
        vertex:
          seq:
            - id: coordinates
              type: vector4u2
            - id: color1
              type: vector4u1
            - id: color2
              type: vector4u1

        ngon:
          seq:
            - id: face_indices
              type: s2
              repeat: expr
              repeat-expr: 9
            - id: data
              #size: 0x2A + 0x20 
              size: 74


        vector4u2:
          seq:
            - id: x
              type: s2
            - id: y
              type: s2
            - id: z
              type: s2
            - id: w
              type: s2
              
        vector4u1:
          seq:
            - id: x
              type: u1
            - id: y
              type: u1
            - id: z
              type: u1
            - id: w
              type: u1


