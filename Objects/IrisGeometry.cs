using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;

namespace IrisLib
{
    /// <summary>
    /// Class to store geometry information.
    /// </summary>
    public class IrisGeometry : IrisElement, IEquatable<IrisGeometry>
    {
        /// <summary>
        /// Flag for vertex colors.
        /// </summary>
        [JsonIgnore]
        public int VertexColors { get; private set; }

        /// <summary>
        /// Geometry data.
        /// </summary>
        [JsonProperty("data")]
        public IrisGeometryData Data { get; private set; }

        /// <summary>
        /// Base constructor for IrisGeometry.
        /// </summary>
        public IrisGeometry()
        {
            Type = "Geometry";
        }

        /// <summary>
        /// Constructor for IrisGeometry which takes vertices and other parameters to construct a variety of objects.
        /// </summary>
        /// <param name="_vertices"></param>
        /// <param name="_normals"></param>
        /// <param name="_textureCoordinates"></param>
        /// <param name="_faces"></param>
        /// <param name="_colors"></param>
        /// <param name="includeNormals"></param>
        public IrisGeometry(List<float[]> _vertices = null, List<float[]> _normals = null, List<float[]> _textureCoordinates = null, List<int[]> _faces = null, List<int> _colors = null, bool includeNormals = false):this()
        {
            IrisGeometryFace face = new IrisGeometryFace
            {
                Topology = false,
                VertexColors = false,
                FaceColor = false,
                FaceMaterial = false,
                FaceNormals = false,
                FaceUVs = false,
                FaceVertexUVs = false,
                VertexNormals = true
            };

            List<float> vertices = new List<float>();

            foreach (var vertex in _vertices)
            {
                vertices.Add(float.Parse($"{vertex[0]:0.000000}"));
                vertices.Add(float.Parse($"{vertex[1]:0.000000}"));
                vertices.Add(float.Parse($"{vertex[2]:0.000000}"));
            }

            List<object> normals = new List<object>();

            if(_normals != null)
                foreach (var normal in _normals)
                {

                    if (includeNormals)
                    {

                        //floating point normals with two significant digits of precision [-1.00, 1.00]
                        //resolution of 201 possibilities.

                        var x = float.Parse($"{normal[0]:0.00}"); //x
                        var y = float.Parse($"{normal[1]:0.00}"); //y
                        var z = float.Parse($"{normal[2]:0.00}"); //z

                        if (x == 0 || x == 1 || x == -1)
                        {
                            normals.Add(Convert.ToInt16(x));
                        }
                        else
                        {
                            normals.Add(float.Parse($"{x:.00}"));
                        }

                        if (y == 0 || y == 1 || y == -1)
                        {
                            normals.Add(Convert.ToInt16(y));
                        }
                        else
                        {
                            normals.Add(float.Parse($"{y:.00}"));
                        }

                        if (z == 0 || z == 1 || z == -1)
                        {
                            normals.Add(Convert.ToInt16(z));
                        }
                        else
                        {
                            normals.Add(float.Parse($"{z:.00}"));
                        }

                        //normals.Add(float.Parse($"{normal.X:0.00}"));
                        //normals.Add(float.Parse($"{normal.Y:0.00}"));
                        //normals.Add(float.Parse($"{normal.Z:0.00}"));

                        //signed integer encoded normals from [-127,127]
                        //resolution of 255 possibilities
                        //normals.Add(IrisMethods.EncodeFloat(normal.X));
                        //normals.Add(IrisMethods.EncodeFloat(normal.Y));
                        //normals.Add(IrisMethods.EncodeFloat(normal.Z));

                    }
                }

            List<float> uv = new List<float>();

            List<List<float>> uvs = new List<List<float>>();

            if (_textureCoordinates != null && _textureCoordinates.Count > 0)
            {
                face.FaceVertexUVs = true;
                foreach (var textureCoordinate in _textureCoordinates)
                {
                    uv.Add(float.Parse($"{textureCoordinate[0]:0.000000}")); //u
                    uv.Add(float.Parse($"{textureCoordinate[1]:0.000000}")); //v
                }

            }
            uvs.Add(uv);

            List<int> colors = new List<int>();

            if (_colors != null && _colors.Count > 0)
            {
                VertexColors = 2;
                face.VertexColors = true;
                
            }

            colors = _colors;

            List<int> facesIndex = new List<int>();

            if(_faces != null)
                foreach (var meshFace in _faces)
                {
                    if (meshFace.Length == 3)//has count 3
                    {

                        face.Topology = false;

                        facesIndex.Add(face.GetFaceType());

                        facesIndex.Add(meshFace[0]); //A
                        facesIndex.Add(meshFace[1]); //B
                        facesIndex.Add(meshFace[2]); //C

                        if (face.VertexNormals)
                        {
                            facesIndex.Add(meshFace[0]); //A
                            facesIndex.Add(meshFace[1]); //B
                            facesIndex.Add(meshFace[2]); //C
                        }

                        if (face.VertexColors)
                        {
                            facesIndex.Add(meshFace[0]); //A
                            facesIndex.Add(meshFace[1]); //B
                            facesIndex.Add(meshFace[2]); //C
                        }

                        if (face.FaceVertexUVs)
                        {
                            facesIndex.Add(meshFace[0]); //A
                            facesIndex.Add(meshFace[1]); //B
                            facesIndex.Add(meshFace[2]); //C
                        }
                    }
                    else
                    {

                        face.Topology = true;

                        facesIndex.Add(face.GetFaceType());

                        facesIndex.Add(meshFace[0]); //A
                        facesIndex.Add(meshFace[1]); //B
                        facesIndex.Add(meshFace[2]); //C
                        facesIndex.Add(meshFace[3]); //D

                        if (face.VertexNormals)
                        {

                            facesIndex.Add(meshFace[0]); //A
                            facesIndex.Add(meshFace[1]); //B
                            facesIndex.Add(meshFace[2]); //C
                            facesIndex.Add(meshFace[3]); //D
                        }

                        if (face.VertexColors)
                        {
                            facesIndex.Add(meshFace[0]); //A
                            facesIndex.Add(meshFace[1]); //B
                            facesIndex.Add(meshFace[2]); //C
                            facesIndex.Add(meshFace[3]); //D
                        }

                        if (face.FaceVertexUVs)
                        {
                            facesIndex.Add(meshFace[0]); //A
                            facesIndex.Add(meshFace[1]); //B
                            facesIndex.Add(meshFace[2]); //C
                            facesIndex.Add(meshFace[3]); //D
                        }
                    }

                }

            Data = new IrisGeometryData
            {
                Vertices = vertices,
                Normals = normals,
                Uvs = uvs,
                Colors = colors,
                Faces = facesIndex
            };

        }

