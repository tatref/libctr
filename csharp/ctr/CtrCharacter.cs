// This is a generated file! Please edit source .ksy file and use kaitai-struct-compiler to rebuild

using Kaitai;
using System.Collections.Generic;

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
            f_animationsIndex = false;
            _read();
        }
        private void _read()
        {
            _size = m_io.ReadU4le();
            _name = System.Text.Encoding.GetEncoding("ASCII").GetString(KaitaiStream.BytesTerminate(m_io.ReadBytes(16), 0, false));
            _unknown1 = m_io.ReadBytes(8);
            _name2 = System.Text.Encoding.GetEncoding("ASCII").GetString(KaitaiStream.BytesTerminate(m_io.ReadBytes(16), 0, false));
            _magic1 = m_io.EnsureFixedContents(new byte[] { 0, 0, 0, 0 });
            _unknown2 = m_io.ReadBytes(32);
            _animationsCount = m_io.ReadU4le();
            _animationsTablePtr = m_io.ReadU4le();
            _unknown3 = m_io.ReadBytes(52);
        }
        public partial class AnimationEntry : KaitaiStruct
        {
            public static AnimationEntry FromFile(string fileName)
            {
                return new AnimationEntry(new KaitaiStream(fileName));
            }

            public AnimationEntry(KaitaiStream p__io, CtrCharacter p__parent = null, CtrCharacter p__root = null) : base(p__io)
            {
                m_parent = p__parent;
                m_root = p__root;
                f_animation = false;
                _read();
            }
            private void _read()
            {
                _animationPtr = m_io.ReadU4le();
            }
            public partial class Anim : KaitaiStruct
            {
                public static Anim FromFile(string fileName)
                {
                    return new Anim(new KaitaiStream(fileName));
                }

                public Anim(KaitaiStream p__io, CtrCharacter.AnimationEntry p__parent = null, CtrCharacter p__root = null) : base(p__io)
                {
                    m_parent = p__parent;
                    m_root = p__root;
                    _read();
                }
                private void _read()
                {
                    _unknown1 = m_io.ReadU4le();
                    _animationName = System.Text.Encoding.GetEncoding("ASCII").GetString(KaitaiStream.BytesTerminate(m_io.ReadBytes(16), 0, false));
                    _unknown2 = m_io.ReadU4le();
                    _unknown3 = m_io.ReadU4le();
                }
                private uint _unknown1;
                private string _animationName;
                private uint _unknown2;
                private uint _unknown3;
                private CtrCharacter m_root;
                private CtrCharacter.AnimationEntry m_parent;
                public uint Unknown1 { get { return _unknown1; } }
                public string AnimationName { get { return _animationName; } }
                public uint Unknown2 { get { return _unknown2; } }
                public uint Unknown3 { get { return _unknown3; } }
                public CtrCharacter M_Root { get { return m_root; } }
                public CtrCharacter.AnimationEntry M_Parent { get { return m_parent; } }
            }
            private bool f_animation;
            private Anim _animation;
            public Anim Animation
            {
                get
                {
                    if (f_animation)
                        return _animation;
                    long _pos = m_io.Pos;
                    m_io.Seek(AnimationPtr);
                    _animation = new Anim(m_io, this, m_root);
                    m_io.Seek(_pos);
                    f_animation = true;
                    return _animation;
                }
            }
            private uint _animationPtr;
            private CtrCharacter m_root;
            private CtrCharacter m_parent;
            public uint AnimationPtr { get { return _animationPtr; } }
            public CtrCharacter M_Root { get { return m_root; } }
            public CtrCharacter M_Parent { get { return m_parent; } }
        }
        private bool f_animationsIndex;
        private List<AnimationEntry> _animationsIndex;
        public List<AnimationEntry> AnimationsIndex
        {
            get
            {
                if (f_animationsIndex)
                    return _animationsIndex;
                long _pos = m_io.Pos;
                m_io.Seek((AnimationsTablePtr + 4));
                _animationsIndex = new List<AnimationEntry>((int) (AnimationsCount));
                for (var i = 0; i < AnimationsCount; i++)
                {
                    _animationsIndex.Add(new AnimationEntry(m_io, this, m_root));
                }
                m_io.Seek(_pos);
                f_animationsIndex = true;
                return _animationsIndex;
            }
        }
        private uint _size;
        private string _name;
        private byte[] _unknown1;
        private string _name2;
        private byte[] _magic1;
        private byte[] _unknown2;
        private uint _animationsCount;
        private uint _animationsTablePtr;
        private byte[] _unknown3;
        private CtrCharacter m_root;
        private KaitaiStruct m_parent;
        public uint Size { get { return _size; } }
        public string Name { get { return _name; } }
        public byte[] Unknown1 { get { return _unknown1; } }
        public string Name2 { get { return _name2; } }
        public byte[] Magic1 { get { return _magic1; } }
        public byte[] Unknown2 { get { return _unknown2; } }
        public uint AnimationsCount { get { return _animationsCount; } }
        public uint AnimationsTablePtr { get { return _animationsTablePtr; } }
        public byte[] Unknown3 { get { return _unknown3; } }
        public CtrCharacter M_Root { get { return m_root; } }
        public KaitaiStruct M_Parent { get { return m_parent; } }
    }
}
