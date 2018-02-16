// This is a generated file! Please edit source .ksy file and use kaitai-struct-compiler to rebuild

using Kaitai;
using System.Collections.Generic;

namespace ctr
{

    /// <summary>
    /// Parser for the CTR models
    /// version 0
    /// Original code https://github.com/DCxDemo/CTR-tools
    /// </summary>
    public partial class CtrModel : KaitaiStruct
    {
        public static CtrModel FromFile(string fileName)
        {
            return new CtrModel(new KaitaiStream(fileName));
        }

        public CtrModel(KaitaiStream p__io, KaitaiStruct p__parent = null, CtrModel p__root = null) : base(p__io)
        {
            m_parent = p__parent;
            m_root = p__root ?? this;
            f_infoHeader = false;
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

            public Header(KaitaiStream p__io, CtrModel p__parent = null, CtrModel p__root = null) : base(p__io)
            {
                m_parent = p__parent;
                m_root = p__root;
                f_objectsIndex = false;
                _read();
            }
            private void _read()
            {
                _size = m_io.ReadU4le();
                _ptrInfoHeader = m_io.ReadU4le();
                _unknown1 = m_io.ReadU4le();
                _unknown2 = m_io.ReadU4le();
                _numPickupHeaders = m_io.ReadS4le();
                _ptrPickupHeaders = m_io.ReadU4le();
                _numPickupModels = m_io.ReadS4le();
                _ptrFacesArray = m_io.ReadU4le();
                _unknown3 = m_io.ReadU4le();
                _unknown4 = m_io.ReadU4le();
                _ptrPickupHeadersPtrArray = m_io.ReadU4le();
                _unknown5 = m_io.ReadU4le();
                _magic1 = m_io.EnsureFixedContents(new byte[] { 0, 0, 0, 0, 0, 0, 0, 0 });
            }
            public partial class ObjectEntry : KaitaiStruct
            {
                public static ObjectEntry FromFile(string fileName)
                {
                    return new ObjectEntry(new KaitaiStream(fileName));
                }

                public ObjectEntry(KaitaiStream p__io, CtrModel.Header p__parent = null, CtrModel p__root = null) : base(p__io)
                {
                    m_parent = p__parent;
                    m_root = p__root;
                    f_obj = false;
                    _read();
                }
                private void _read()
                {
                    _objectPtr = m_io.ReadU4le();
                }
                public partial class Obj : KaitaiStruct
                {
                    public static Obj FromFile(string fileName)
                    {
                        return new Obj(new KaitaiStream(fileName));
                    }

                    public Obj(KaitaiStream p__io, CtrModel.Header.ObjectEntry p__parent = null, CtrModel p__root = null) : base(p__io)
                    {
                        m_parent = p__parent;
                        m_root = p__root;
                        f_xxx = false;
                        _read();
                    }
                    private void _read()
                    {
                        _name = System.Text.Encoding.GetEncoding("ASCII").GetString(m_io.ReadBytes(16));
                        _ptrModel = m_io.ReadU4le();
                        _px = m_io.ReadS2le();
                        _py = m_io.ReadS2le();
                        _pz = m_io.ReadS2le();
                        _p0 = m_io.ReadS2le();
                        _magic1 = m_io.EnsureFixedContents(new byte[] { 0, 0, 0, 0 });
                        _unknown1 = m_io.ReadU4le();
                        _unknown2 = m_io.ReadU4le();
                        _unknown3 = m_io.ReadU4le();
                        _unknown4 = m_io.ReadU4le();
                        _ax = m_io.ReadS2le();
                        _ay = m_io.ReadS2le();
                        _az = m_io.ReadS2le();
                        _bx = m_io.ReadS2le();
                        _by = m_io.ReadS2le();
                        _bz = m_io.ReadS2le();
                        _unknown5 = m_io.ReadU4le();
                    }
                    public partial class TheModel : KaitaiStruct
                    {
                        public static TheModel FromFile(string fileName)
                        {
                            return new TheModel(new KaitaiStream(fileName));
                        }

                        public TheModel(KaitaiStream p__io, CtrModel.Header.ObjectEntry.Obj p__parent = null, CtrModel p__root = null) : base(p__io)
                        {
                            m_parent = p__parent;
                            m_root = p__root;
                            _read();
                        }
                        private void _read()
                        {
                            _size = m_io.ReadU4le();
                            _name = System.Text.Encoding.GetEncoding("ASCII").GetString(m_io.ReadBytes(16));
                        }
                        private uint _size;
                        private string _name;
                        private CtrModel m_root;
                        private CtrModel.Header.ObjectEntry.Obj m_parent;
                        public uint Size { get { return _size; } }
                        public string Name { get { return _name; } }
                        public CtrModel M_Root { get { return m_root; } }
                        public CtrModel.Header.ObjectEntry.Obj M_Parent { get { return m_parent; } }
                    }
                    private bool f_xxx;
                    private TheModel _xxx;
                    public TheModel Xxx
                    {
                        get
                        {
                            if (f_xxx)
                                return _xxx;
                            long _pos = m_io.Pos;
                            m_io.Seek(PtrModel);
                            _xxx = new TheModel(m_io, this, m_root);
                            m_io.Seek(_pos);
                            f_xxx = true;
                            return _xxx;
                        }
                    }
                    private string _name;
                    private uint _ptrModel;
                    private short _px;
                    private short _py;
                    private short _pz;
                    private short _p0;
                    private byte[] _magic1;
                    private uint _unknown1;
                    private uint _unknown2;
                    private uint _unknown3;
                    private uint _unknown4;
                    private short _ax;
                    private short _ay;
                    private short _az;
                    private short _bx;
                    private short _by;
                    private short _bz;
                    private uint _unknown5;
                    private CtrModel m_root;
                    private CtrModel.Header.ObjectEntry m_parent;
                    public string Name { get { return _name; } }
                    public uint PtrModel { get { return _ptrModel; } }
                    public short Px { get { return _px; } }
                    public short Py { get { return _py; } }
                    public short Pz { get { return _pz; } }
                    public short P0 { get { return _p0; } }
                    public byte[] Magic1 { get { return _magic1; } }
                    public uint Unknown1 { get { return _unknown1; } }
                    public uint Unknown2 { get { return _unknown2; } }
                    public uint Unknown3 { get { return _unknown3; } }
                    public uint Unknown4 { get { return _unknown4; } }
                    public short Ax { get { return _ax; } }
                    public short Ay { get { return _ay; } }
                    public short Az { get { return _az; } }
                    public short Bx { get { return _bx; } }
                    public short By { get { return _by; } }
                    public short Bz { get { return _bz; } }
                    public uint Unknown5 { get { return _unknown5; } }
                    public CtrModel M_Root { get { return m_root; } }
                    public CtrModel.Header.ObjectEntry M_Parent { get { return m_parent; } }
                }
                private bool f_obj;
                private Obj _obj;
                public Obj Obj
                {
                    get
                    {
                        if (f_obj)
                            return _obj;
                        long _pos = m_io.Pos;
                        m_io.Seek((ObjectPtr + 4));
                        _obj = new Obj(m_io, this, m_root);
                        m_io.Seek(_pos);
                        f_obj = true;
                        return _obj;
                    }
                }
                private uint _objectPtr;
                private CtrModel m_root;
                private CtrModel.Header m_parent;
                public uint ObjectPtr { get { return _objectPtr; } }
                public CtrModel M_Root { get { return m_root; } }
                public CtrModel.Header M_Parent { get { return m_parent; } }
            }
            private bool f_objectsIndex;
            private List<ObjectEntry> _objectsIndex;
            public List<ObjectEntry> ObjectsIndex
            {
                get
                {
                    if (f_objectsIndex)
                        return _objectsIndex;
                    long _pos = m_io.Pos;
                    m_io.Seek((PtrPickupHeadersPtrArray + 4));
                    _objectsIndex = new List<ObjectEntry>((int) (NumPickupHeaders));
                    for (var i = 0; i < NumPickupHeaders; i++)
                    {
                        _objectsIndex.Add(new ObjectEntry(m_io, this, m_root));
                    }
                    m_io.Seek(_pos);
                    f_objectsIndex = true;
                    return _objectsIndex;
                }
            }
            private uint _size;
            private uint _ptrInfoHeader;
            private uint _unknown1;
            private uint _unknown2;
            private int _numPickupHeaders;
            private uint _ptrPickupHeaders;
            private int _numPickupModels;
            private uint _ptrFacesArray;
            private uint _unknown3;
            private uint _unknown4;
            private uint _ptrPickupHeadersPtrArray;
            private uint _unknown5;
            private byte[] _magic1;
            private CtrModel m_root;
            private CtrModel m_parent;
            public uint Size { get { return _size; } }
            public uint PtrInfoHeader { get { return _ptrInfoHeader; } }
            public uint Unknown1 { get { return _unknown1; } }
            public uint Unknown2 { get { return _unknown2; } }
            public int NumPickupHeaders { get { return _numPickupHeaders; } }
            public uint PtrPickupHeaders { get { return _ptrPickupHeaders; } }
            public int NumPickupModels { get { return _numPickupModels; } }
            public uint PtrFacesArray { get { return _ptrFacesArray; } }
            public uint Unknown3 { get { return _unknown3; } }
            public uint Unknown4 { get { return _unknown4; } }
            public uint PtrPickupHeadersPtrArray { get { return _ptrPickupHeadersPtrArray; } }
            public uint Unknown5 { get { return _unknown5; } }
            public byte[] Magic1 { get { return _magic1; } }
            public CtrModel M_Root { get { return m_root; } }
            public CtrModel M_Parent { get { return m_parent; } }
        }
        public partial class InfoHeader : KaitaiStruct
        {
            public static InfoHeader FromFile(string fileName)
            {
                return new InfoHeader(new KaitaiStream(fileName));
            }