        /// <summary>
        /// Check if one IrisGeometry equals another.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(IrisGeometry other)
        {
            if (other == null)
            {
                return false;
            }
            else
            {

                return Type.Equals(other.Type) &&
                       Data.Colors.SequenceEqual(other.Data.Colors) &&
                       Data.Faces.SequenceEqual(other.Data.Faces) &&
                       Data.Normals.SequenceEqual(other.Data.Normals) &&
                       Data.Uvs[0].SequenceEqual(other.Data.Uvs[0]) &&
                       Data.Vertices.SequenceEqual(other.Data.Vertices);
            }
        }
    }

    /// <summary>
    /// Geometry data.
    /// </summary>
    public class IrisGeometryData
    {
        /// <summary>
        /// The list of vertices associated with this geometry.
        /// </summary>
        [JsonProperty("vertices")]
        public IList<float> Vertices { get; set; }

        /// <summary>
        /// The list of normals associated with this geometry.
        /// </summary>
        [JsonProperty("normals")]
        public IList<object> Normals { get; set; }

        /// <summary>
        /// The list of UVs associated with this geometry.
        /// </summary>
        [JsonProperty("uvs")]
        public List<List<float>> Uvs { get; set; }

        /// <summary>
        /// The list of colors associated with this geometry.
        /// </summary>
        [JsonProperty("colors")]
        public IList<int> Colors { get; set; }

