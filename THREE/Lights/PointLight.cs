using Newtonsoft.Json;

namespace IrisLib
{
    /// <summary>
    /// Analogous to: https://github.com/mrdoob/three.js/blob/dev/src/lights/PointLight.js
    /// </summary>
    public class PointLight: Light
    {
        /// <summary>
        /// Light distance.
        /// </summary>
        [JsonProperty("distance")]
        public float Distance { get; set; }

        /// <summary>
        /// Light decay.
        /// </summary>
        [JsonProperty("decay")]
        public float Decay { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public PointLight()
        {
            Type = "PointLight";
        }
    }
}
