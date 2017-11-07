using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace THREE.Core
{
    public class BufferGeometry : IGeometry
    {
        [JsonProperty("type")]
        public string Type { get; private set; }

        [JsonProperty("uuid")]
        public Guid Uuid { get; private set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("data")]
        BufferGeometryData Data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public BufferGeometryBoundingSphere BoundingSphere
        {
            get { return Data.BoundingSphere; }
            set { Data.BoundingSphere = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public List<BufferAttribute> Attributes
        {
            get { return Data.Attributes; }
            set { Data.Attributes = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public BufferGeometry()
        {
            Type = GetType().Name;
            Uuid = Guid.NewGuid();
        }
    }

    internal class BufferGeometryData
    {
        [JsonProperty("attributes")]
        internal List<BufferAttribute> Attributes { get; set; }

        [JsonProperty("boundingSphere")]
        internal BufferGeometryBoundingSphere BoundingSphere { get; set; }
    }

    /// <summary>
    /// Data for the bounding sphere.
    /// </summary>
    public class BufferGeometryBoundingSphere
    {
        /// <summary>
        /// Center position of the bounding sphere.
        /// </summary>
        [JsonProperty("center")]
        public float[] Center { get; set; }

        /// <summary>
        /// Radius of the bounding sphere.
        /// </summary>
        [JsonProperty("radius")]
        public float Radius { get; set; }

    }
}
