# This is a generated file! Please edit source .ksy file and use kaitai-struct-compiler to rebuild

from pkg_resources import parse_version
from kaitaistruct import __version__ as ks_version, KaitaiStruct, KaitaiStream, BytesIO


if parse_version(ks_version) < parse_version('0.7'):
    raise Exception("Incompatible Kaitai Struct Python API: 0.7 or later is required, but you have %s" % (ks_version))

class CtrCharacter(KaitaiStruct):
    """Parser for the CTR characters
    version 0
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
            self.name = (KaitaiStream.bytes_terminate(self._io.read_bytes(16), 0, False)).decode(u"ASCII")
            self.unknown1 = self._io.read_bytes(136)
            self.animation1_ptr = self._io.read_u4le()
            self.animation2_ptr = self._io.read_u4le()
            self.animation3_ptr = self._io.read_u4le()
            self.animation4_ptr = self._io.read_u4le()

        class Animation(KaitaiStruct):
            def __init__(self, _io, _parent=None, _root=None):
                self._io = _io
                self._parent = _parent
                self._root = _root if _root else self
                self._read()

            def _read(self):
                self.unknown1 = self._io.read_u4le()
                self.name = (KaitaiStream.bytes_terminate(self._io.read_bytes(16), 0, False)).decode(u"ASCII")


        @property
        def animation1(self):
            if hasattr(self, '_m_animation1'):
                return self._m_animation1 if hasattr(self, '_m_animation1') else None

            _pos = self._io.pos()
            self._io.seek(self.animation1_ptr)
            self._m_animation1 = self._root.Header.Animation(self._io, self, self._root)
            self._io.seek(_pos)
            return self._m_animation1 if hasattr(self, '_m_animation1') else None

        @property
        def animation2(self):
            if hasattr(self, '_m_animation2'):
                return self._m_animation2 if hasattr(self, '_m_animation2') else None

            _pos = self._io.pos()
            self._io.seek(self.animation2_ptr)
            self._m_animation2 = self._root.Header.Animation(self._io, self, self._root)
            self._io.seek(_pos)
            return self._m_animation2 if hasattr(self, '_m_animation2') else None

        @property
        def animation3(self):
            if hasattr(self, '_m_animation3'):
                return self._m_animation3 if hasattr(self, '_m_animation3') else None

            _pos = self._io.pos()
            self._io.seek(self.animation3_ptr)
            self._m_animation3 = self._root.Header.Animation(self._io, self, self._root)
            self._io.seek(_pos)
            return self._m_animation3 if hasattr(self, '_m_animation3') else None

        @property
        def animation4(self):
            if hasattr(self, '_m_animation4'):
                return self._m_animation4 if hasattr(self, '_m_animation4') else None

            _pos = self._io.pos()
            self._io.seek(self.animation4_ptr)
            self._m_animation4 = self._root.Header.Animation(self._io, self, self._root)
            self._io.seek(_pos)
            return self._m_animation4 if hasattr(self, '_m_animation4') else None