            public InfoHeader(KaitaiStream p__io, CtrModel p__parent = null, CtrModel p__root = null) : base(p__io)
            {
                m_parent = p__parent;
                m_root = p__root;
                f_vertices = false;
                _read();
            }
            private void _read()
            {
                _unknown1 = m_io.ReadU4le();
                _facesNum = m_io.ReadS4le();
                _vertexNum = m_io.ReadS4le();
                _unknown2 = m_io.ReadU4le();
                _ptrNgonArray = m_io.ReadS4le();
                _ptrVertArray = m_io.ReadU4le();
                _unknown3 = m_io.ReadU4le();
                _ptrFaceArray = m_io.ReadU4le();
                _faceNum = m_io.ReadS4le();
            }
            public partial class Vertex : KaitaiStruct
            {
                public static Vertex FromFile(string fileName)
                {
                    return new Vertex(new KaitaiStream(fileName));
                }

                public Vertex(KaitaiStream p__io, CtrModel.InfoHeader p__parent = null, CtrModel p__root = null) : base(p__io)
                {
                    m_parent = p__parent;
                    m_root = p__root;
                    _read();
                }
                private void _read()
                {
                    _coordinates = new Vector4u2(m_io, this, m_root);
                    _color1 = new Vector4u1(m_io, this, m_root);
                    _color2 = new Vector4u1(m_io, this, m_root);
                }
                public partial class Vector4u2 : KaitaiStruct
                {
                    public static Vector4u2 FromFile(string fileName)
                    {
                        return new Vector4u2(new KaitaiStream(fileName));
                    }

