using Newtonsoft.Json;

namespace THREE
{
    /// <summary>
    /// 
    /// Analogous to: https://github.com/mrdoob/three.js/blob/master/src/lights/SpotLightShadow.js
    /// Original Source: https://github.com/mrdoob/three.js/blob/master/src/lights/SpotLightShadow.js
    /// </summary>
    public class SpotLightShadow : LightShadow
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("camera")]
        public new PerspectiveCamera Camera { get; set; }
    }
}
