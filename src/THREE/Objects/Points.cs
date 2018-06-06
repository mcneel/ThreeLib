using Newtonsoft.Json;
using System;
using THREE.Core;
using THREE.Materials;

namespace THREE.Objects
{
    public class Points : Object3D
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
        public Guid GeometryUuid { get { return (Geometry as Element).Uuid; } }

        /// <summary>
        /// The material associated with this mesh.
        /// </summary>
        [JsonIgnore]
        public IMaterial Material { get; set; }

        /// <summary>
        /// This object's material Uuid.
        /// </summary>
        [JsonProperty("material")]
        public Guid MaterialUuid { get { return (Material as Material).Uuid; } }

    }
}
