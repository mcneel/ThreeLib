using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;

namespace IrisLib
{
    public class IrisGeometryBuffer : IrisElement
    {
        [JsonProperty("data")]
        public IrisBufferGeometryData Data { get; private set; }

        public IrisGeometryBuffer()
        {
            Type = "BufferGeometry";
        }

        public IrisGeometryBuffer(double[] point, Color color, double[] center, double radius):this(new List<double[]> { { point } }, new List<Color> { { color } }, center, radius)
        { }

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

    public class IrisBufferGeometryData
    {
        [JsonProperty("attributes")]
        public IIrisBufferGeometryDataAttributes Attributes { get; set; }

        [JsonProperty("boundingSphere")]
        public IrisBufferGeometryDataBoundingSphere BoundingSphere { get; set; }

    }

    public interface IIrisBufferGeometryDataAttributes { }

    public class IrisBufferGeometryDataAttributes : IIrisBufferGeometryDataAttributes
    {
        [JsonProperty("position")]
        public IrisBufferGeometryArrayAttribute Position { get; set; }

        [JsonProperty("normal")]
        public IrisBufferGeometryArrayAttribute Normal { get; set; }

        [JsonProperty("color")]
        public IrisBufferGeometryArrayAttribute Color { get; set; }

        [JsonProperty("uv")]
        public IrisBufferGeometryArrayAttribute UV { get; set; }

    }

    public class IrisBufferGeometryPointDataAttributes : IIrisBufferGeometryDataAttributes
    {

        [JsonProperty("position")]
        public IrisBufferGeometryArrayAttribute Position { get; set; }

        [JsonProperty("color")]
        public IrisBufferGeometryArrayAttribute Color { get; set; }

    }

    public class IrisBufferGeometryAttribute
    {
        [JsonProperty("itemSize", Order = -2)]
        public int ItemSize { get; set; }

        [JsonProperty("type", Order = -2)]
        public string Type { get; set; }
    }

    public class IrisBufferGeometryArrayAttribute : IrisBufferGeometryAttribute
    {
        [JsonProperty("array")]
        public List<float> Array { get; set; }

        public IrisBufferGeometryArrayAttribute(int size, string type)
        {
            ItemSize = size;
            Type = "Float32Array";
        }

    }

    public class IrisBufferGeometryDataBoundingSphere
    {
        [JsonProperty("center")]
        public double[] Center { get; set; }

        [JsonProperty("radius")]
        public double Radius { get; set; }

    }
}
