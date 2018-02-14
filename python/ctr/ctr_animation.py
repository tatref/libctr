# This is a generated file! Please edit source .ksy file and use kaitai-struct-compiler to rebuild

from pkg_resources import parse_version
from kaitaistruct import __version__ as ks_version, KaitaiStruct, KaitaiStream, BytesIO


if parse_version(ks_version) < parse_version('0.7'):
    raise Exception("Incompatible Kaitai Struct Python API: 0.7 or later is required, but you have %s" % (ks_version))

class CtrAnimation(KaitaiStruct):
    """Parser for the `dance` and `lose` animations
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
            self.content_size = self._io.read_u4le()
            self.name = (self._io.read_bytes(16)).decode(u"ASCII")
            self.unknown1 = self._io.read_u2le()
            self.magic = self._io.ensure_fixed_contents(b"\x01\x00")
            self.magic1 = self._io.ensure_fixed_contents(b"\x18\x00\x00\x00")
            self.name2 = (self._io.read_bytes(16)).decode(u"ASCII")
            self.magic2 = self._io.ensure_fixed_contents(b"\x00\x00\x00\x00")
            self.magic3 = self._io.ensure_fixed_contents(b"\x20\x4E\x00\x00")
            self.unknown2 = self._io.read_u4le()
            self.unknown3 = self._io.read_u4le()
            self.unknown4 = self._io.read_u4le()
            self.magic4 = self._io.ensure_fixed_contents(b"\x00\x00\x00\x00")
            self.wx8_header_end = self._io.read_u4le()
            self.unknown6 = self._io.read_u4le()
            self.magic5 = self._io.ensure_fixed_contents(b"\x00\x00\x00\x00")
            self.unknown7 = self._io.read_u4le()
            self.unknown8 = self._io.read_u4le()
            self.magic6 = self._io.ensure_fixed_contents(b"\x00\x00\x00\x00")
            self.unknown9 = self._io.read_u4le()