                    public Vector4u2(KaitaiStream p__io, CtrModel.InfoHeader.Vertex p__parent = null, CtrModel p__root = null) : base(p__io)
                    {
                        m_parent = p__parent;
                        m_root = p__root;
                        _read();
                    }
                    private void _read()
                    {
                        _x = m_io.ReadU2le();
                        _y = m_io.ReadU2le();
                        _z = m_io.ReadU2le();
                        _w = m_io.ReadU2le();
                    }
                    private ushort _x;
                    private ushort _y;
                    private ushort _z;
                    private ushort _w;
                    private CtrModel m_root;
                    private CtrModel.InfoHeader.Vertex m_parent;
                    public ushort X { get { return _x; } }
                    public ushort Y { get { return _y; } }
                    public ushort Z { get { return _z; } }
                    public ushort W { get { return _w; } }
                    public CtrModel M_Root { get { return m_root; } }
                    public CtrModel.InfoHeader.Vertex M_Parent { get { return m_parent; } }
                }
                public partial class Vector4u1 : KaitaiStruct
                {
                    public static Vector4u1 FromFile(string fileName)
                    {
                        return new Vector4u1(new KaitaiStream(fileName));
                    }

                    public Vector4u1(KaitaiStream p__io, CtrModel.InfoHeader.Vertex p__parent = null, CtrModel p__root = null) : base(p__io)
                    {
                        m_parent = p__parent;
                        m_root = p__root;
                        _read();
                    }
                    private void _read()
                    {
                        _x = m_io.ReadU1();
                        _y = m_io.ReadU1();
                        _z = m_io.ReadU1();
                        _w = m_io.ReadU1();
                    }
                    private byte _x;
                    private byte _y;
                    private byte _z;
                    private byte _w;
                    private CtrModel m_root;
                    private CtrModel.InfoHeader.Vertex m_parent;
                    public byte X { get { return _x; } }
                    public byte Y { get { return _y; } }
                    public byte Z { get { return _z; } }
                    public byte W { get { return _w; } }
                    public CtrModel M_Root { get { return m_root; } }
                    public CtrModel.InfoHeader.Vertex M_Parent { get { return m_parent; } }
                }
                private Vector4u2 _coordinates;
                private Vector4u1 _color1;
                private Vector4u1 _color2;
                private CtrModel m_root;
                private CtrModel.InfoHeader m_parent;
                public Vector4u2 Coordinates { get { return _coordinates; } }
                public Vector4u1 Color1 { get { return _color1; } }

