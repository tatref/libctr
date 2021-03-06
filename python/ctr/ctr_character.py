# This is a generated file! Please edit source .ksy file and use kaitai-struct-compiler to rebuild

from pkg_resources import parse_version
from kaitaistruct import __version__ as ks_version, KaitaiStruct, KaitaiStream, BytesIO


if parse_version(ks_version) < parse_version('0.7'):
    raise Exception("Incompatible Kaitai Struct Python API: 0.7 or later is required, but you have %s" % (ks_version))

class CtrCharacter(KaitaiStruct):
    """Parser for the CTR characters (low, med, hi) and animations (dance, lose)
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
        self.unknown2 = self._io.read_bytes(12)
        self.wx8_ptr = self._io.read_u4le()
        self.magic2 = self._io.ensure_fixed_contents(b"\x00\x00\x00\x00")
        self.unknown_ptr1 = self._io.read_u4le()
        self.unknown_ptr2 = self._io.read_u4le()
        self.magic3 = self._io.ensure_fixed_contents(b"\x00\x00\x00\x00")
        self.animations_count = self._io.read_u4le()
        self.animations_table_ptr = self._io.read_u4le()
        self.magic4 = self._io.ensure_fixed_contents(b"\x00\x00\x00\x00")

    class AnimationEntry(KaitaiStruct):
        def __init__(self, _io, _parent=None, _root=None):
            self._io = _io
            self._parent = _parent
            self._root = _root if _root else self
            self._read()

        def _read(self):
            self.animation_ptr = self._io.read_u4le()

        class Animation(KaitaiStruct):
            def __init__(self, _io, _parent=None, _root=None):
                self._io = _io
                self._parent = _parent
                self._root = _root if _root else self
                self._read()

            def _read(self):
                self.animation_name = (KaitaiStream.bytes_terminate(self._io.read_bytes(16), 0, False)).decode(u"ASCII")
                self.unknown_count1 = self._io.read_u1()
                self.unknown_xx = self._io.read_u1()
                self.unknown_size1 = self._io.read_u2le()
                self.unknown_ptr2 = self._io.read_u4le()
                self.unknown3 = self._io.read_u4le()
                self.unknown4 = self._io.read_u4le()
                self.unknown_data1 = [None] * (self.unknown_count1)
                for i in range(self.unknown_count1):
                    self.unknown_data1[i] = self._root.AnimationEntry.Animation.UnknownData1(self._io, self, self._root)


            class UnknownData1(KaitaiStruct):
                def __init__(self, _io, _parent=None, _root=None):
                    self._io = _io
                    self._parent = _parent
                    self._root = _root if _root else self
                    self._read()

                def _read(self):
                    self.magic1 = self._io.read_bytes((16 + 4))
                    self.data1 = self._io.read_bytes((self._parent.unknown_size1 - 20))


            @property
            def magic1(self):
                if hasattr(self, '_m_magic1'):
                    return self._m_magic1 if hasattr(self, '_m_magic1') else None

                _pos = self._io.pos()
                self._io.seek((self.unknown_ptr2 + 4))
                self._m_magic1 = self._io.ensure_fixed_contents(b"\xFF\x01\x00\x00")
                self._io.seek(_pos)
                return self._m_magic1 if hasattr(self, '_m_magic1') else None


        @property
        def animation(self):
            if hasattr(self, '_m_animation'):
                return self._m_animation if hasattr(self, '_m_animation') else None

            _pos = self._io.pos()
            self._io.seek((self.animation_ptr + 4))
            self._m_animation = self._root.AnimationEntry.Animation(self._io, self, self._root)
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

    @property
    def wx8section(self):
        """ends with [0xff 0xff 0xff 0xff]
        """
        if hasattr(self, '_m_wx8section'):
            return self._m_wx8section if hasattr(self, '_m_wx8section') else None

        _pos = self._io.pos()
        self._io.seek((self.wx8_ptr + 4))
        self._m_wx8section = self._io.read_u4le()
        self._io.seek(_pos)
        return self._m_wx8section if hasattr(self, '_m_wx8section') else None


