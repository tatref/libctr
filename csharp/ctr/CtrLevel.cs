// This is a generated file! Please edit source .ksy file and use kaitai-struct-compiler to rebuild

using Kaitai;
using System.Collections.Generic;

namespace ctr
{

    /// <summary>
    /// Parser for CTR levels
    /// Original code https://github.com/DCxDemo/CTR-tools
    /// version 0.1
    /// </summary>
    public partial class CtrLevel : KaitaiStruct
    {
        public static CtrLevel FromFile(string fileName)
        {
            return new CtrLevel(new KaitaiStream(fileName));
        }

        public CtrLevel(KaitaiStream p__io, KaitaiStruct p__parent = null, CtrLevel p__root = null) : base(p__io)
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

            public Header(KaitaiStream p__io, CtrLevel p__parent = null, CtrLevel p__root = null) : base(p__io)
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

                public ObjectEntry(KaitaiStream p__io, CtrLevel.Header p__parent = null, CtrLevel p__root = null) : base(p__io)
                {
                    m_parent = p__parent;
                    m_root = p__root;
                    f_objectInstance = false;
                    _read();
                }
                private void _read()
                {
                    _objectInstancePtr = m_io.ReadU4le();
                }
                public partial class ObjectInstance : KaitaiStruct
                {
                    public static ObjectInstance FromFile(string fileName)
                    {
                        return new ObjectInstance(new KaitaiStream(fileName));
                    }

                    public ObjectInstance(KaitaiStream p__io, CtrLevel.Header.ObjectEntry p__parent = null, CtrLevel p__root = null) : base(p__io)
                    {
                        m_parent = p__parent;
                        m_root = p__root;
                        f_objectMesh = false;
                        _read();
                    }
                    private void _read()
                    {
                        _name = System.Text.Encoding.GetEncoding("ASCII").GetString(KaitaiStream.BytesTerminate(m_io.ReadBytes(16), 0, false));
                        _meshPtr = m_io.ReadU4le();
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
                        _eventType = m_io.ReadU4le();
                    }
                    public partial class Mesh : KaitaiStruct
                    {
                        public static Mesh FromFile(string fileName)
                        {
                            return new Mesh(new KaitaiStream(fileName));
                        }

                        public Mesh(KaitaiStream p__io, CtrLevel.Header.ObjectEntry.ObjectInstance p__parent = null, CtrLevel p__root = null) : base(p__io)
                        {
                            m_parent = p__parent;
                            m_root = p__root;
                            f_tablePtrEnd = false;
                            f_tablePtr = false;
                            _read();
                        }
                        private void _read()
                        {
                            _unknown1 = m_io.ReadU4le();
                            _name = System.Text.Encoding.GetEncoding("ASCII").GetString(KaitaiStream.BytesTerminate(m_io.ReadBytes(16), 0, false));
                            _unknown2 = m_io.ReadU4le();
                            _name2Ptr = m_io.ReadU4le();
                            _name2 = System.Text.Encoding.GetEncoding("ASCII").GetString(KaitaiStream.BytesTerminate(m_io.ReadBytes(16), 0, false));
                            _magic1 = m_io.EnsureFixedContents(new byte[] { 0, 0, 0, 0 });
                            _unknown4 = m_io.ReadBytes(12);
                            _wx8Ptr = m_io.ReadU4le();
                            _unknownPtr1 = m_io.ReadU4le();
                            _unknownTablePtr = m_io.ReadU4le();
                            _unknownPtr3 = m_io.ReadU4le();
                        }
                        private bool f_tablePtrEnd;
                        private uint _tablePtrEnd;
                        public uint TablePtrEnd
                        {
                            get
                            {
                                if (f_tablePtrEnd)
                                    return _tablePtrEnd;
                                long _pos = m_io.Pos;
                                m_io.Seek((UnknownTablePtr + 4));
                                _tablePtrEnd = m_io.ReadU4le();
                                m_io.Seek(_pos);
                                f_tablePtrEnd = true;
                                return _tablePtrEnd;
                            }
                        }
                        private bool f_tablePtr;
                        private List<uint> _tablePtr;

