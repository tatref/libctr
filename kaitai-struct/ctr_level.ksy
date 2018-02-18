meta:
  id: ctr_level
  file-extension: lev
  endian: le
doc: |
  Parser for the CTR levels
  version 0
  Original code https://github.com/DCxDemo/CTR-tools

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
              - id: unknown5
                type: u4
            instances:
              object_mesh:
                pos: mesh_ptr
                type: object_mesh
            types:
              object_mesh:
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
                  - id: unknown3
                    type: u4
                  - id: name2
                    type: str
                    size: 16
                    encoding: ASCII
                    terminator: 0
                  - id: magic1
                    contents: [0x00, 0x00, 0x00, 0x00]




  info_header:
      seq:
        - id: unknown1
          type: u4
        - id: faces_num
          type: s4
        - id: vertex_num
          type: s4
        - id: unknown2
          type: u4
        - id: ptr_ngon_array
          type: s4
        - id: ptr_vert_array
          type: u4
        - id: unknown3
          type: u4
        - id: ptr_face_array
          type: u4
        - id: face_num
          type: s4
      instances:
        vertices:
          pos: ptr_vert_array
          type: vertex
          repeat: expr
          repeat-expr: vertex_num
      types:
        vertex:
          seq:
            - id: coordinates
              type: vector4u2
            - id: color1
              type: vector4u1
            - id: color2
              type: vector4u1
              doc: |
                ???
          types:
            vector4u2:
              seq:
                - id: x
                  type: u2
                - id: y
                  type: u2
                - id: z
                  type: u2
                - id: w
                  type: u2
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


