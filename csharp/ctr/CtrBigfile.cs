// This is a generated file! Please edit source .ksy file and use kaitai-struct-compiler to rebuild

using Kaitai;
using System.Collections.Generic;

namespace ctr
{

    /// <summary>
    /// BIGFILE.BIG parser
    /// version 1.0
    /// </summary>
    public partial class CtrBigfile : KaitaiStruct
    {
        public static CtrBigfile FromFile(string fileName)
        {
            return new CtrBigfile(new KaitaiStream(fileName));
        }

        public CtrBigfile(KaitaiStream p__io, KaitaiStruct p__parent = null, CtrBigfile p__root = null) : base(p__io)
        {
            m_parent = p__parent;
            m_root = p__root ?? this;
            f_index = false;
            _read();
        }
        private void _read()
        {
            _magic = m_io.EnsureFixedContents(new byte[] { 0, 0, 0, 0 });
            _filesCount = m_io.ReadU4le();
        }

        /// <summary>
        /// Represents an entry in the bigfile
        /// </summary>
        public partial class IndexEntry : KaitaiStruct
        {
            public static IndexEntry FromFile(string fileName)
            {
                return new IndexEntry(new KaitaiStream(fileName));
            }

            public IndexEntry(KaitaiStream p__io, CtrBigfile p__parent = null, CtrBigfile p__root = null) : base(p__io)
            {
                m_parent = p__parent;
                m_root = p__root;
                f_fileContent = false;
                _read();
            }
            private void _read()
            {
                _offset = m_io.ReadU4le();
                _size = m_io.ReadU4le();
            }
            private bool f_fileContent;
            private byte[] _fileContent;
            public byte[] FileContent
            {
                get
                {
                    if (f_fileContent)
                        return _fileContent;
                    KaitaiStream io = M_Root.M_Io;
                    long _pos = io.Pos;
                    io.Seek((Offset * 2048));
                    _fileContent = io.ReadBytes(Size);
                    io.Seek(_pos);
                    f_fileContent = true;
                    return _fileContent;
                }
            }
            private uint _offset;
            private uint _size;
            private CtrBigfile m_root;
            private CtrBigfile m_parent;

            /// <summary>
            /// Pointer to the beginning of the entry (absolute offset). Unit is in 2048 bytes
            /// </summary>
            public uint Offset { get { return _offset; } }

            /// <summary>
            /// Size of the entry in bytes
            /// </summary>
            public uint Size { get { return _size; } }
            public CtrBigfile M_Root { get { return m_root; } }
            public CtrBigfile M_Parent { get { return m_parent; } }
        }
        private bool f_index;
        private List<IndexEntry> _index;
        public List<IndexEntry> Index
        {
            get
            {
                if (f_index)
                    return _index;
                long _pos = m_io.Pos;
                m_io.Seek(8);
                _index = new List<IndexEntry>((int) (FilesCount));
                for (var i = 0; i < FilesCount; i++)
                {
                    _index.Add(new IndexEntry(m_io, this, m_root));
                }
                m_io.Seek(_pos);
                f_index = true;
                return _index;
            }
        }
        private byte[] _magic;
        private uint _filesCount;
        private CtrBigfile m_root;
        private KaitaiStruct m_parent;
        public byte[] Magic { get { return _magic; } }

        /// <summary>
        /// number of entries in the bigfile
        /// </summary>
        public uint FilesCount { get { return _filesCount; } }
        public CtrBigfile M_Root { get { return m_root; } }
        public KaitaiStruct M_Parent { get { return m_parent; } }
    }
}