                        /// <summary>
                        /// this can contain a lot of pointers (70 for &quot;c&quot; mesh), or very few (8 for &quot;cactus_short&quot;
                        /// fixme: does not work for &quot;cowskull&quot; (out of bounds)
                        /// </summary>
                        public List<uint> TablePtr
                        {
                            get
                            {
                                if (f_tablePtr)
                                    return _tablePtr;
                                long _pos = m_io.Pos;
                                m_io.Seek((UnknownTablePtr + 4));
                                _tablePtr = new List<uint>();
                                {
                                    var i = 0;
                                    uint M_;
                                    do {
                                        M_ = m_io.ReadU4le();
                                        _tablePtr.Add(M_);
                                        i++;
                                    } while (!(M_Io.Pos > TablePtrEnd));
                                }
                                m_io.Seek(_pos);
                                f_tablePtr = true;
                                return _tablePtr;
                            }
                        }
                        private uint _unknown1;
                        private string _name;
                        private uint _unknown2;
                        private uint _name2Ptr;
                        private string _name2;
                        private byte[] _magic1;
                        private byte[] _unknown4;
                        private uint _wx8Ptr;
                        private uint _unknownPtr1;
                        private uint _unknownTablePtr;
                        private uint _unknownPtr3;
                        private CtrLevel m_root;
                        private CtrLevel.Header.ObjectEntry.ObjectInstance m_parent;
                        public uint Unknown1 { get { return _unknown1; } }
                        public string Name { get { return _name; } }

                        /// <summary>
                        /// always the same for a given type of object
                        /// </summary>
                        public uint Unknown2 { get { return _unknown2; } }

                        /// <summary>
                        /// ptr to name2 + 4
                        /// </summary>
                        public uint Name2Ptr { get { return _name2Ptr; } }
                        public string Name2 { get { return _name2; } }
                        public byte[] Magic1 { get { return _magic1; } }
                        public byte[] Unknown4 { get { return _unknown4; } }

                        /// <summary>
                        /// always the same for a given type of object
                        /// </summary>
                        public uint Wx8Ptr { get { return _wx8Ptr; } }
                        public uint UnknownPtr1 { get { return _unknownPtr1; } }

                        /// <summary>
                        /// pointer to a table of pointers of variable size, see table_ptr instances
                        /// </summary>
                        public uint UnknownTablePtr { get { return _unknownTablePtr; } }
                        public uint UnknownPtr3 { get { return _unknownPtr3; } }
                        public CtrLevel M_Root { get { return m_root; } }
                        public CtrLevel.Header.ObjectEntry.ObjectInstance M_Parent { get { return m_parent; } }
                    }
                    private bool f_objectMesh;
                    private Mesh _objectMesh;
                    public Mesh ObjectMesh
                    {
                        get
                        {
                            if (f_objectMesh)
                                return _objectMesh;
                            long _pos = m_io.Pos;
                            m_io.Seek(MeshPtr);
                            _objectMesh = new Mesh(m_io, this, m_root);
                            m_io.Seek(_pos);
                            f_objectMesh = true;
                            return _objectMesh;
                        }
                    }
                    private string _name;
                    private uint _meshPtr;
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
                    private uint _eventType;
                    private CtrLevel m_root;
                    private CtrLevel.Header.ObjectEntry m_parent;
                    public string Name { get { return _name; } }
                    public uint MeshPtr { get { return _meshPtr; } }
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

