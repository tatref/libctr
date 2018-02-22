# This is a generated file! Please edit source .ksy file and use kaitai-struct-compiler to rebuild

from pkg_resources import parse_version
from kaitaistruct import __version__ as ks_version, KaitaiStruct, KaitaiStream, BytesIO


if parse_version(ks_version) < parse_version('0.7'):
    raise Exception("Incompatible Kaitai Struct Python API: 0.7 or later is required, but you have %s" % (ks_version))

class CtrCharacter(KaitaiStruct):
    """Parser for the CTR characters (low, med, hi) and animations (dance, loose)
    version 0.1
    """
    def __init__(self, _io, _parent=None, _root=None):
        self._io = _io
        self._parent = _parent
        self._root = _root if _root else self
        self._read()

    def _read(self):
        self.size = self._io.read_u4le()
        self.name = (KaitaiStream.bytes_terminate(self._io.read_bytes(16), 0, False)).decode(u"ASCII")
        self.unknown1 = self._io.read_bytes(8)
        self.name2 = (KaitaiStream.bytes_terminate(self._io.read_bytes(16), 0, False)).decode(u"ASCII")
        self.magic1 = self._io.ensure_fixed_contents(b"\x00\x00\x00\x00")
        self.unknown2 = self._io.read_bytes(20)
        self.wx8_end = self._io.read_u4le()
        self.unknown3 = self._io.read_bytes(8)
        self.animations_count = self._io.read_u4le()
        self.animations_table_ptr = self._io.read_u4le()
        self.unknown4 = self._io.read_bytes(52)

    class AnimationEntry(KaitaiStruct):
        def __init__(self, _io, _parent=None, _root=None):
            self._io = _io
            self._parent = _parent
            self._root = _root if _root else self
            self._read()

        def _read(self):
            self.animation_ptr = self._io.read_u4le()

        class Anim(KaitaiStruct):
            def __init__(self, _io, _parent=None, _root=None):
                self._io = _io
                self._parent = _parent
                self._root = _root if _root else self
                self._read()

            def _read(self):
                self.unknown1 = self._io.read_u4le()
                self.animation_name = (KaitaiStream.bytes_terminate(self._io.read_bytes(16), 0, False)).decode(u"ASCII")
                self.unknown2 = self._io.read_u4le()
                self.unknown3 = self._io.read_u4le()


        @property
        def animation(self):
            if hasattr(self, '_m_animation'):
                return self._m_animation if hasattr(self, '_m_animation') else None

            _pos = self._io.pos()
            self._io.seek(self.animation_ptr)
            self._m_animation = self._root.AnimationEntry.Anim(self._io, self, self._root)
            self._io.seek(_pos)
            return self._m_animation if hasattr(self, '_m_animation') else None


    @property
    def animations_index(self):
        if hasattr(self, '_m_animations_index'):
            return self._m_animations_index if hasattr(self, '_m_animations_index') else None

        _pos = self._io.pos()
        self._io.seek((self.animations_table_ptr + 4))
        self._m_animations_index = [None] * (self.animations_count)
        for i in range(self.animations_count):
            self._m_animations_index[i] = self._root.AnimationEntry(self._io, self, self._root)

        self._io.seek(_pos)
        return self._m_animations_index if hasattr(self, '_m_animations_index') else None


