# This is a generated file! Please edit source .ksy file and use kaitai-struct-compiler to rebuild

from pkg_resources import parse_version
from kaitaistruct import __version__ as ks_version, KaitaiStruct, KaitaiStream, BytesIO


if parse_version(ks_version) < parse_version('0.7'):
    raise Exception("Incompatible Kaitai Struct Python API: 0.7 or later is required, but you have %s" % (ks_version))

class CtrLevel(KaitaiStruct):
    """Parser for CTR levels
    Original code https://github.com/DCxDemo/CTR-tools
    version 0.1
    """
    def __init__(self, _io, _parent=None, _root=None):
        self._io = _io
        self._parent = _parent
        self._root = _root if _root else self
        self._read()

    def _read(self):
        self.header = self._root.Header(self._io, self, self._root)

    class Header(KaitaiStruct):
        def __init__(self, _io, _parent=None, _root=None):
            self._io = _io
            self._parent = _parent
            self._root = _root if _root else self
            self._read()

        def _read(self):
            self.size = self._io.read_u4le()
            self.ptr_info_header = self._io.read_u4le()
            self.unknown1 = self._io.read_u4le()
            self.unknown2 = self._io.read_u4le()
            self.num_pickup_headers = self._io.read_s4le()
            self.ptr_pickup_headers = self._io.read_u4le()
            self.num_pickup_models = self._io.read_s4le()
            self.ptr_faces_array = self._io.read_u4le()
            self.unknown3 = self._io.read_u4le()
            self.unknown4 = self._io.read_u4le()
            self.ptr_pickup_headers_ptr_array = self._io.read_u4le()
            self.unknown5 = self._io.read_u4le()
            self.magic1 = self._io.ensure_fixed_contents(b"\x00\x00\x00\x00\x00\x00\x00\x00")

        class ObjectEntry(KaitaiStruct):
            def __init__(self, _io, _parent=None, _root=None):
                self._io = _io
                self._parent = _parent
                self._root = _root if _root else self
                self._read()

            def _read(self):
                self.object_instance_ptr = self._io.read_u4le()

            class ObjectInstance(KaitaiStruct):
                def __init__(self, _io, _parent=None, _root=None):
                    self._io = _io
                    self._parent = _parent
                    self._root = _root if _root else self
                    self._read()

                def _read(self):
                    self.name = (KaitaiStream.bytes_terminate(self._io.read_bytes(16), 0, False)).decode(u"ASCII")
                    self.mesh_ptr = self._io.read_u4le()
                    self.px = self._io.read_s2le()
                    self.py = self._io.read_s2le()
                    self.pz = self._io.read_s2le()
                    self.p0 = self._io.read_s2le()
                    self.magic1 = self._io.ensure_fixed_contents(b"\x00\x00\x00\x00")
                    self.unknown1 = self._io.read_u4le()
                    self.unknown2 = self._io.read_u4le()
                    self.unknown3 = self._io.read_u4le()
                    self.unknown4 = self._io.read_u4le()
                    self.ax = self._io.read_s2le()
                    self.ay = self._io.read_s2le()
                    self.az = self._io.read_s2le()
                    self.bx = self._io.read_s2le()
                    self.by = self._io.read_s2le()
                    self.bz = self._io.read_s2le()
                    self.event_type = self._io.read_u4le()

                class Mesh(KaitaiStruct):
                    def __init__(self, _io, _parent=None, _root=None):
                        self._io = _io
                        self._parent = _parent
                        self._root = _root if _root else self
                        self._read()

                    def _read(self):
                        self.unknown1 = self._io.read_u4le()
                        self.name = (KaitaiStream.bytes_terminate(self._io.read_bytes(16), 0, False)).decode(u"ASCII")
                        self.unknown2 = self._io.read_u4le()
                        self.name2_ptr = self._io.read_u4le()
                        self.name2 = (KaitaiStream.bytes_terminate(self._io.read_bytes(16), 0, False)).decode(u"ASCII")
                        self.magic1 = self._io.ensure_fixed_contents(b"\x00\x00\x00\x00")
                        self.unknown4 = self._io.read_bytes(12)
                        self.wx8_ptr = self._io.read_u4le()
                        self.unknown_ptr1 = self._io.read_u4le()
                        self.unknown_table_ptr = self._io.read_u4le()
                        self.unknown_ptr3 = self._io.read_u4le()

                    @property
                    def table_ptr_end(self):
                        if hasattr(self, '_m_table_ptr_end'):
                            return self._m_table_ptr_end if hasattr(self, '_m_table_ptr_end') else None

                        _pos = self._io.pos()
                        self._io.seek((self.unknown_table_ptr + 4))
                        self._m_table_ptr_end = self._io.read_u4le()
                        self._io.seek(_pos)
                        return self._m_table_ptr_end if hasattr(self, '_m_table_ptr_end') else None

                    @property
                    def table_ptr(self):
                        """this can contain a lot of pointers (70 for "c" mesh), or very few (8 for "cactus_short"
                        fixme: does not work for "cowskull" (out of bounds)
                        """
                        if hasattr(self, '_m_table_ptr'):
                            return self._m_table_ptr if hasattr(self, '_m_table_ptr') else None

                        _pos = self._io.pos()
                        self._io.seek((self.unknown_table_ptr + 4))
                        self._m_table_ptr = []
                        i = 0
                        while True:
                            _ = self._io.read_u4le()
                            self._m_table_ptr.append(_)
                            if self._io.pos() > self.table_ptr_end:
                                break
                            i += 1
                        self._io.seek(_pos)
                        return self._m_table_ptr if hasattr(self, '_m_table_ptr') else None


                @property
                def object_mesh(self):
                    if hasattr(self, '_m_object_mesh'):
                        return self._m_object_mesh if hasattr(self, '_m_object_mesh') else None

                    _pos = self._io.pos()
                    self._io.seek(self.mesh_ptr)
                    self._m_object_mesh = self._root.Header.ObjectEntry.ObjectInstance.Mesh(self._io, self, self._root)
                    self._io.seek(_pos)
                    return self._m_object_mesh if hasattr(self, '_m_object_mesh') else None


            @property
            def object_instance(self):
                if hasattr(self, '_m_object_instance'):
                    return self._m_object_instance if hasattr(self, '_m_object_instance') else None

                _pos = self._io.pos()
                self._io.seek((self.object_instance_ptr + 4))
                self._m_object_instance = self._root.Header.ObjectEntry.ObjectInstance(self._io, self, self._root)
                self._io.seek(_pos)
                return self._m_object_instance if hasattr(self, '_m_object_instance') else None


        @property
        def objects_index(self):
            if hasattr(self, '_m_objects_index'):
                return self._m_objects_index if hasattr(self, '_m_objects_index') else None

            _pos = self._io.pos()
            self._io.seek((self.ptr_pickup_headers_ptr_array + 4))
            self._m_objects_index = [None] * (self.num_pickup_headers)
            for i in range(self.num_pickup_headers):
                self._m_objects_index[i] = self._root.Header.ObjectEntry(self._io, self, self._root)

            self._io.seek(_pos)
            return self._m_objects_index if hasattr(self, '_m_objects_index') else None


    class InfoHeader(KaitaiStruct):
        def __init__(self, _io, _parent=None, _root=None):
            self._io = _io
            self._parent = _parent
            self._root = _root if _root else self
            self._read()

        def _read(self):
            self.unknown1 = self._io.read_u4le()
            self.faces_count = self._io.read_s4le()
            self.vertices_count = self._io.read_s4le()
            self.unknown2 = self._io.read_u4le()
            self.ngon_array_ptr = self._io.read_s4le()
            self.vertices_array_ptr = self._io.read_u4le()
            self.unknown3 = self._io.read_u4le()
            self.face_array_ptr = self._io.read_u4le()
            self.face_count_unknown = self._io.read_s4le()

        class Vertex(KaitaiStruct):
            def __init__(self, _io, _parent=None, _root=None):
                self._io = _io
                self._parent = _parent
                self._root = _root if _root else self
                self._read()

            def _read(self):
                self.coordinates = self._root.InfoHeader.Vector4u2(self._io, self, self._root)
                self.color1 = self._root.InfoHeader.Vector4u1(self._io, self, self._root)
                self.color2 = self._root.InfoHeader.Vector4u1(self._io, self, self._root)


        class Ngon(KaitaiStruct):
            def __init__(self, _io, _parent=None, _root=None):
                self._io = _io
                self._parent = _parent
                self._root = _root if _root else self
                self._read()

            def _read(self):
                self.face_indices = [None] * (9)
                for i in range(9):
                    self.face_indices[i] = self._io.read_s2le()

                self.data = self._io.read_bytes(74)


        class Vector4u2(KaitaiStruct):
            def __init__(self, _io, _parent=None, _root=None):
                self._io = _io
                self._parent = _parent
                self._root = _root if _root else self
                self._read()

            def _read(self):
                self.x = self._io.read_s2le()
                self.y = self._io.read_s2le()
                self.z = self._io.read_s2le()
                self.w = self._io.read_s2le()


        class Vector4u1(KaitaiStruct):
            def __init__(self, _io, _parent=None, _root=None):
                self._io = _io
                self._parent = _parent
                self._root = _root if _root else self
                self._read()

            def _read(self):
                self.x = self._io.read_u1()
                self.y = self._io.read_u1()
                self.z = self._io.read_u1()
                self.w = self._io.read_u1()


        @property
        def vertices(self):
            if hasattr(self, '_m_vertices'):
                return self._m_vertices if hasattr(self, '_m_vertices') else None

            _pos = self._io.pos()
            self._io.seek((self.vertices_array_ptr + 4))
            self._m_vertices = [None] * (self.vertices_count)
            for i in range(self.vertices_count):
                self._m_vertices[i] = self._root.InfoHeader.Vertex(self._io, self, self._root)

            self._io.seek(_pos)
            return self._m_vertices if hasattr(self, '_m_vertices') else None

        @property
        def ngons(self):
            if hasattr(self, '_m_ngons'):
                return self._m_ngons if hasattr(self, '_m_ngons') else None

            _pos = self._io.pos()
            self._io.seek((self.ngon_array_ptr + 4))
            self._m_ngons = [None] * (self.faces_count)
            for i in range(self.faces_count):
                self._m_ngons[i] = self._root.InfoHeader.Ngon(self._io, self, self._root)

            self._io.seek(_pos)
            return self._m_ngons if hasattr(self, '_m_ngons') else None


    @property
    def info_header(self):
        if hasattr(self, '_m_info_header'):
            return self._m_info_header if hasattr(self, '_m_info_header') else None

        _pos = self._io.pos()
        self._io.seek(self.header.ptr_info_header)
        self._m_info_header = self._root.InfoHeader(self._io, self, self._root)
        self._io.seek(_pos)
        return self._m_info_header if hasattr(self, '_m_info_header') else None


