# This is a generated file! Please edit source .ksy file and use kaitai-struct-compiler to rebuild

from pkg_resources import parse_version
from kaitaistruct import __version__ as ks_version, KaitaiStruct, KaitaiStream, BytesIO


if parse_version(ks_version) < parse_version('0.7'):
    raise Exception("Incompatible Kaitai Struct Python API: 0.7 or later is required, but you have %s" % (ks_version))

class CtrBigfile(KaitaiStruct):
    """BIGFILE.BIG parser
    version 1.0
    """
    def __init__(self, _io, _parent=None, _root=None):
        self._io = _io
        self._parent = _parent
        self._root = _root if _root else self
        self._read()

    def _read(self):
        self.magic = self._io.ensure_fixed_contents(b"\x00\x00\x00\x00")
        self.files_count = self._io.read_u4le()

    class IndexEntry(KaitaiStruct):
        """Represents an entry in the bigfile
        """
        def __init__(self, _io, _parent=None, _root=None):
            self._io = _io
            self._parent = _parent
            self._root = _root if _root else self
            self._read()

        def _read(self):
            self.offset = self._io.read_u4le()
            self.size = self._io.read_u4le()

        @property
        def file_content(self):
            if hasattr(self, '_m_file_content'):
                return self._m_file_content if hasattr(self, '_m_file_content') else None

            io = self._root._io
            _pos = io.pos()
            io.seek((self.offset * 2048))
            self._m_file_content = io.read_bytes(self.size)
            io.seek(_pos)
            return self._m_file_content if hasattr(self, '_m_file_content') else None


    @property
    def index(self):
        if hasattr(self, '_m_index'):
            return self._m_index if hasattr(self, '_m_index') else None

        _pos = self._io.pos()
        self._io.seek(8)
        self._m_index = [None] * (self.files_count)
        for i in range(self.files_count):
            self._m_index[i] = self._root.IndexEntry(self._io, self, self._root)

        self._io.seek(_pos)
        return self._m_index if hasattr(self, '_m_index') else None


