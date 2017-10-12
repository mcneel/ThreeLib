using Newtonsoft.Json;
using System.Collections.Generic;

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
        public IrisBufferGeometryData Data { get; set; }

        /// <summary>
        /// Constructor for Buffer Geometry
        /// </summary>
        public IrisGeometryBuffer()
        {
            Type = "BufferGeometry";
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
