using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;

namespace IrisLib
{
    /// <summary>
    /// Class for Buffer Geometry.
    /// </summary>
    public class IrisGeometryBuffer : IrisElement
    {
        /// <summary>
        /// The attributes for Buffer Geometry
        /// </summary>
        [JsonProperty("data")]
        public IrisBufferGeometryData Data { get; private set; }

        /// <summary>
        /// Constructor for Buffer Geometry
        /// </summary>
        public IrisGeometryBuffer()
        {
            Type = "BufferGeometry";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <param name="color"></param>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        public IrisGeometryBuffer(double[] point, Color color, double[] center, double radius):this(new List<double[]> { { point } }, new List<Color> { { color } }, center, radius)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="points"></param>
        /// <param name="colors"></param>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        public IrisGeometryBuffer(List<double[]> points, List<Color> colors, double[] center, double radius) : this()
        {
            var vertices = new List<float>();

            foreach (var point in points)
            {
                vertices.Add(float.Parse($"{point[0]:0.000000}"));
                vertices.Add(float.Parse($"{point[1]:0.000000}"));
                vertices.Add(float.Parse($"{point[2]:0.000000}"));
            }

            var colorList = new List<float>();

            foreach (Color color in colors)
            {
                colorList.Add(color.R / 255.0f);
                colorList.Add(color.G / 255.0f);
                colorList.Add(color.B / 255.0f);
            }

            var boundingSphere = new IrisBufferGeometryDataBoundingSphere
            {
                Center = center,
                Radius = radius
            };

            var attributes = new IrisBufferGeometryPointDataAttributes
            {
                Position = new IrisBufferGeometryArrayAttribute(3, "Float32Array")
                {
                    Array = vertices
                },

                Color = new IrisBufferGeometryArrayAttribute(3, "Float32Array")
                {
                    Array = colorList
                }

            };

            Data = new IrisBufferGeometryData
            {
                Attributes = attributes,
                BoundingSphere = boundingSphere
            };

        }

    }

    /// <summary>
    /// 
    /// </summary>
    public class IrisBufferGeometryData
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("attributes")]
        public IIrisBufferGeometryDataAttributes Attributes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("boundingSphere")]
        public IrisBufferGeometryDataBoundingSphere BoundingSphere { get; set; }

    }

    /// <summary>
    /// 
    /// </summary>
    public interface IIrisBufferGeometryDataAttributes { }

    /// <summary>
    /// 
    /// </summary>
    public class IrisBufferGeometryDataAttributes : IIrisBufferGeometryDataAttributes
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("position")]
        public IrisBufferGeometryArrayAttribute Position { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("normal")]
        public IrisBufferGeometryArrayAttribute Normal { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("color")]
        public IrisBufferGeometryArrayAttribute Color { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("uv")]
        public IrisBufferGeometryArrayAttribute UV { get; set; }

    }

    /// <summary>
    /// 
    /// </summary>
    public class IrisBufferGeometryPointDataAttributes : IIrisBufferGeometryDataAttributes
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("position")]
        public IrisBufferGeometryArrayAttribute Position { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("color")]
        public IrisBufferGeometryArrayAttribute Color { get; set; }

    }

    /// <summary>
    /// 
    /// </summary>
    public class IrisBufferGeometryAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("itemSize", Order = -2)]
        public int ItemSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("type", Order = -2)]
        public string Type { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class IrisBufferGeometryArrayAttribute : IrisBufferGeometryAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("array")]
        public List<float> Array { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="size"></param>
        /// <param name="type"></param>
        public IrisBufferGeometryArrayAttribute(int size, string type)
        {
            ItemSize = size;
            Type = "Float32Array";
        }

    }

    /// <summary>
    /// Data for the bounding sphere.
    /// </summary>
    public class IrisBufferGeometryDataBoundingSphere
    {
        /// <summary>
        /// Center position of the bounding sphere.
        /// </summary>
        [JsonProperty("center")]
        public double[] Center { get; set; }

        /// <summary>
        /// Radius of the bounding sphere.
        /// </summary>
        [JsonProperty("radius")]
        public double Radius { get; set; }

    }
}
