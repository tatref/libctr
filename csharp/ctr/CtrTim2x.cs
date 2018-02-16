// This is a generated file! Please edit source .ksy file and use kaitai-struct-compiler to rebuild

using Kaitai;

namespace ctr
{

    /// <summary>
    /// tim2x contains 2 TIMs in a row
    /// version 0
    /// </summary>
    public partial class CtrTim2x : KaitaiStruct
    {
        public static CtrTim2x FromFile(string fileName)
        {
            return new CtrTim2x(new KaitaiStream(fileName));
        }

        public CtrTim2x(KaitaiStream p__io, KaitaiStruct p__parent = null, CtrTim2x p__root = null) : base(p__io)
        {
            m_parent = p__parent;
            m_root = p__root ?? this;
            _read();
        }
        private void _read()
        {
            _magic = m_io.EnsureFixedContents(new byte[] { 32, 0, 0, 0 });
            _tim1Size = m_io.ReadU4le();
            _tim1 = new PsxTim(m_io);
            _tim2Size = m_io.ReadU4le();
            _tim2 = new PsxTim(m_io);
        }
        private byte[] _magic;
        private uint _tim1Size;
        private PsxTim _tim1;
        private uint _tim2Size;
        private PsxTim _tim2;
        private CtrTim2x m_root;
        private KaitaiStruct m_parent;
        public byte[] Magic { get { return _magic; } }
        public uint Tim1Size { get { return _tim1Size; } }
        public PsxTim Tim1 { get { return _tim1; } }
        public uint Tim2Size { get { return _tim2Size; } }
        public PsxTim Tim2 { get { return _tim2; } }
        public CtrTim2x M_Root { get { return m_root; } }
        public KaitaiStruct M_Parent { get { return m_parent; } }
    }
}
