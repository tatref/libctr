# This is a generated file! Please edit source .ksy file and use kaitai-struct-compiler to rebuild

from pkg_resources import parse_version
from kaitaistruct import __version__ as ks_version, KaitaiStruct, KaitaiStream, BytesIO


if parse_version(ks_version) < parse_version('0.7'):
    raise Exception("Incompatible Kaitai Struct Python API: 0.7 or later is required, but you have %s" % (ks_version))

from ctr.psx_tim import PsxTim
class CtrTim2x(KaitaiStruct):
    """tim2x contains 2 TIMs in a row
    version 0
    """
    def __init__(self, _io, _parent=None, _root=None):
        self._io = _io
        self._parent = _parent
        self._root = _root if _root else self
        self._read()

    def _read(self):
        self.magic = self._io.ensure_fixed_contents(b"\x20\x00\x00\x00")
        self.tim1_size = self._io.read_u4le()
        self.tim1 = PsxTim(self._io)
        self.tim2_size = self._io.read_u4le()
        self.tim2 = PsxTim(self._io)


