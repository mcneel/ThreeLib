using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace THREE.Core
{
    public class BufferGeometry : Element, IGeometry
    {

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
        public Dictionary<string, BufferAttribute> Attributes
        {
            get { return Data.Attributes; }
            set { Data.Attributes = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public BufferGeometry()
        {
            Data = new BufferGeometryData();
            Attributes = new Dictionary<string, BufferAttribute>();
            BoundingSphere = new BufferGeometryBoundingSphere();
        }
    }

    internal class BufferGeometryData
    {
        [JsonProperty("attributes")]
        internal Dictionary<string, BufferAttribute> Attributes { get; set; }

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
