// This is a generated file! Please edit source .ksy file and use kaitai-struct-compiler to rebuild

using Kaitai;

namespace ctr
{

    /// <summary>
    /// Parser for the CTR characters
    /// version 0
    /// </summary>
    public partial class CtrCharacter : KaitaiStruct
    {
        public static CtrCharacter FromFile(string fileName)
        {
            return new CtrCharacter(new KaitaiStream(fileName));
        }

        public CtrCharacter(KaitaiStream p__io, KaitaiStruct p__parent = null, CtrCharacter p__root = null) : base(p__io)
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

            public Header(KaitaiStream p__io, CtrCharacter p__parent = null, CtrCharacter p__root = null) : base(p__io)
            {
                m_parent = p__parent;
                m_root = p__root;
                f_animation1 = false;
                f_animation2 = false;
                f_animation3 = false;
                f_animation4 = false;
                _read();
            }
            private void _read()
            {
                _size = m_io.ReadU4le();
                _name = System.Text.Encoding.GetEncoding("ASCII").GetString(KaitaiStream.BytesTerminate(m_io.ReadBytes(16), 0, false));
                _unknown1 = m_io.ReadBytes(136);
                _animation1Ptr = m_io.ReadU4le();
                _animation2Ptr = m_io.ReadU4le();
                _animation3Ptr = m_io.ReadU4le();
                _animation4Ptr = m_io.ReadU4le();
            }
            public partial class Animation : KaitaiStruct
            {
                public static Animation FromFile(string fileName)
                {
                    return new Animation(new KaitaiStream(fileName));
                }

                public Animation(KaitaiStream p__io, CtrCharacter.Header p__parent = null, CtrCharacter p__root = null) : base(p__io)
                {
                    m_parent = p__parent;
                    m_root = p__root;
                    _read();
                }
                private void _read()
                {
                    _unknown1 = m_io.ReadU4le();
                    _name = System.Text.Encoding.GetEncoding("ASCII").GetString(KaitaiStream.BytesTerminate(m_io.ReadBytes(16), 0, false));
                }
                private uint _unknown1;
                private string _name;
                private CtrCharacter m_root;
                private CtrCharacter.Header m_parent;
                public uint Unknown1 { get { return _unknown1; } }
                public string Name { get { return _name; } }
                public CtrCharacter M_Root { get { return m_root; } }
                public CtrCharacter.Header M_Parent { get { return m_parent; } }
            }
            private bool f_animation1;
            private Animation _animation1;
            public Animation Animation1
            {
                get
                {
                    if (f_animation1)
                        return _animation1;
                    long _pos = m_io.Pos;
                    m_io.Seek(Animation1Ptr);
                    _animation1 = new Animation(m_io, this, m_root);
                    m_io.Seek(_pos);
                    f_animation1 = true;
                    return _animation1;
                }
            }
            private bool f_animation2;
            private Animation _animation2;
            public Animation Animation2
            {
                get
                {
                    if (f_animation2)
                        return _animation2;
                    long _pos = m_io.Pos;
                    m_io.Seek(Animation2Ptr);
                    _animation2 = new Animation(m_io, this, m_root);
                    m_io.Seek(_pos);
                    f_animation2 = true;
                    return _animation2;
                }
            }
            private bool f_animation3;
            private Animation _animation3;
            public Animation Animation3
            {
                get
                {
                    if (f_animation3)
                        return _animation3;
                    long _pos = m_io.Pos;
                    m_io.Seek(Animation3Ptr);
                    _animation3 = new Animation(m_io, this, m_root);
                    m_io.Seek(_pos);
                    f_animation3 = true;
                    return _animation3;
                }
            }
            private bool f_animation4;
            private Animation _animation4;
            public Animation Animation4
            {
                get
                {
                    if (f_animation4)
                        return _animation4;
                    long _pos = m_io.Pos;
                    m_io.Seek(Animation4Ptr);
                    _animation4 = new Animation(m_io, this, m_root);
                    m_io.Seek(_pos);
                    f_animation4 = true;
                    return _animation4;
                }
            }
            private uint _size;
            private string _name;
            private byte[] _unknown1;
            private uint _animation1Ptr;
            private uint _animation2Ptr;
            private uint _animation3Ptr;
            private uint _animation4Ptr;
            private CtrCharacter m_root;
            private CtrCharacter m_parent;
            public uint Size { get { return _size; } }
            public string Name { get { return _name; } }
            public byte[] Unknown1 { get { return _unknown1; } }
            public uint Animation1Ptr { get { return _animation1Ptr; } }
            public uint Animation2Ptr { get { return _animation2Ptr; } }
            public uint Animation3Ptr { get { return _animation3Ptr; } }
            public uint Animation4Ptr { get { return _animation4Ptr; } }
            public CtrCharacter M_Root { get { return m_root; } }
            public CtrCharacter M_Parent { get { return m_parent; } }
        }
        private Header _header;
        private CtrCharacter m_root;
        private KaitaiStruct m_parent;
        public Header Header { get { return _header; } }
        public CtrCharacter M_Root { get { return m_root; } }
        public KaitaiStruct M_Parent { get { return m_parent; } }
    }
}
