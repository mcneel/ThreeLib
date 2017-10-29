using Newtonsoft.Json;
using System;

namespace IrisLib
{
    /// <summary>
    /// 
    /// </summary>
    public class Line : Object3D
    {
        /// <summary>
        /// The geometry associated with this Mesh.
        /// </summary>
        [JsonIgnore]
        public IGeometry Geometry { get; set; }

        /// <summary>
        /// Uuid of this geometry.
        /// </summary>
        [JsonProperty("geometry")]
        public Guid GeometryUuid { get { return (Geometry as Geometry).Uuid; } }

        /// <summary>
        /// The material associated with this mesh.
        /// </summary>
        [JsonIgnore]
        public IMaterial Material { get; set; }

        /// <summary>
        /// This object's material Uuid.
        /// </summary>
        [JsonProperty("material")]
        public Guid MaterialUuid { get { return (Material as MaterialBase).Uuid; } }

        /// <summary>
        /// 
        /// </summary>
        public Line()
        {
            Type = "Line";
        }
    }
}
