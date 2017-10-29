using Newtonsoft.Json;
using System;

namespace IrisLib
{
    /// <summary>
    /// Analogous to https://github.com/mrdoob/three.js/blob/master/src/materials/PointsMaterial.js
    /// </summary>
    public class PointsMaterial : MaterialBase<PointsMaterial>
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

        public new bool Equals(PointsMaterial other)
        {
            if (other == null)
            {
                return false;
            }
            else
            {
                return Type.Equals(other.Type) && 
                       Color.Equals(other.Color) &&
                       Map.Equals(other.Map) &&
                       Opacity.Equals(other.Opacity) &&
                       Side.Equals(other.Side) &&
                       VertexColors.Equals(other.VertexColors) &&
                       Size.Equals(other.Size) &&
                       SizeAttenuation.Equals(other.SizeAttenuation);
            }
        }
    }
}
