# This is a generated file! Please edit source .ksy file and use kaitai-struct-compiler to rebuild

from pkg_resources import parse_version
from kaitaistruct import __version__ as ks_version, KaitaiStruct, KaitaiStream, BytesIO


if parse_version(ks_version) < parse_version('0.7'):
    raise Exception("Incompatible Kaitai Struct Python API: 0.7 or later is required, but you have %s" % (ks_version))

class CtrModel(KaitaiStruct):
    """Parser for the CTR models
    version 0
    Original code https://github.com/DCxDemo/CTR-tools
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


    class InfoHeader(KaitaiStruct):
        def __init__(self, _io, _parent=None, _root=None):
            self._io = _io
            self._parent = _parent
            self._root = _root if _root else self
            self._read()

        def _read(self):
            self.unknown1 = self._io.read_u4le()
            self.faces_num = self._io.read_s4le()
            self.vertex_num = self._io.read_s4le()
            self.unknown2 = self._io.read_u4le()
            self.ptr_ngon_array = self._io.read_s4le()
            self.ptr_vert_array = self._io.read_u4le()
            self.unknown3 = self._io.read_u4le()
            self.ptr_face_array = self._io.read_u4le()
            self.face_num = self._io.read_s4le()

        class Vertex(KaitaiStruct):
            def __init__(self, _io, _parent=None, _root=None):
                self._io = _io
                self._parent = _parent
                self._root = _root if _root else self
                self._read()

            def _read(self):
                self.coordinates = self._root.InfoHeader.Vertex.Vector4u2(self._io, self, self._root)
                self.color1 = self._root.InfoHeader.Vertex.Vector4u1(self._io, self, self._root)
                self.color2 = self._root.InfoHeader.Vertex.Vector4u1(self._io, self, self._root)

            class Vector4u2(KaitaiStruct):
                def __init__(self, _io, _parent=None, _root=None):
                    self._io = _io
                    self._parent = _parent
                    self._root = _root if _root else self
                    self._read()

                def _read(self):
                    self.x = self._io.read_u2le()
                    self.y = self._io.read_u2le()
                    self.z = self._io.read_u2le()
                    self.w = self._io.read_u2le()


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
            self._io.seek(self.ptr_vert_array)
            self._m_vertices = [None] * (self.vertex_num)
            for i in range(self.vertex_num):
                self._m_vertices[i] = self._root.InfoHeader.Vertex(self._io, self, self._root)

            self._io.seek(_pos)
            return self._m_vertices if hasattr(self, '_m_vertices') else None


    @property
    def info_header(self):
        if hasattr(self, '_m_info_header'):
            return self._m_info_header if hasattr(self, '_m_info_header') else None

        _pos = self._io.pos()
        self._io.seek(self.header.ptr_info_header)
        self._m_info_header = self._root.InfoHeader(self._io, self, self._root)
        self._io.seek(_pos)
        return self._m_info_header if hasattr(self, '_m_info_header') else None