                /// <summary>
                /// ???
                /// </summary>
                public Vector4u1 Color2 { get { return _color2; } }
                public CtrModel M_Root { get { return m_root; } }
                public CtrModel.InfoHeader M_Parent { get { return m_parent; } }
            }
            private bool f_vertices;
            private List<Vertex> _vertices;
            public List<Vertex> Vertices
            {
                get
                {
                    if (f_vertices)
                        return _vertices;
                    long _pos = m_io.Pos;
                    m_io.Seek(PtrVertArray);
                    _vertices = new List<Vertex>((int) (VertexNum));
                    for (var i = 0; i < VertexNum; i++)
                    {
                        _vertices.Add(new Vertex(m_io, this, m_root));
                    }
                    m_io.Seek(_pos);
                    f_vertices = true;
                    return _vertices;
                }
            }
            private uint _unknown1;
            private int _facesNum;
            private int _vertexNum;
            private uint _unknown2;
            private int _ptrNgonArray;
            private uint _ptrVertArray;
            private uint _unknown3;
            private uint _ptrFaceArray;
            private int _faceNum;
            private CtrModel m_root;
            private CtrModel m_parent;
            public uint Unknown1 { get { return _unknown1; } }
            public int FacesNum { get { return _facesNum; } }
            public int VertexNum { get { return _vertexNum; } }
            public uint Unknown2 { get { return _unknown2; } }
            public int PtrNgonArray { get { return _ptrNgonArray; } }
            public uint PtrVertArray { get { return _ptrVertArray; } }
            public uint Unknown3 { get { return _unknown3; } }
            public uint PtrFaceArray { get { return _ptrFaceArray; } }
            public int FaceNum { get { return _faceNum; } }
            public CtrModel M_Root { get { return m_root; } }
            public CtrModel M_Parent { get { return m_parent; } }
        }
        private bool f_infoHeader;
        private InfoHeader _infoHeader;
        public InfoHeader InfoHeader
        {
            get
            {
                if (f_infoHeader)
                    return _infoHeader;
                long _pos = m_io.Pos;
                m_io.Seek(Header.PtrInfoHeader);
                _infoHeader = new InfoHeader(m_io, this, m_root);
                m_io.Seek(_pos);
                f_infoHeader = true;
                return _infoHeader;
            }
        }
        private Header _header;
        private CtrModel m_root;
        private KaitaiStruct m_parent;
        public Header Header { get { return _header; } }
        public CtrModel M_Root { get { return m_root; } }
        public KaitaiStruct M_Parent { get { return m_parent; } }
    }
}
