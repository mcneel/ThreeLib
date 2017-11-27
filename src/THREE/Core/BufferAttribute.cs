using Newtonsoft.Json;
using System;

namespace THREE.Core
{
    /// <summary>
    /// This class stores data for an attribute (such as vertex positions, face indices, normals, colors, UVs, and any custom attributes ) associated with a BufferGeometry, which allows for more efficient passing of data to the GPU.
    /// Data is stored as vectors of any length(defined by itemSize), and in general in the methods outlined below if passing in an index, this is automatically multiplied by the vector length.
    /// </summary>
    public class BufferAttribute
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("itemSize")]
        public int ItemSize { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("normalized")]
        public bool Normalized { get; set; }

        [JsonProperty("dynamic")]
        public bool Dynamic { get; set; }

        [JsonProperty("array")]
        public object[] Array { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public enum BufferAttributeType
    {
        Int8Array = 0,
        Uint8Array = 1,
        Uint8ClampedArray = 2,
        Int16Array = 3,
        Uint16Array = 4,
        Int32Array = 5,
        Uint32Array = 6,
        Float32Array = 7,
        Float64Array = 8
    }
}