        /// <summary>
        /// The faces associated with this geometry.
        /// </summary>
        [JsonProperty("faces")]
        public IList<int> Faces { get; set; }
    }

    /// <summary>
    /// Class for storing geometry face data.
    /// </summary>
    public class IrisGeometryFace
    {
        /// <summary>
        /// False for triangle, true for quad.
        /// </summary>
        public bool Topology { get; set; } //false for triangle, true for quad

        /// <summary>
        /// 
        /// </summary>
        public bool FaceMaterial { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool FaceUVs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool FaceVertexUVs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool FaceNormals { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool VertexNormals { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool FaceColor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool VertexColors { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte GetFaceType()
        {
            bool[] faceBits = new bool[] { Topology, FaceMaterial, FaceUVs, FaceVertexUVs,
                                           FaceNormals, VertexNormals, FaceColor, VertexColors };
            System.Collections.BitArray bits = new System.Collections.BitArray(faceBits);

            byte b = 0;
            if (bits.Get(0)) b++;
            if (bits.Get(1)) b += 2;
            if (bits.Get(2)) b += 4;
            if (bits.Get(3)) b += 8;
            if (bits.Get(4)) b += 16;
            if (bits.Get(5)) b += 32;
            if (bits.Get(6)) b += 64;
            if (bits.Get(7)) b += 128;
            return b;
        }
    }

    /// <summary>
    /// Simple collection class for creating lists of IrisGeometry.
    /// </summary>
    public class IrisGeometryCollection : Collection<IrisGeometry>
    {
        /// <summary>
        /// Add a geometry to this collection if it does not already exist.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Guid AddIfNew(IrisGeometry item)
        {
            var q = from a in this
                    where a.Equals(item)
                    select a.Uuid;

            var enumerable = q as Guid[] ?? q.ToArray();
            if (!enumerable.Any())
            {
                Add(item);
                return item.Uuid;
            }
            else
            {
                return enumerable.Single();
            }
        }
    }

    //public class IrisGeometryComparer : IEqualityComparer<IrisGeometry> 
    //{

    //    public bool Equals(IrisGeometry x, IrisGeometry y)
    //    {
    //        //Check whether the objects are the same object. 
    //        if (Object.ReferenceEquals(x, y)) return true;

    //        //Check whether the products' properties are equal. 
    //        return x != null && y != null && 
    //            x.Type.Equals(y.Type) &&
    //            x.Data.Colors.SequenceEqual(y.Data.Colors) &&
    //            x.Data.Faces.SequenceEqual(y.Data.Faces) &&
    //            x.Data.Normals.SequenceEqual(y.Data.Normals) &&
    //            x.Data.Uvs.SequenceEqual(y.Data.Uvs) &&
    //            x.Data.Vertices.SequenceEqual(y.Data.Vertices);
    //    }

    //    public int GetHashCode(IrisGeometry obj)
    //    {
    //        //throw new NotImplementedException();

    //        //Get hash code for the Name field if it is not null. 
    //        int hashType = obj.Type == null ? 0 : obj.Type.GetHashCode();

    //        int hashColors = obj.Data.Colors.GetHashCode();
    //        int hashFaces = obj.Data.Faces.GetHashCode();
    //        int hashNormals = obj.Data.Normals.GetHashCode();
    //        int hashUvs = obj.Data.Uvs.GetHashCode();
    //        int hashVertices = obj.Data.Vertices.GetHashCode();

    //        //Calculate the hash code for the product. 
    //        return hashType ^ hashColors ^ hashFaces ^ hashNormals ^ hashUvs ^ hashVertices;
    //    }
    //}

}