                    /// <summary>
                    /// https://github.com/DCxDemo/CTR-tools/blob/master/formats/formats.txt
                    /// </summary>
                    public uint EventType { get { return _eventType; } }
                    public CtrLevel M_Root { get { return m_root; } }
                    public CtrLevel.Header.ObjectEntry M_Parent { get { return m_parent; } }
                }
                private bool f_objectInstance;
                private ObjectInstance _objectInstance;
                public ObjectInstance ObjectInstance
                {
                    get
                    {
                        if (f_objectInstance)
                            return _objectInstance;
                        long _pos = m_io.Pos;
                        m_io.Seek((ObjectInstancePtr + 4));
                        _objectInstance = new ObjectInstance(m_io, this, m_root);
                        m_io.Seek(_pos);
                        f_objectInstance = true;
                        return _objectInstance;
                    }
                }
                private uint _objectInstancePtr;
                private CtrLevel m_root;
                private CtrLevel.Header m_parent;
                public uint ObjectInstancePtr { get { return _objectInstancePtr; } }
                public CtrLevel M_Root { get { return m_root; } }
                public CtrLevel.Header M_Parent { get { return m_parent; } }
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
            private CtrLevel m_root;
            private CtrLevel m_parent;
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
            public CtrLevel M_Root { get { return m_root; } }
            public CtrLevel M_Parent { get { return m_parent; } }
        }
        public partial class InfoHeader : KaitaiStruct
        {
            public static InfoHeader FromFile(string fileName)
            {
                return new InfoHeader(new KaitaiStream(fileName));
            }

            public InfoHeader(KaitaiStream p__io, CtrLevel p__parent = null, CtrLevel p__root = null) : base(p__io)
            {
                m_parent = p__parent;
                m_root = p__root;
                f_vertices = false;
                f_ngons = false;
                _read();
            }
            private void _read()
            {
                _unknown1 = m_io.ReadU4le();
                _facesCount = m_io.ReadS4le();
                _verticesCount = m_io.ReadS4le();
                _unknown2 = m_io.ReadU4le();
                _ngonArrayPtr = m_io.ReadS4le();
                _verticesArrayPtr = m_io.ReadU4le();
                _unknown3 = m_io.ReadU4le();
                _faceArrayPtr = m_io.ReadU4le();
                _faceCountUnknown = m_io.ReadS4le();
            }
            public partial class Vertex : KaitaiStruct
            {
                public static Vertex FromFile(string fileName)
                {
                    return new Vertex(new KaitaiStream(fileName));
                }

                public Vertex(KaitaiStream p__io, CtrLevel.InfoHeader p__parent = null, CtrLevel p__root = null) : base(p__io)
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
                private Vector4u2 _coordinates;
                private Vector4u1 _color1;
                private Vector4u1 _color2;
                private CtrLevel m_root;
                private CtrLevel.InfoHeader m_parent;
                public Vector4u2 Coordinates { get { return _coordinates; } }
                public Vector4u1 Color1 { get { return _color1; } }
                public Vector4u1 Color2 { get { return _color2; } }
                public CtrLevel M_Root { get { return m_root; } }
                public CtrLevel.InfoHeader M_Parent { get { return m_parent; } }
            }
            public partial class Ngon : KaitaiStruct
            {
                public static Ngon FromFile(string fileName)
                {
                    return new Ngon(new KaitaiStream(fileName));
                }

                public Ngon(KaitaiStream p__io, CtrLevel.InfoHeader p__parent = null, CtrLevel p__root = null) : base(p__io)
                {
                    m_parent = p__parent;
                    m_root = p__root;
                    _read();
                }
                private void _read()
                {
                    _faceIndices = new List<short>((int) (9));
                    for (var i = 0; i < 9; i++)
                    {
                        _faceIndices.Add(m_io.ReadS2le());
                    }
                    _data = m_io.ReadBytes(74);
                }
                private List<short> _faceIndices;
                private byte[] _data;
                private CtrLevel m_root;
                private CtrLevel.InfoHeader m_parent;
                public List<short> FaceIndices { get { return _faceIndices; } }
                public byte[] Data { get { return _data; } }
                public CtrLevel M_Root { get { return m_root; } }
                public CtrLevel.InfoHeader M_Parent { get { return m_parent; } }
            }
            public partial class Vector4u2 : KaitaiStruct
            {
                public static Vector4u2 FromFile(string fileName)
                {
                    return new Vector4u2(new KaitaiStream(fileName));
                }

