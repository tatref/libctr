// This is a generated file! Please edit source .ksy file and use kaitai-struct-compiler to rebuild

using Kaitai;
using System.Collections.Generic;

namespace ctr
{

    /// <summary>
    /// Parser for the lang files
    /// version 0.1
    /// </summary>
    public partial class CtrLang : KaitaiStruct
    {
        public static CtrLang FromFile(string fileName)
        {
            return new CtrLang(new KaitaiStream(fileName));
        }

        public CtrLang(KaitaiStream p__io, KaitaiStruct p__parent = null, CtrLang p__root = null) : base(p__io)
        {
            m_parent = p__parent;
            m_root = p__root ?? this;
            f_strings = false;
            f_something = false;
            _read();
        }
        private void _read()
        {
            _stringsCount = m_io.ReadU4le();
            _offset = m_io.ReadU4le();
        }
        private bool f_strings;
        private List<string> _strings;
        public List<string> Strings
        {
            get
            {
                if (f_strings)
                    return _strings;
                long _pos = m_io.Pos;
                m_io.Seek(8);
                _strings = new List<string>((int) (StringsCount));
                for (var i = 0; i < StringsCount; i++)
                {
                    _strings.Add(System.Text.Encoding.GetEncoding("ascii").GetString(m_io.ReadBytesTerm(0, false, true, true)));
                }
                m_io.Seek(_pos);
                f_strings = true;
                return _strings;
            }
        }
        private bool f_something;
        private uint _something;
        public uint Something
        {
            get
            {
                if (f_something)
                    return _something;
                long _pos = m_io.Pos;
                m_io.Seek(Offset);
                _something = m_io.ReadU4le();
                m_io.Seek(_pos);
                f_something = true;
                return _something;
            }
        }
        private uint _stringsCount;
        private uint _offset;
        private CtrLang m_root;
        private KaitaiStruct m_parent;
        public uint StringsCount { get { return _stringsCount; } }
        public uint Offset { get { return _offset; } }
        public CtrLang M_Root { get { return m_root; } }
        public KaitaiStruct M_Parent { get { return m_parent; } }
    }
}
