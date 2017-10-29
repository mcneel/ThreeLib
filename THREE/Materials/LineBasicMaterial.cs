using Newtonsoft.Json;

namespace IrisLib
{
    /// <summary>
    /// 
    /// </summary>
    public class LineBasicMaterial : Material<LineBasicMaterial>
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

        /// <summary>
        /// Default constructor.
        /// </summary>
        public LineBasicMaterial()
        {
            Type = "LineBasicMaterial";
        }
    }
}
