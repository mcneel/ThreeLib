using Newtonsoft.Json;
using System;
using THREE.Textures;

namespace THREE.Materials
{
    /// <summary>
    /// Analogous to https://github.com/mrdoob/three.js/blob/master/src/materials/PointsMaterial.js
    /// </summary>
    public class PointsMaterial : Material, IEquatable<PointsMaterial>
    {

        /// <summary>
        /// Material color.
        /// </summary>
        [JsonProperty("color")]
        public int Color { get; set; }

        /// <summary>
        /// Point size.
        /// </summary>
        [JsonProperty("size")]
        public double Size { get; set; }

        /// <summary>
        /// Size attenuation flag.
        /// </summary>
        [JsonProperty("sizeAttenuation", DefaultValueHandling = DefaultValueHandling.Include)]
        public bool SizeAttenuation { get; set; }

        /// <summary>
        /// The diffuse map texture.
        /// </summary>
        [JsonIgnore]
        public Texture Map { get; set; }

        /// <summary>
        /// Material diffuse color map.
        /// </summary>
        [JsonProperty("map")]
        public Guid? MapUuid
        {
            get
            {
                if (Map != null)
                    return Map.Uuid;
                else return null;
            }
        }

        public bool Equals(PointsMaterial other)
        {
            if (other == null) return false;
            else return Color.Equals(other.Color) &&
                       Size.Equals(other.Size) &&
                       SizeAttenuation.Equals(other.SizeAttenuation);
        }

        public override bool Equals(Material other)
        {
            if (other.GetType() == typeof(PointsMaterial)) return Equals((PointsMaterial)other) && base.Equals(other);
            else return false;
        }
    }
}
