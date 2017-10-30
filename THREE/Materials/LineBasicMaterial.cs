using Newtonsoft.Json;
using System;

namespace IrisLib
{
    /// <summary>
    /// 
    /// </summary>
    public class LineBasicMaterial : Material, IEquatable<LineBasicMaterial>
    {

        /// <summary>
        /// The material color.
        /// </summary>
        [JsonProperty("color", DefaultValueHandling = DefaultValueHandling.Include)]
        public int Color { get; set; }

        /// <summary>
        /// The curve linewidth.
        /// </summary>
        [JsonProperty("linewidth")]
        public float LineWidth { get; set; }

        /// <summary>
        /// 
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
