# This is a generated file! Please edit source .ksy file and use kaitai-struct-compiler to rebuild

from pkg_resources import parse_version
from kaitaistruct import __version__ as ks_version, KaitaiStruct, KaitaiStream, BytesIO


if parse_version(ks_version) < parse_version('0.7'):
    raise Exception("Incompatible Kaitai Struct Python API: 0.7 or later is required, but you have %s" % (ks_version))

class CtrLang(KaitaiStruct):
    """Parser for the lang files
    version 0
    """
    def __init__(self, _io, _parent=None, _root=None):
        self._io = _io
        self._parent = _parent
        self._root = _root if _root else self
        self._read()

    def _read(self):
        self.strings_count = self._io.read_u4le()
        self.offset = self._io.read_u4le()

    @property
    def strings(self):
        if hasattr(self, '_m_strings'):
            return self._m_strings if hasattr(self, '_m_strings') else None

        _pos = self._io.pos()
        self._io.seek(8)
        self._m_strings = [None] * (self.strings_count)
        for i in range(self.strings_count):
            self._m_strings[i] = (self._io.read_bytes_term(0, False, True, True)).decode(u"ascii")

        self._io.seek(_pos)
        return self._m_strings if hasattr(self, '_m_strings') else None

    @property
    def something(self):
        if hasattr(self, '_m_something'):
            return self._m_something if hasattr(self, '_m_something') else None

        _pos = self._io.pos()
        self._io.seek(self.offset)
        self._m_something = self._io.read_u4le()
        self._io.seek(_pos)
        return self._m_something if hasattr(self, '_m_something') else None


