// This is a generated file! Please edit source .ksy file and use kaitai-struct-compiler to rebuild

using Kaitai;

namespace ctr
{

    /// <summary>
    /// Parser for the `dance` and `lose` animations
    /// version 0
    /// </summary>
    public partial class CtrAnimation : KaitaiStruct
    {
        public static CtrAnimation FromFile(string fileName)
        {
            return new CtrAnimation(new KaitaiStream(fileName));
        }

        public CtrAnimation(KaitaiStream p__io, KaitaiStruct p__parent = null, CtrAnimation p__root = null) : base(p__io)
        {
            m_parent = p__parent;
            m_root = p__root ?? this;
            _read();
        }
        private void _read()
        {
            _header = new Header(m_io, this, m_root);
        }
        public partial class Header : KaitaiStruct
        {
            public static Header FromFile(string fileName)
            {
                return new Header(new KaitaiStream(fileName));
            }

            public Header(KaitaiStream p__io, CtrAnimation p__parent = null, CtrAnimation p__root = null) : base(p__io)
            {
                m_parent = p__parent;
                m_root = p__root;
                _read();
            }
            private void _read()
            {
                _contentSize = m_io.ReadU4le();
                _name = System.Text.Encoding.GetEncoding("ASCII").GetString(m_io.ReadBytes(16));
                _unknown1 = m_io.ReadU2le();
                _magic = m_io.EnsureFixedContents(new byte[] { 1, 0 });
                _magic1 = m_io.EnsureFixedContents(new byte[] { 24, 0, 0, 0 });
                _name2 = System.Text.Encoding.GetEncoding("ASCII").GetString(m_io.ReadBytes(16));
                _magic2 = m_io.EnsureFixedContents(new byte[] { 0, 0, 0, 0 });
                _magic3 = m_io.EnsureFixedContents(new byte[] { 32, 78, 0, 0 });
                _unknown2 = m_io.ReadU4le();
                _unknown3 = m_io.ReadU4le();
                _unknown4 = m_io.ReadU4le();
                _magic4 = m_io.EnsureFixedContents(new byte[] { 0, 0, 0, 0 });
                _wx8HeaderEnd = m_io.ReadU4le();
                _unknown6 = m_io.ReadU4le();
                _magic5 = m_io.EnsureFixedContents(new byte[] { 0, 0, 0, 0 });
                _unknown7 = m_io.ReadU4le();
                _unknown8 = m_io.ReadU4le();
                _magic6 = m_io.EnsureFixedContents(new byte[] { 0, 0, 0, 0 });
                _unknown9 = m_io.ReadU4le();
            }
            private uint _contentSize;
            private string _name;
            private ushort _unknown1;
            private byte[] _magic;
            private byte[] _magic1;
            private string _name2;
            private byte[] _magic2;
            private byte[] _magic3;
            private uint _unknown2;
            private uint _unknown3;
            private uint _unknown4;
            private byte[] _magic4;
            private uint _wx8HeaderEnd;
            private uint _unknown6;
            private byte[] _magic5;
            private uint _unknown7;
            private uint _unknown8;
            private byte[] _magic6;
            private uint _unknown9;
            private CtrAnimation m_root;
            private CtrAnimation m_parent;

            /// <summary>
            /// TODO from where to where?
            /// </summary>
            public uint ContentSize { get { return _contentSize; } }
            public string Name { get { return _name; } }
            public ushort Unknown1 { get { return _unknown1; } }
            public byte[] Magic { get { return _magic; } }
            public byte[] Magic1 { get { return _magic1; } }
            public string Name2 { get { return _name2; } }
            public byte[] Magic2 { get { return _magic2; } }
            public byte[] Magic3 { get { return _magic3; } }
            public uint Unknown2 { get { return _unknown2; } }
            public uint Unknown3 { get { return _unknown3; } }
            public uint Unknown4 { get { return _unknown4; } }
            public byte[] Magic4 { get { return _magic4; } }

            /// <summary>
            /// end of WX8 header, points to some 0xffff
            /// </summary>
            public uint Wx8HeaderEnd { get { return _wx8HeaderEnd; } }
            public uint Unknown6 { get { return _unknown6; } }
            public byte[] Magic5 { get { return _magic5; } }

            /// <summary>
            /// xxxx
            /// </summary>
            public uint Unknown7 { get { return _unknown7; } }

            /// <summary>
            /// xxxx
            /// </summary>
            public uint Unknown8 { get { return _unknown8; } }
            public byte[] Magic6 { get { return _magic6; } }

            /// <summary>
            /// xxxx
            /// </summary>
            public uint Unknown9 { get { return _unknown9; } }
            public CtrAnimation M_Root { get { return m_root; } }
            public CtrAnimation M_Parent { get { return m_parent; } }
        }
        private Header _header;
        private CtrAnimation m_root;
        private KaitaiStruct m_parent;
        public Header Header { get { return _header; } }
        public CtrAnimation M_Root { get { return m_root; } }
        public KaitaiStruct M_Parent { get { return m_parent; } }
    }
}