                public Vector4u2(KaitaiStream p__io, CtrLevel.InfoHeader.Vertex p__parent = null, CtrLevel p__root = null) : base(p__io)
                {
                    m_parent = p__parent;
                    m_root = p__root;
                    _read();
                }
                private void _read()
                {
                    _x = m_io.ReadS2le();
                    _y = m_io.ReadS2le();
                    _z = m_io.ReadS2le();
                    _w = m_io.ReadS2le();
                }
                private short _x;
                private short _y;
                private short _z;
                private short _w;
                private CtrLevel m_root;
                private CtrLevel.InfoHeader.Vertex m_parent;
                public short X { get { return _x; } }
                public short Y { get { return _y; } }
                public short Z { get { return _z; } }
                public short W { get { return _w; } }
                public CtrLevel M_Root { get { return m_root; } }
                public CtrLevel.InfoHeader.Vertex M_Parent { get { return m_parent; } }
            }
            public partial class Vector4u1 : KaitaiStruct
            {
                public static Vector4u1 FromFile(string fileName)
                {
                    return new Vector4u1(new KaitaiStream(fileName));
                }

                public Vector4u1(KaitaiStream p__io, CtrLevel.InfoHeader.Vertex p__parent = null, CtrLevel p__root = null) : base(p__io)
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
                private CtrLevel m_root;
                private CtrLevel.InfoHeader.Vertex m_parent;
                public byte X { get { return _x; } }
                public byte Y { get { return _y; } }
                public byte Z { get { return _z; } }
                public byte W { get { return _w; } }
                public CtrLevel M_Root { get { return m_root; } }
                public CtrLevel.InfoHeader.Vertex M_Parent { get { return m_parent; } }
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
                    m_io.Seek((VerticesArrayPtr + 4));
                    _vertices = new List<Vertex>((int) (VerticesCount));
                    for (var i = 0; i < VerticesCount; i++)
                    {
                        _vertices.Add(new Vertex(m_io, this, m_root));
                    }
                    m_io.Seek(_pos);
                    f_vertices = true;
                    return _vertices;
                }
            }
            private bool f_ngons;
            private List<Ngon> _ngons;
            public List<Ngon> Ngons
            {
                get
                {
                    if (f_ngons)
                        return _ngons;
                    long _pos = m_io.Pos;
                    m_io.Seek((NgonArrayPtr + 4));
                    _ngons = new List<Ngon>((int) (FacesCount));
                    for (var i = 0; i < FacesCount; i++)
                    {
                        _ngons.Add(new Ngon(m_io, this, m_root));
                    }
                    m_io.Seek(_pos);
                    f_ngons = true;
                    return _ngons;
                }
            }
            private uint _unknown1;
            private int _facesCount;
            private int _verticesCount;
            private uint _unknown2;
            private int _ngonArrayPtr;
            private uint _verticesArrayPtr;
            private uint _unknown3;
            private uint _faceArrayPtr;
            private int _faceCountUnknown;
            private CtrLevel m_root;
            private CtrLevel m_parent;
            public uint Unknown1 { get { return _unknown1; } }
            public int FacesCount { get { return _facesCount; } }
            public int VerticesCount { get { return _verticesCount; } }
            public uint Unknown2 { get { return _unknown2; } }
            public int NgonArrayPtr { get { return _ngonArrayPtr; } }
            public uint VerticesArrayPtr { get { return _verticesArrayPtr; } }
            public uint Unknown3 { get { return _unknown3; } }
            public uint FaceArrayPtr { get { return _faceArrayPtr; } }
            public int FaceCountUnknown { get { return _faceCountUnknown; } }
            public CtrLevel M_Root { get { return m_root; } }
            public CtrLevel M_Parent { get { return m_parent; } }
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
        private CtrLevel m_root;
        private KaitaiStruct m_parent;
        public Header Header { get { return _header; } }
        public CtrLevel M_Root { get { return m_root; } }
        public KaitaiStruct M_Parent { get { return m_parent; } }
    }
}
