using Newtonsoft.Json;
using System;

namespace THREE.Materials
{
    /// <summary>
    /// 
    /// </summary>
    public class LineBasicMaterial : Material, IEquatable<LineBasicMaterial>
    {

        /// <summary>
        /// The material color.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Include)]
        public int Color { get; set; }

        /// <summary>
        /// The curve linewidth.
        /// </summary>
        public float LineWidth { get; set; }

        /// <summary>
        /// The type of capping for the line.
        /// </summary>
        [JsonProperty("linecap")]
        public string LineCap { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("linejoin")]
        public string LineJoin { get; set; }

        public bool Equals(LineBasicMaterial other)
        {
            if (other == null)
            {
                return false;
            }
            else
            {
                return Color.Equals(other.Color) &&
                       LineWidth.Equals(other.LineWidth)&&
                       LineJoin.Equals(other.LineJoin)&&
                       LineCap.Equals(other.LineCap);
            }
        }

        public override bool Equals(Material other)
        {
            if (other.GetType() == typeof(LineBasicMaterial)) return Equals((LineBasicMaterial)other) && base.Equals(other);
            else return false;
        }
    }
}
