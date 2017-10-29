using Newtonsoft.Json;

namespace IrisLib
{
    /// <summary>
    /// 
    /// </summary>
    public class LineBasicMaterial : MaterialBase<LineBasicMaterial>
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

        public new bool Equals(LineBasicMaterial other)
        {
            if (other == null)
            {
                return false;
            }
            else
            {
                return Color.Equals(other.Color) &&
                       Opacity.Equals(other.Opacity) &&
                       Side.Equals(other.Side) &&
                       VertexColors.Equals(other.VertexColors)&&
                       LineWidth.Equals(other.LineWidth)&&
                       LineJoin.Equals(other.LineJoin)&&
                       LineCap.Equals(other.LineCap);
            }
        }
    }
}
